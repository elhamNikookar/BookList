using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBookList.Pages.BookList
{
    public class IndexModel : PageModel
    {
        #region Constructor

        private readonly ApplicationDbContext _context;

        public IEnumerable<Book> Books { get; set; }
        public string PageName { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion



        public void OnGet()
        {
            PageName = "Book List";
            Books = _context.Books.ToList();
        }

        public IActionResult OnGetDelete(int ID)
        {
            var book = _context.Books.Find(ID);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
