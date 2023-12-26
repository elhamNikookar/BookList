using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBookList.Pages.BookList
{
    public class CreateModel : PageModel
    {
        #region Concstructor

        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Book Book { get; set; }
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion



        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _context.Books.Add(Book);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
