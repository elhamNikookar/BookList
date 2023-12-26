using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookList.Models;

namespace MyBookList.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        #region Concstructor

        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Book Book { get; set; }
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if(id == null) return Page();

            Book = await _context.Books.FindAsync(id);
            if (Book == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (Book.ID == 0) _context.Books.Add(Book);
            else _context.Books.Update(Book);

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
