using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBnbMVC.Models;
using AirBnbMVC.Viewmodels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AirBnbMVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AirBnbContext _context;

        public ReservationsController(AirBnbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id, ReservationsViewmodel viewModel)
        {
            
            ReservationsViewmodel vm = new ReservationsViewmodel
            {
                Context = _context,
            };
            await vm.GetDetails(id);
            return View(vm);
        }

        
        [Route("Create/{propertyId}")]
        public IActionResult Create([FromRoute] int propertyId)
        {
            var vm = new ReservationsViewmodel
            {
                Context = _context,
            };
            vm.Load(propertyId);

            return View(vm);
        }

        
        [HttpPost]
        [Route("Create/{propertyId}")]
        public async Task<IActionResult> Create(ReservationsViewmodel viewModel)
        {
                
            viewModel.Context = _context;
            await viewModel.CreateReservation(viewModel);

            return RedirectToAction(nameof(Details), new { id = viewModel.Reservation.Id });
        }

    }
}
