using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using AspNetCoreWebAppCodeFirst.Pages.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string ManufacturerName { get; set; }
        public List<CarItem> ListOfCars { get; set; } = new();
        public class CarItem
        {
            public string RegNo { get; set; }
            public int Year { get; set; }
        }
        public ManufacturerViewModel Manufacturer { get; set; }
        public IActionResult OnGet(int manufacturerId)
        {
            if (manufacturerId == 0)
            {
                return NotFound();
            }
            var currentManufacturer = _context.Manufacturers.Include(manufacturer => manufacturer.Trucks).First(manufacturer => manufacturer.Id == manufacturerId);
            ManufacturerName = currentManufacturer.Name.ToUpper();

            ListOfCars = currentManufacturer.Trucks.Select(car => new CarItem
            {
                RegNo = car.RegNo,
                Year = car.Year
            }).ToList();

            return Page();
        }
    }

}
