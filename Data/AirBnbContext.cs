using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirBnbMVC.Models;

    public class AirBnbContext : DbContext
    {
        public AirBnbContext (DbContextOptions<AirBnbContext> options)
            : base(options)
        {
        }

    public DbSet<Landlord> Landlords { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }

    public DbSet<Reservation> Reservations { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AirBnbWPFDatabase;Integrated Security=SSPI;");
        base.OnConfiguring(optionsBuilder);

    }
}
