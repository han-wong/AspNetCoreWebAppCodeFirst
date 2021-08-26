using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppCodeFirst.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string SearchWord { get; private set; }
        public List<SearchItem> SearchItems { get; set; }

        public class SearchItem
        {
        }
        public IActionResult OnGet(string query)
        {
            SearchItems = new();
            if (query == null)
            {
                return Page();
            }

            SearchWord = query;
            return Page();
        }
    }
}
