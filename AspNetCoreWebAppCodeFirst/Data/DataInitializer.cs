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
            SeedTrucks(dbContext);
        }

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            if (!dbContext.Cars.Any(c => c.Model == "XC90"))
                dbContext.Cars.Add(new Car { 
                    Manufacturer = "Volvo", 
                    Model = "XC90", 
                    Price = 250000, 
                    Year = 2002 });
            if (!dbContext.Cars.Any(c => c.Model == "Supra"))
                dbContext.Cars.Add(new Car { 
                    Manufacturer = "Toyota", 
                    Model = "Supra", 
                    Price = 160000, 
                    Year = 1978 });
           if (!dbContext.Cars.Any(c => c.Model == "Leaf"))
                dbContext.Cars.Add(new Car { 
                    Manufacturer = "Nissan", 
                    Model = "Leaf", 
                    Price = 170000, 
                    Year = 2011 });
           if (!dbContext.Cars.Any(c => c.Model == "Polo"))
                dbContext.Cars.Add(new Car { 
                    Manufacturer = "Volkswagen", 
                    Model = "Polo", 
                    Price = 180000, 
                    Year = 2010 });
           if (!dbContext.Cars.Any(c => c.Model == "S-Max"))
                dbContext.Cars.Add(new Car { 
                    Manufacturer = "Ford", 
                    Model = "S-Max", 
                    Price = 300000, 
                    Year = 2007 });
            dbContext.SaveChanges();
        }

        private static void SeedTrucks(ApplicationDbContext dbContext)
        {
            if (!dbContext.Trucks.Any(c => c.Model == "R730"))
                dbContext.Trucks.Add(new Truck
                {
                    Manufacturer = "Scania", 
                    Model = "R730", 
                    Price = 425000, 
                    Year = 2011
                });
            if (!dbContext.Trucks.Any(c => c.Model == "TGX"))
                dbContext.Trucks.Add(new Truck
                {
                    Manufacturer = "MAN", 
                    Model = "TGX", 
                    Price = 472000, 
                    Year = 2017
                });
            if (!dbContext.Trucks.Any(c => c.Model == "Actros"))
                dbContext.Trucks.Add(new Truck
                {
                    Manufacturer = "Mercedes-Benz", 
                    Model = "Actros", 
                    Price = 599000, 
                    Year = 2011
                });
            dbContext.SaveChanges();
        }
    }
}
