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
        
        public IList<CarViewModel> Cars { get; set; }

        public void OnGet()
        {
            Cars = _context.Cars.Select(car => new CarViewModel
            {
                Id = car.Id,
                RegNo = car.RegNo,
                Model = car.Model,
                ManufacturerName = _context.Manufacturers.First(manufacturer => manufacturer.Id == car.Manufacturer.Id).Name,
                Price = car.Price,
                Year = car.Year,
            }).ToList();
        }
    }

}
