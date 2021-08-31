using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private ApplicationDbContext _dbContext;

        public RegisterModel(ILogger<RegisterModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public bool OkUpdates { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string First { get; set; }

        [Required]
        [MaxLength(100)]
        public string Last { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public List<SelectListItem> AllUserTypes { get; set; }

        public List<SelectListItem> AllCountries { get; set; }

        [Required]
        public int CountryId { get; set; }

        public void OnGet()
        {
            AllCountries = _dbContext.Countries.Select(country => new SelectListItem
            {
                Text = country.Name,
                Value = country.Id.ToString()
            }).ToList();

            AllUserTypes = Enum.GetNames(typeof(UserType)).Select(userType => new SelectListItem(userType, userType)).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.UserRegistrations.Add(new UserRegistration
                {
                    Country = _dbContext.Countries.First(country => country.Id == CountryId),
                    Email = Email,
                    First = First,
                    Last = Last,
                    OkUpdates = OkUpdates,
                    Password = Password,
                    UserType = UserType
                });
                _dbContext.SaveChanges();
                
                return RedirectToPage("/RegisterConfirmation", new
                {
                    firstname = First
                });
            }


            return Page();
        }
    }
}
