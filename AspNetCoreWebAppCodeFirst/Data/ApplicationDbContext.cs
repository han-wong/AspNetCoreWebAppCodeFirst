using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserRegistration> UserRegistrations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CV> CVs  { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
