using System.ComponentModel.DataAnnotations;

namespace AirBnbMVC.Models
{
    public class Landlord
    {

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name ="Naam verhuurder")]
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
