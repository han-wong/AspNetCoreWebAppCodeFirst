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
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Id { get; set; }
        public List<SelectListItem> AllManufacturers { get; set; }

        public bool HasRadio { get; set; }

        public int ManufacturerId { get; set; }

        public string Model { get; set; }

        [Range(1, 1999999)]
        public decimal Price { get; set; }

        [MaxLength(6)]
        public string RegNo { get; set; }

        [Range(1950, 2025)]
        public int Year { get; set; }

        public IActionResult OnGet(int carId)
        {
            if (carId == 0)
            {
                return NotFound();
            }

            Id = carId;
            var currentCar =_context.Cars.First(car => car.Id == carId);

            if (currentCar == null)
            {
                return NotFound();
            }

            HasRadio = currentCar.HasRadio;
            ManufacturerId = _context.Manufacturers.First(manufacturer => manufacturer.Cars.Contains(currentCar)).Id;
            Model = currentCar.Model;
            Price = currentCar.Price;
            RegNo = currentCar.RegNo;
            Year = currentCar.Year;

            AllManufacturers = _context.Manufacturers.Select(manufacturer => new SelectListItem
            {
                Text = manufacturer.Name,
                Value = manufacturer.Id.ToString()
            }).ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            var currentCar = _context.Cars.First(car => car.Id == Id);

            if (currentCar == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentManufacturer = _context.Manufacturers.First(manufacturer => manufacturer.Id == ManufacturerId);
                if (!currentManufacturer.Cars.Contains(currentCar))
                {
                    currentManufacturer.Cars.Add(currentCar);
                }
                currentCar.HasRadio = HasRadio;
                currentCar.Model = Model;
                currentCar.Price = Price;
                currentCar.Year = Year;
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
