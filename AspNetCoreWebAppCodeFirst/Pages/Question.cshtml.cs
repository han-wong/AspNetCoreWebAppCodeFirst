using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreWebAppCodeFirst.Pages
{
    public class QuestionModel : PageModel
    {

        [BindProperty]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [BindProperty]
        [MaxLength(512)]
        public string Question { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/QuestionConfirmation", new
                {
                    email = Email
                });
            }

            return Page();
        }
    }
}
