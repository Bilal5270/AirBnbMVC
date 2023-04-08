namespace AirBnbMVC.Models
{
    public class Property
    {

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public int AmountOfRooms { get; set; }

        public int PricePerNight { get; set; }

        public List<Reservation> Reservations { get; set; }

        public Property()
        {
            Reservations = new List<Reservation>();
        }


        public Landlord? Landlord { get; set; }


    }
}
