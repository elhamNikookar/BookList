using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookList.Models;

namespace MyBookList.Pages.BookList
{
    public class EditModel : PageModel
    {
        #region Constructor

        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Book Book { get; set; }
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
      
        #endregion
        public void OnGet(int ID)
        {
            Book = _context.Books.Find(ID);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Update(Book);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
