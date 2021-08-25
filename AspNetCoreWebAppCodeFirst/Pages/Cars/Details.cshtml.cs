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

        public CarViewModel Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.Include(car => car.Manufacturer).FirstOrDefaultAsync(car => car.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            Car = new CarViewModel
            {
                Id = car.Id,
                ManufacturerName = car.Manufacturer.Name,
                Model = car.Model,
                Price = car.Price,
                RegNo = car.RegNo,
                Year = car.Year,
            };
            return Page();
        }
    }
}
