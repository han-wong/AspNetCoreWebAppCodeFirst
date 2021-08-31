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
        private readonly ApplicationDbContext _dbContext;
        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> AllManufacturers { get; set; }

        public Manufacturer Manufacturer  { get; set; }

        public Car Car { get; set; }

        [HiddenInput]
        public int CarId { get; set; }

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

            CarId = carId;

            Car = _dbContext.Cars.First(car => car.Id == CarId);

            if (Car == null)
            {
                return NotFound();
            }

            AllManufacturers = _dbContext.Manufacturers.Select(manufacturer => new SelectListItem(manufacturer.Name, manufacturer.Id.ToString())).ToList();

            HasRadio = Car.HasRadio;
            Manufacturer = _dbContext.Manufacturers.First(manufacturer => manufacturer.Cars.Contains(Car));
            ManufacturerId = ManufacturerId;
            Model = Car.Model;
            Price = Car.Price;
            RegNo = Car.RegNo;
            Year = Car.Year;

            return Page();
        }

        public IActionResult OnPost()
        {
            Car = _dbContext.Cars.First(firstCar => firstCar.Id == CarId);

            if (Car == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Manufacturer = _dbContext.Manufacturers.First(manufacturer => manufacturer.Id == ManufacturerId);
                if (!Manufacturer.Cars.Contains(Car))
                {
                    Manufacturer.Cars.Add(Car);
                }
                Car.HasRadio = HasRadio;
                Car.Model = Model;
                Car.Price = Price;
                Car.Year = Year;
            
                _dbContext.SaveChanges();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
