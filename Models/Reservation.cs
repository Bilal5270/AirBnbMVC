using System.ComponentModel.DataAnnotations;

namespace AirBnbMVC.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Einddatum")]
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int PropertyId { get; set; }
        [Display(Name = "Locatie")]
        public Property Property { get; set; }

        public string StartDateAsString { get => StartDate.ToShortDateString(); }
        public string EndDateAsString { get => EndDate.ToShortDateString(); }



    }
}
