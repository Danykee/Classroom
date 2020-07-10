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
    
    
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _context;

        public AssignmentController(IAssignmentRepository context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var assignments = from assignment in _context.GetAll()
                           select assignment;
            return View(assignments);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment = _context.GetAssignmentByAssignmentId(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                assignment.AssignmentID = Guid.NewGuid();
                _context.Add(assignment);
                _context.Update(assignment);
                return RedirectToAction("Index");
            }
            return View(assignment);
        }
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment = _context.GetAssignmentByAssignmentId(id);

            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Assignment assignment)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(assignment);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(assignment);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment = _context.GetAssignmentByAssignmentId(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Assignment assignment = _context.GetAssignmentByAssignmentId(id);
            _context.Delete(assignment);
            return RedirectToAction("Index");
        }

    }
}
