using System.ComponentModel.DataAnnotations;

namespace AirBnbMVC.Models
{
    public class Property
    {

        public int Id { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Postcode")]
        public string PostalCode { get; set; }
        [Display(Name = "Aantal Slaapkamers")]
        public int AmountOfRooms { get; set; }
        [Display(Name = "Prijs per nacht")]
        public int PricePerNight { get; set; }

        public List<Reservation> Reservations { get; set; }

        public Property()
        {
            Reservations = new List<Reservation>();
        }

        
        public int LandlordId { get; set; }
        [Display(Name = "Eigenaar")]
        public Landlord? Landlord { get; set; }


    }
}
