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
    
    public class CourseController : Controller
    {
        private readonly ICourseRepository _context;

        public CourseController(ICourseRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = from course in _context.GetAll()
                           select course;
            return View(courses);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _context.GetCourseByCourseId(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.CourseID = Guid.NewGuid();
                _context.Add(course);
                _context.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _context.GetCourseByCourseId(id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(course);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(course);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _context.GetCourseByCourseId(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Course course = _context.GetCourseByCourseId(id);
            _context.Delete(course);
            return RedirectToAction("Index");
        }

    }
}
