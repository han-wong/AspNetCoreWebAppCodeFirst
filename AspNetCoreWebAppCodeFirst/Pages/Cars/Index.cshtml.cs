using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IList<CarItem> Cars { get; set; }
        public class CarItem
        {
            public int Id { get; set; }
            public string RegNo { get; set; }
            public string Model { get; set; }
            public string ManufacturerName { get; set; }
            public decimal Price { get; set; }
            public int Year { get; set; }
        }
        public void OnGet()
        {
            Cars = _context.Cars.Select(car => new CarItem
            {
                Id = car.Id,
                RegNo = car.RegNo,
                Model = car.Model,
                ManufacturerName = _context.Manufacturers.First(manufacturer => manufacturer.Cars.Contains(car)).Name,
                Price = car.Price,
                Year = car.Year,
            }).ToList();
        }
    }
}
