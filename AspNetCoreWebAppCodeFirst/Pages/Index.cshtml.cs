using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebAppCodeFirst.Data;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AspNetCoreWebAppCodeFirst.Data.ApplicationDbContext _context;

        public IndexModel(AspNetCoreWebAppCodeFirst.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
        }
    }
}
