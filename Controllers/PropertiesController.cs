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
            
            PropertiesViewmodel vm = new PropertiesViewmodel
            {
                Context = _context
            };
            await vm.GetAllProperties();
            return View(vm);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            PropertiesViewmodel vm = new PropertiesViewmodel
            {
                Context = _context
            };

            await vm.GetDetails(id);
            return View(null, vm);
        }

    }
}
