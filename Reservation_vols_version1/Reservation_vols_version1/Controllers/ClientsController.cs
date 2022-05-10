using Microsoft.AspNetCore.Mvc;
using Reservation_vols;
using Reservation_vols.CRUD;

namespace Reservation_vols_version1.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            ClientDB Clientdb = new ClientDB();
            List<Client> Clients = Clientdb.GetAll();
            ViewData["clients"] = Clients;
            return View();
        }
    }
}
