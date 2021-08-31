using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class QuestionConfirmationModel : PageModel
    {
        public string Email { get; set; }
        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
