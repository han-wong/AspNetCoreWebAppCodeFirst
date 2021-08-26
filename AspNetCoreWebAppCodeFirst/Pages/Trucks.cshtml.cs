using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class TrucksModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TrucksModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public class TruckViewModel
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public decimal Price { get; set; }
            public int Year { get; set; }
        }
        public List<TruckViewModel> Trucks{ get; set; }

        public void OnGet()
        {
            Trucks = _context.Trucks.Select(c => new TruckViewModel
            {
                Model = c.Model,
                //Manufacturer = _context.Manufacturers.First(m => m.Id == c.Manufacturer.Id).Name,
                Price = c.Price,
                Year = c.Year,
            }).ToList();
        }
    }

}
