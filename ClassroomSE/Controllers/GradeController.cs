using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassroomSE;
using ClassroomSE.Models;
using Microsoft.AspNetCore.Authorization;
using ClassroomSE.Abstractions;

namespace ClassroomSE.Controllers
{
    
    public class GradeController : Controller
    {
        private readonly IGradeRepository _context;

        public GradeController(IGradeRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var grades = from grade in _context.GetAll()
                           select grade;
            return View(grades);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade grade = _context.GetGradeByGradeId(id);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                grade.GradeID = Guid.NewGuid();
                _context.Add(grade);
                _context.Update(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade grade = _context.GetGradeByGradeId(id);

            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Grade grade)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(grade);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(grade);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade grade = _context.GetGradeByGradeId(id);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Grade grade = _context.GetGradeByGradeId(id);
            _context.Delete(grade);
            return RedirectToAction("Index");
        }

    }
}
