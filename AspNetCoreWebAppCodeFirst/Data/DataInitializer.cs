using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedCars(dbContext);
        }

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            if (!dbContext.Cars.Any(c => c.Model == "XC90"))
                dbContext.Cars.Add(new Car { Manufacturer = "Volvo", Model = "XC90", Price = 200000, Year = 2002 });
            if (!dbContext.Cars.Any(c => c.Model == "Supra"))
                dbContext.Cars.Add(new Car { Manufacturer = "Toyota", Model = "Supra", Price = 150000, Year = 1978 });
            dbContext.SaveChanges();
        }
    }
}
