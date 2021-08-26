using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebAppCodeFirst.Data;

namespace AspNetCoreWebAppCodeFirst.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }


        public async Task<IActionResult> OnGetAsync(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }
            var currentCar = await _context.Cars.FirstOrDefaultAsync(car => car.Id == carId);
            if (currentCar == null)
            {
                return NotFound();
            }

            Id = (int)carId;
            Manufacturer = _context.Manufacturers.First(manufacturer => manufacturer.Cars.Contains(currentCar)).Name;
            Model = currentCar.Model;
            Price = currentCar.Price;
            RegNo = currentCar.RegNo;
            Year = currentCar.Year;

            return Page();
        }
    }
}
