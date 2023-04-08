namespace AirBnbMVC.Models
{
    public class Landlord
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

        public List<Property> Properties { get; set; }


        public Landlord()
        {
            Properties = new List<Property>();
        }




    }
}
