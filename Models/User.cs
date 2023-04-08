namespace AirBnbMVC.Models
{
    public class User
    {

        public int Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public List<Reservation>? Reservations { get; set; }

        public User()
        {
            Reservations = new List<Reservation>();
        }



    }
}
