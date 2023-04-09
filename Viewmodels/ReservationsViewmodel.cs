using AirBnbMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirBnbMVC.Viewmodels
{
    public class ReservationsViewmodel
    {
        public int Id { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Einddatum")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

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
                var totalNights = (Reservation.EndDate - Reservation.StartDate).Days;
                var nightlyRate = Property.PricePerNight;
                var subtotal = totalNights * nightlyRate;
                return subtotal;
            }
        }

    }
}
