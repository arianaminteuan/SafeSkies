using Microsoft.AspNetCore.Mvc;
using SafeSkies.Models;

namespace SafeSkies.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(BookingFlight booking)
        {
            if (ModelState.IsValid)
            {
                return View("Confirmation",booking);
            }
            return View(booking);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
