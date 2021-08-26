using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ManufacturerViewModel> Manufacturers { get; set; }

        public void OnGet()
        {
            Manufacturers = _context.Manufacturers.Select(manufacturer => new ManufacturerViewModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
            }).ToList();
        }
    }
}
