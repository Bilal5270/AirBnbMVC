namespace AirBnbMVC.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User User { get; set; }

        public Property Property { get; set; }

        public string StartDateAsString { get => StartDate.ToShortDateString(); }
        public string EndDateAsString { get => EndDate.ToShortDateString(); }



    }
}
