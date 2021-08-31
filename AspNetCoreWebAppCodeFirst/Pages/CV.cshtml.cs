using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    [BindProperties]
    public class CVModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CVModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }
        public bool HasCar { get; set; }
        public bool HasLicense { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public List<string> AllPossibleWorkLocations { get; set; }
        public List<Education> Educations { get; set; }
        public string SelectedLocation { get; set; }

        public void OnGet()
        {
            AllPossibleWorkLocations = Enum.GetNames(typeof(PossibleWorkLocation)).Select(location => location).ToList();
        }
    }
}
