using GoodBooksMvc.DataAccess;
using GoodBooksMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodBooksMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly GoodBooksMvcContext _context;

        public BooksController(GoodBooksMvcContext context)
        {
            _context = context;
        }
        [Route("/[controller]")]
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            var compareBooks = HttpContext.Request.Cookies["CompareBooks"] ?? "";
            var compareIds = new HashSet<string>(compareBooks.Split(',', StringSplitOptions.RemoveEmptyEntries));
            var chosenBooks = new List<Book>();
            var otherBooks = new List<Book>(); 
            foreach(var book in books)
            {
                if(compareIds.Contains(book.Id.ToString()))
                {
                    chosenBooks.Add(book);
                }
                else
                {
                    otherBooks.Add(book);
                }
            }
            ViewBag.CompareBooks = compareIds;
            ViewBag.ChosenBooks = chosenBooks;
            ViewBag.OtherBooks = otherBooks;

            return View(books);
        }

        public IActionResult ToggleCompare(int id)
        {
            string compareList = HttpContext.Request.Cookies["CompareBooks"] ?? "";
            var compareIds = new HashSet<string>(compareList.Split(',', StringSplitOptions.RemoveEmptyEntries));

            if (compareIds.Contains(id.ToString()))
            {
                compareIds.Remove(id.ToString());
            }
            else
            {
                compareIds.Add(id.ToString());
            }

            HttpContext.Response.Cookies.Append("CompareBooks", string.Join(',', compareIds));

            return RedirectToAction("Index");
        }
    }
}
