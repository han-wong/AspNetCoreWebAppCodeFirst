using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Data
{
    public class DataInitializer
    {
        private static readonly List<Manufacturer> _seedManufacturers = new()
        {
            new Manufacturer
            {
                Name = "Volvo",
                Cars = new() { new Car { RegNo = "AAA123", Year = 2002, Price = 250000, Model = "XC90" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Toyota",
                Cars = new() { new Car { RegNo = "BBB456", Year = 1978, Price = 160000, Model = "Supra" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Nissan",
                Cars = new() { new Car { RegNo = "CCC789", Year = 2011, Price = 170000, Model = "Leaf" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Volkswagen",
                Cars = new() { new Car { RegNo = "DDD135", Year = 2010, Price = 180000, Model = "Polo" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Ford",
                Cars = new() { new Car { RegNo = "EEE246", Year = 2007, Price = 300000, Model = "S-Max" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Tesla",
                Cars = new() { new Car { RegNo = "COVID9", Year = 2019, Price = 1000000, Model = "Model S" }, },
                Trucks = new()
            },
            new Manufacturer
            {
                Name = "Scania",
                Cars = new(),
                Trucks = new() { new Truck { RegNo = "FFF666", Year = 2011, Price = 425000, Model = "R730" }, }
            },
            new Manufacturer
            {
                Name = "MAN",
                Cars = new(),
                Trucks = new() { new Truck { RegNo = "ABC111", Year = 2017, Price = 472000, Model = "TGX" }, }
            },
            new Manufacturer
            {
                Name = "Mercedes-Benz",
                Cars = new(),
                Trucks = new() { new Truck { RegNo = "DEF222", Year = 2011, Price = 599000, Model = "Actros" }, }
            },
        };

        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.Manufacturers.Any())
            {
                SeedManufacturers(context);
                SeedCars(context);
                SeedTrucks(context);
            }
        }

        private static void SeedManufacturers(ApplicationDbContext context)
        {
            foreach (var seedManufacturer in _seedManufacturers)
            {
                var seedName = seedManufacturer.Name;
                if (!context.Manufacturers.Any(manufacturer => manufacturer.Name == seedName))
                    context.Manufacturers.Add(new Manufacturer { Name = seedName });
            }

            context.SaveChanges();
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            foreach (var seedManufacturer in _seedManufacturers)
            {
                var contextCars = context.Manufacturers.First(manufacturer => manufacturer.Name == seedManufacturer.Name).Trucks;
                foreach (var seedCar in seedManufacturer.Trucks)
                {
                    if (contextCars.Any(car => car.RegNo == seedCar.RegNo))
                        contextCars.Add(seedCar);
                }
            }

            context.SaveChanges();
        }

        private static void SeedTrucks(ApplicationDbContext context)
        {
            foreach (var seedManufacturer in _seedManufacturers)
            {
                var contextTrucks = context.Manufacturers.First(manufacturer => manufacturer.Name == seedManufacturer.Name).Trucks;
                foreach (var seedTruck in seedManufacturer.Trucks)
                {
                    if (contextTrucks.Any(truck => truck.RegNo == seedTruck.RegNo))
                        contextTrucks.Add(seedTruck);
                }
            }

            context.SaveChanges();
        }
    }
}
