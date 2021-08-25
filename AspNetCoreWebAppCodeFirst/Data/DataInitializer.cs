using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class DataInitializer
    {
        private static readonly Dictionary<string, Dictionary<string, List<string>>> 
            _vehicles = new Dictionary<string, Dictionary<string, List<string>>> {
            { 
                "cars", new Dictionary<string, List<string>> {
                    { "XC90", new List<string> { "Volvo", "250000", "2002" } },
                    { "Supra", new List<string> { "Toyota", "160000", "1978" } },
                    { "Leaf", new List<string> { "Nissan", "170000", "2011" } },
                    { "Polo", new List<string> { "Volkswagen", "180000", "2010" } },
                    { "S-Max", new List<string> { "Ford", "300000", "2007" } },
                }
            },
            {
                "trucks", new Dictionary<string, List<string>> {
                    { "R730", new List<string> { "Scania", "425000", "2011" } },
                    { "TGX", new List<string> { "MAN", "472000", "2017" } },
                    { "Actros", new List<string> { "Mercedes-Benz", "599000", "2011" } },
                }
            },
        };

        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedManufacturers(dbContext);
            SeedCars(dbContext);
            SeedTrucks(dbContext);
        }

        private static void SeedManufacturers(ApplicationDbContext dbContext)
        {
            foreach (var type in _vehicles)
            {
                foreach (var model in type.Value)
                {
                    if (!dbContext.Manufacturers.Any(m => m.Name == model.Value[0]))
                        dbContext.Manufacturers.Add(new Manufacturer { Name = model.Value[0] });
                }
            }

            dbContext.SaveChanges();
        }

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            var cars = dbContext.Cars;
            var manufacturers = dbContext.Manufacturers;
            var models = _vehicles["cars"];
            
            foreach (var model in models)
            {
                var manufacturer = manufacturers.First(m => m.Name == model.Value[0]);
                if (!cars.Any(c => c.Model == model.Key))
                    cars.Add(new Car
                    {
                        Manufacturer = manufacturer,
                        Model = model.Key,
                        Price = int.Parse(model.Value[1]),
                        Year = int.Parse(model.Value[2]),
                    });
                else
                {
                    var car = cars.First(c => c.Model == model.Key);
                    if (car.Manufacturer == null)
                        car.Manufacturer = manufacturer;
                }
            }

            dbContext.SaveChanges();
        }

        private static void SeedTrucks(ApplicationDbContext dbContext)
        {
            var trucks = dbContext.Trucks;
            var manufacturers = dbContext.Manufacturers;
            var models = _vehicles["trucks"];
            
            foreach (var model in models)
            {
                var manufacturer = manufacturers.First(m => m.Name == model.Value[0]);
                if (!trucks.Any(c => c.Model == model.Key))
                    trucks.Add(new Truck
                    {
                        Manufacturer = manufacturer,
                        Model = model.Key,
                        Price = int.Parse(model.Value[1]),
                        Year = int.Parse(model.Value[2]),
                    });
                else
                {
                    var car = trucks.First(c => c.Model == model.Key);
                    if (car.Manufacturer == null)
                        car.Manufacturer = manufacturer;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
