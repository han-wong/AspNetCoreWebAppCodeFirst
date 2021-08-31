using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class HiddenInputModel : PageModel
    {
        public void OnGet()
        {
            Count = 0;

        }

        public void OnPost()
        {
                Count++;
        }

        [BindProperty]
        [HiddenInput]
        public int Count { get; set; }
    }
}
