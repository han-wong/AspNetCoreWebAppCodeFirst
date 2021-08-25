using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAppCodeFirst.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
    
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            var car = _context.Cars.Include(car => car.Manufacturer).First(car => car.Id == id);
            HasRadio = car.HasRadio;
            RegNo = car.RegNo;
            Model = car.Model;
            Price = car.Price;
            Year = car.Year;
            ManufacturerId = car.Manufacturer.Id;
            AllManufacturers = _context.Manufacturers.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }).ToList();
        }

        public List<SelectListItem> AllManufacturers { get; set; }

        [BindProperty]
        public bool HasRadio { get; set; }

        [BindProperty]
        public int ManufacturerId { get; set; }

        [BindProperty]
        public string Model { get; set; }

        [BindProperty]
        [Range(1, 1999999)]
        public decimal Price { get; set; }

        [BindProperty]
        [MaxLength(6)]
        public string RegNo { get; set; }

        [BindProperty]
        [Range(1950, 2025)]
        public int Year { get; set; }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var editCar = _context.Cars.Include(car => car.Manufacturer).First(car => car.Id == id);
                editCar.HasRadio = HasRadio;
                editCar.Manufacturer = _context.Manufacturers.First(manufacturer => manufacturer.Id == ManufacturerId);
                editCar.Model = Model;
                editCar.Price = Price;
                editCar.RegNo = RegNo;
                editCar.Year = Year;
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
