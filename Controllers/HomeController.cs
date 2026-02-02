using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SafeSkies.Models;
using SafeSkies.Models.ViewModels;

namespace SafeSkies.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Contact");
            }

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
