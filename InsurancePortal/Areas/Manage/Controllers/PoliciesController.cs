using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurancePortal.Data;
using InsurancePortal.Models;

namespace InsurancePortal.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manage/Policies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pollicies.Include(p => p.PolicyCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manage/Policies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Pollicies
                .Include(p => p.PolicyCategory)
                .FirstOrDefaultAsync(m => m.PolicyId == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // GET: Manage/Policies/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Manage/Policies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolicyId,PolicyName,PolicyImageURL,CategoryId")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName", policy.CategoryId);
            return View(policy);
        }

        // GET: Manage/Policies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Pollicies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName", policy.CategoryId);
            return View(policy);
        }

        // POST: Manage/Policies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PolicyId,PolicyName,PolicyImageURL,CategoryId")] Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyExists(policy.PolicyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName", policy.CategoryId);
            return View(policy);
        }

        // GET: Manage/Policies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Pollicies
                .Include(p => p.PolicyCategory)
                .FirstOrDefaultAsync(m => m.PolicyId == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // POST: Manage/Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policy = await _context.Pollicies.FindAsync(id);
            _context.Pollicies.Remove(policy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyExists(int id)
        {
            return _context.Pollicies.Any(e => e.PolicyId == id);
        }
    }
}
