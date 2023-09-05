using GoodBooksMvc.DataAccess;
using GoodBooksMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodBooksMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /* Doesn't Work
            int count = 1;
            count++;
            HttpContext.Session.SetString("counter", count.ToString());
            Response.Cookies.Append("counter", count.ToString());
            ViewData["visitCount"] = Request.Cookies["Counter"];
            */
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}