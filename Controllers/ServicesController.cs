using Microsoft.AspNetCore.Mvc;

namespace safeSkies.Controllers
{
    public class ServicesController : Controller
    {
        
        public IActionResult FlightBooking()
        {
            return View();
        }
        public IActionResult LoungeAccess()
        {
            return View();
        }
    }
}
