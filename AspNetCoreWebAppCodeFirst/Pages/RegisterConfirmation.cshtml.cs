using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class RegisterConfirmationModel : PageModel
    {
        public string FirstName { get; set; }
        public void OnGet(string firstname)
        {
            FirstName = firstname;
        }
    }
}