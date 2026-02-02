using Microsoft.AspNetCore.Mvc;
using SafeSkies.DataAccess.Repository.IRepository;
using SafeSkies.Models;

namespace SafeSkies.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _flightRepo;

        public FlightsController(IFlightRepository flightRepo)
        {
            _flightRepo = flightRepo;
        }

        public IActionResult Index()
        {
            var flights = _flightRepo.GetAll();

            Console.WriteLine("Number of flights fetched: " + flights.Count); // 🔍 DEBUG LOG

            return View(flights);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(flight.Id))
                {
                    flight.Id = Guid.NewGuid().ToString();
                }

                _flightRepo.Create(flight);
                return RedirectToAction("Index");
            }
            return View(flight);
        }


        // GET: Flights/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var flight = _flightRepo.Get(id);

            if (flight == null)
                return NotFound();

            return View(flight);
        }

        // POST: Flights/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Flight updatedFlight)
        {
            if (id != updatedFlight.Id)
                return BadRequest();


            if (ModelState.IsValid)
            {
                _flightRepo.Update(id, updatedFlight);
                return RedirectToAction("Index");
            }

            return View(updatedFlight);
        }

        // GET: Flights/Delete/{id}
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var flight = _flightRepo.Get(id);
            if (flight == null)
                return NotFound();

            return View(flight);
        }


        // POST: Flights/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _flightRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var flight = _flightRepo.Get(id);

            if (flight == null)
                return NotFound();

            return View(flight);
        }

    }
}
