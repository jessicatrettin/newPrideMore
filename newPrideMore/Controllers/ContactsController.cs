using Microsoft.AspNetCore.Mvc;

namespace newPrideMore.Controllers

{
    public class ContactsController : Controller
    {

        // GET: Contacts
        public IActionResult Index()
        {
            return View();
        }
    }
}
