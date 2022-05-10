using Microsoft.AspNetCore.Mvc;
using Reservation_vols;
using Reservation_vols.CRUD;

namespace Reservation_vols_version1.Controllers
{
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            FlightDB Flightdb = new FlightDB();
            List<Flight> Flights = Flightdb.GetAll();
            ViewData["flights"] = Flights;
            return View();
        }
    }
}
