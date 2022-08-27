using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using InsurancePortal.Areas.Show.ViewModels;
using InsurancePortal.Data;
using InsurancePortal.Models;


namespace InsurancePortal.Areas.Show.Controllers
{
    [Area("show")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName"));
            
            ViewData["CategoryId"] = categories.ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index([Bind("CategoryId")] ShowPolicyViewModels model)
        {
            // Retrieve the Menu Items for the selected category
            var items = _context.Pollicies.Where(m => m.CategoryId == model.CategoryId);

            // Populate the data into the viewmodel object
            model.Policies = items.ToList();

            // Populate the data for the drop-down select list
            ViewData["CategoryId"] = new SelectList(_context.PolicyCategories, "CategoryId", "CategoryName");

            // Display the View
            return View("Index", model);
        }

        public IActionResult AddToCart(int? id, [Bind("CategoryId", "Quantity")] ShowPolicyViewModels model)
        {
            if (id.HasValue)
            {
                int PolicyId = id.Value;
            }
            return RedirectToAction("Index");
        }
    }
}
