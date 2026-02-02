using Microsoft.AspNetCore.Mvc;

namespace SafeSkies.Controllers
{
    public class ContactController : Controller
    {
       
        public IActionResult Contact()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "All fields are required.";
                return View();
            }

            ViewBag.SuccessMessage = "Thank you for contacting us!";
            return View();
        }
    }
}
