using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_vols;
using Reservation_vols.CRUD;

namespace Reservation_vols_version1.Controllers
{
    public class AirportsController : Controller
    {


        // GET: Airports
        public IActionResult Index()
        {
            AirportDB airportdb = new AirportDB();
            List<Airport> airports = airportdb.GetAll();
            ViewData["airports"] = airports;
            return View();
        }

        // GET; airports/Create
        public IActionResult Create()
        {
            Airport airport = new Airport();
            
            return View(airport);
        }

        // POST: Airports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Address")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AirportDB dbAirport = new AirportDB();
                    dbAirport.Insert(airport);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Aéroport avec la même addresse ou le même nom déja existant !");
                    return View(airport);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(airport);
        }

        // GET; airports/Edit/5
        public IActionResult Edit(int? id)
        {
            Airport airport = null;
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                AirportDB airportdb = new AirportDB();
                try
                {
                    airport = airportdb.GetById(id ?? 1);
                }
                catch (Exception ex)
                {
                    return NotFound();
                } 
            }
            
            return View(airport);
        }

        // POST: Airports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AirportId,Name,Address")] Airport airport)
        {
            if (id != airport.AirportId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    AirportDB dbAirport = new AirportDB();
                    dbAirport.Update(airport);
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(airport);
        }

        public IActionResult Delete(int? id)
        {
            Airport airport = null;

            if(id == null)
            {
                return NotFound();
            }
            else
            {
                AirportDB airportDb = new AirportDB();
                try
                {
                    airport=airportDb.GetById(id ?? 1);
                }
                catch(Exception ex)
                {
                    return NotFound();
                }
            }

            ViewData["airport"] = airport;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AirportDB airportDb = new AirportDB();
            try
            {
                airportDb.Delete(id);
            }
            catch(Exception ex)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
