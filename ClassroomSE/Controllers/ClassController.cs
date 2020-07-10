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
    
    public class ClassController : Controller
    {
        private readonly IClassRepository _context;

        public ClassController(IClassRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var @classes = from @class in _context.GetAll()
                           select @class;
            return View(@classes);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class @class = _context.GetClassByClassId(id);

            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(Class @class)
        {
            if (ModelState.IsValid)
            {
                @class.ClassID = Guid.NewGuid();
                _context.Add(@class);
                _context.Update(@class);
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class @class = _context.GetClassByClassId(id);

            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Class @class)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(@class);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(@class);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class @class = _context.GetClassByClassId(id);

            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Class @class = _context.GetClassByClassId(id);
            _context.Delete(@class);
            return RedirectToAction("Index");
        }

    }
}
