using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            
            return View();
        }
    }
}