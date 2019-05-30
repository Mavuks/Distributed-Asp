using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class Puppies : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}