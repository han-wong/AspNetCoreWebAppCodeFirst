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

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class EditCarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditCarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
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
                var car = _context.Cars.Include(e => e.Manufacturer).First(r => r.Id == id);
                car.HasRadio = HasRadio;
                car.Manufacturer = _context.Manufacturers.First(r => r.Id == ManufacturerId);
                car.Model = Model;
                car.Price = Price;
                car.RegNo = RegNo;
                car.Year = Year;
                _context.SaveChanges();
                return RedirectToPage("/Cars");
            }
            return Page();
        }
    }
}
