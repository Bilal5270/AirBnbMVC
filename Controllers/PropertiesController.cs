using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBnbMVC.Models;
using AirBnbMVC.Viewmodels;

namespace AirBnbMVC.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly AirBnbContext _context;

        public PropertiesController(AirBnbContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var airBnbContext = _context.Properties.Include(s => s.Landlord);
            var properties = await airBnbContext.ToListAsync();
            PropertiesViewmodel vm = new PropertiesViewmodel
            {
                Properties = properties
            };
            return View(vm);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Properties == null)
            {
                return NotFound();
            }

            var property = await _context.Properties
                .Include(s => s.Landlord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            PropertiesViewmodel vm = new PropertiesViewmodel
            {
                Property = property
            };

            return View(null, vm);
        }

    }
}
