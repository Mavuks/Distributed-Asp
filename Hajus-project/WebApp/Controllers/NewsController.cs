using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class News : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}