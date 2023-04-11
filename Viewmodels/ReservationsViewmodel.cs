using AirBnbMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirBnbMVC.Viewmodels
{
    public class ReservationsViewmodel
    {
        public AirBnbContext Context { get; set; }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Einddatum")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        public int PropertyId { get; set; }
        [Display(Name = "Locatie")]
        public Property Property { get; set; }
        public Reservation Reservation { get; set; }

        [Display(Name = "Je totale prijs is")]

        public int TotalPrice
        {
            get
            {
                if (Reservation == null || Property == null)
                {
                    return 0;
                }
                var totalNights = (Reservation.EndDate - Reservation.StartDate).Days;
                var nightlyRate = Property.PricePerNight;
                var subtotal = totalNights * nightlyRate;
                return subtotal;
            }
        }

        public ReservationsViewmodel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
        public async Task CreateReservation(ReservationsViewmodel viewModel)
        {
            var reservations = Context.Reservations.Where(reservation => reservation.Property == Property && 
            ((StartDate >= reservation.StartDate && EndDate <= reservation.EndDate)
            || (StartDate >= reservation.StartDate && StartDate <= reservation.EndDate)));
            if (reservations.Any())
            {
                throw new Exception("Er bestaat al een reservering op deze datum");
            }
            var newUser = new User
            {
                FirstName = FirstName,
                LastName = LastName
            };

            Context.Users.Add(newUser);
            await Context.SaveChangesAsync();


            var reservation = new Reservation
            {
                StartDate = StartDate,
                EndDate = EndDate,
                UserId = newUser.Id,
                PropertyId = PropertyId
            };

            Context.Reservations.Add(reservation);
            await Context.SaveChangesAsync();

            viewModel.Reservation = reservation;
        }
        public void Load(int propertyId)
        {
            Property = Context.Properties.FirstOrDefault(p => p.Id == propertyId);
        }

        public async Task GetDetails(int? id)
        {
            if (id == null || Context.Reservations == null)
            {
                throw new Exception("Geen reservering gevonden.");
            }

            var reservation = await Context.Reservations
                .Include(r => r.Property)
                .ThenInclude(p => p.Landlord)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                throw new Exception("Geen reservering gevonden.");
            }
            var property = reservation.Property;

            Property = property;
            Reservation = reservation;
        }
    }
}
