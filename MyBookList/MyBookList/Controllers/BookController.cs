using Microsoft.AspNetCore.Mvc;
using MyBookList.Models;

namespace MyBookList.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        #region Constructor
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion


        // /Controller/Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _context.Books.ToList()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Json(new { success = true, message = "Deleted Successful!" });
            }

            return Json(new { success = false, message = "Delete fails!" });
        }
    }
}
