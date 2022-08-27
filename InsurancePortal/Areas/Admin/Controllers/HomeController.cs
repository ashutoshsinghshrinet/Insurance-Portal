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

namespace InsurancePortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="AppAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
