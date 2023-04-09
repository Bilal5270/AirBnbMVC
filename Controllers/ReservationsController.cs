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

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Property)
                .ThenInclude(p => p.Landlord)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            var property = reservation.Property;
            ReservationsViewmodel vm = new ReservationsViewmodel
            {
                Reservation = reservation,
                Property = property
            };
            return View(vm);
        }

        // GET: Reservations/Create
        [Route("Create/{propertyId}")]
        public IActionResult Create([FromRoute] int propertyId)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == propertyId);
            
            var vm = new ReservationsViewmodel
            {
                Property = property
            };
             
            return View(vm);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create/{propertyId}")]
        public async Task<IActionResult> Create(ReservationsViewmodel viewModel)
        {
           
                // Create a new User instance with the data from the UserViewModel
                var newUser = new User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                // Add the new user to the database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                // Use the new user's Id to create the Reservation instance
                var reservation = new Reservation
                {
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate,
                    UserId = newUser.Id,
                    PropertyId = viewModel.PropertyId
                };

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = reservation.Id });
        }

    }
}
