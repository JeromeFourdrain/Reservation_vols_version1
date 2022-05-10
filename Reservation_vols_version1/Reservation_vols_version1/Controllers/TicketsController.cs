using Microsoft.AspNetCore.Mvc;
using Reservation_vols;
using Reservation_vols.CRUD;

namespace Reservation_vols_version1.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            TicketDB Ticketdb = new TicketDB();
            List<Ticket> Tickets = Ticketdb.GetAll();
            ViewData["tickets"] = Tickets;
            return View();
        }
    }
}
