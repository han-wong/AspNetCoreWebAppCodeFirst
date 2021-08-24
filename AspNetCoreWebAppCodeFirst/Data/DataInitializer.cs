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
            SeedManufacturers(dbContext);
            SeedCars(dbContext);
            SeedTrucks(dbContext);
        }

        private static void SeedManufacturers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Manufacturers.Any(m => m.Name == "Ford"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Ford" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "MAN"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "MAN" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Mercedes-Benz"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Mercedes-Benz" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Nissan"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Nissan" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Scania"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Scania" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Toyota"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Toyota" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Volkswagen"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Volkswagen" });
            if (!dbContext.Manufacturers.Any(m => m.Name == "Volvo"))
                dbContext.Manufacturers.Add(new Manufacturer { Name = "Volvo" });
        }

        private static void SeedCars(ApplicationDbContext dbContext)
        {
            var cars = dbContext.Cars;
            var manufacturers = dbContext.Manufacturers;

            var car = cars.First(c => c.Model == "XC90");
            var manufacturer = manufacturers.First(m => m.Name == "Volvo");
            if (car == null)
                cars.Add(new Car
                {
                    Manufacturer = manufacturer,
                    Model = "XC90",
                    Price = 250000,
                    Year = 2002
                });
            else if (car.Manufacturer == null)
                car.Manufacturer = manufacturer;

            car = cars.First(c => c.Model == "Supra");
            manufacturer = manufacturers.First(m => m.Name == "Toyota");
            if (car == null)
                cars.Add(new Car
                {
                    Manufacturer = manufacturer,
                    Model = "Supra",
                    Price = 160000,
                    Year = 1978
                });
            else if (car.Manufacturer == null)
                car.Manufacturer = manufacturer;

            car = cars.First(c => c.Model == "Leaf");
            manufacturer = manufacturers.First(m => m.Name == "Nissan");
            if (car == null)
                cars.Add(new Car
                {
                    Manufacturer = manufacturer,
                    Model = "Leaf",
                    Price = 170000,
                    Year = 2011
                });
            else if (car.Manufacturer == null)
                car.Manufacturer = manufacturer;

            car = cars.First(c => c.Model == "Polo");
            manufacturer = manufacturers.First(m => m.Name == "Volkswagen");
            if (car == null)
                cars.Add(new Car
                {
                    Manufacturer = manufacturer,
                    Model = "Polo",
                    Price = 180000,
                    Year = 2010
                });
            else if (car.Manufacturer == null)
                car.Manufacturer = manufacturer;

            car = cars.First(c => c.Model == "S-Max");
            manufacturer = manufacturers.First(m => m.Name == "Ford");
            if (car == null)
                cars.Add(new Car
                {
                    Manufacturer = manufacturer,
                    Model = "S-Max",
                    Price = 300000,
                    Year = 2007
                });
            else if (car.Manufacturer == null)
                car.Manufacturer = manufacturer;

            dbContext.SaveChanges();
        }

        private static void SeedTrucks(ApplicationDbContext dbContext)
        {
            var trucks = dbContext.Trucks;
            var manufacturers = dbContext.Manufacturers;

            var truck = trucks.First(c => c.Model == "R730");
            var manufacturer = manufacturers.First(m => m.Name == "Scania");
            if (truck == null)
                trucks.Add(new Truck
                {
                    Manufacturer = manufacturer,
                    Model = "R730",
                    Price = 425000,
                    Year = 2011
                });
            else if (truck.Manufacturer == null)
                truck.Manufacturer = manufacturer;

            truck = trucks.First(c => c.Model == "TGX");
            manufacturer = manufacturers.First(m => m.Name == "MAN");
            if (truck == null)
                trucks.Add(new Truck
                {
                    Manufacturer = manufacturer,
                    Model = "TGX",
                    Price = 472000,
                    Year = 2017
                });
            else if (truck.Manufacturer == null)
                truck.Manufacturer = manufacturer;

            truck = trucks.First(c => c.Model == "Actros");
            manufacturer = manufacturers.First(m => m.Name == "Mercedes-Benz");
            if (truck == null)
                trucks.Add(new Truck
                {
                    Manufacturer = manufacturer,
                    Model = "Actros",
                    Price = 599000,
                    Year = 2011
                });
            else if (truck.Manufacturer == null)
                truck.Manufacturer = manufacturer;

            dbContext.SaveChanges();
        }
    }
}
