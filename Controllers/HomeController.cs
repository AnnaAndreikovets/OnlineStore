using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            
            return View();
        }
    }
}