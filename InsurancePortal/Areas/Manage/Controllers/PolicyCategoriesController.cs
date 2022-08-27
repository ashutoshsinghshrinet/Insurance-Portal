using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurancePortal.Data;
using InsurancePortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace InsurancePortal.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PolicyCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolicyCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manage/PolicyCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.PolicyCategories.ToListAsync());
        }

        // GET: Manage/PolicyCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyCategory = await _context.PolicyCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (policyCategory == null)
            {
                return NotFound();
            }

            return View(policyCategory);
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: Manage/PolicyCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/PolicyCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryImageURL")] PolicyCategory policyCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policyCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policyCategory);
        }

        // GET: Manage/PolicyCategories/Edit/5
        [Authorize(Roles = "AppAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyCategory = await _context.PolicyCategories.FindAsync(id);
            if (policyCategory == null)
            {
                return NotFound();
            }
            return View(policyCategory);
        }

        // POST: Manage/PolicyCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryImageURL")] PolicyCategory policyCategory)
        {
            if (id != policyCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyCategoryExists(policyCategory.CategoryId))
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
            return View(policyCategory);
        }

        // GET: Manage/PolicyCategories/Delete/5
        [Authorize(Roles = "AppAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyCategory = await _context.PolicyCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (policyCategory == null)
            {
                return NotFound();
            }

            return View(policyCategory);
        }

        // POST: Manage/PolicyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AppAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policyCategory = await _context.PolicyCategories.FindAsync(id);
            _context.PolicyCategories.Remove(policyCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyCategoryExists(int id)
        {
            return _context.PolicyCategories.Any(e => e.CategoryId == id);
        }
    }
}
