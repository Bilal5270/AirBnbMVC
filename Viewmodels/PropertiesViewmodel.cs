using AirBnbMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Property = AirBnbMVC.Models.Property;

namespace AirBnbMVC.Viewmodels
{
    public class PropertiesViewmodel
    {
        public Property Property { get; set; }
        public List<Property> Properties { get; set; } 

    }
}
