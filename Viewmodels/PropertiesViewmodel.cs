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

        public async Task Filtering(string city, int? minPrice, int? maxPrice, int? minRooms)
        {
            var list = Context.Properties.Include(p => p.Landlord).AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                list = list.Where(p => p.City.Contains(city));
            }

            if (minPrice.HasValue)
            {
                list = list.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                list = list.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (minRooms.HasValue)
            {
                list = list.Where(p => p.AmountOfRooms >= minRooms.Value);
            }

            var properties = await list.ToListAsync();

            Properties = properties;
        }
    }
}
