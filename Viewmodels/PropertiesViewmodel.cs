using AirBnbMVC.Models;
using Microsoft.EntityFrameworkCore;
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
        public AirBnbContext Context { get; set; }

        public async Task GetDetails(int? id)
        {
            if (id == null || Context.Properties == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var property = await Context.Properties
                .Include(s => s.Landlord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

           Property = property;
        }

        public async Task GetAllProperties()
        {
            var airBnbContext = Context.Properties.Include(s => s.Landlord);
            var properties = await airBnbContext.ToListAsync();
            Properties = properties;
        }

    }
}
