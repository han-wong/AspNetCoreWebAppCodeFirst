using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class CarsModel : PageModel
    {
        private ApplicationDbContext _context;

        public CarsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public class CarViewModel
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public decimal Price { get; set; }
            public int Year { get; set; }
        }
        public List<CarViewModel> Cars { get; set; }

        public void OnGet()
        {
            Cars = _context.Cars.Select(c => new CarViewModel
            {
                Model = c.Model,
                Manufacturer = _context.Manufacturers.First(m => m.Id == c.Manufacturer.Id).Name,
                Price = c.Price,
                Year = c.Year,
            }).ToList();
        }
        
    }

}
