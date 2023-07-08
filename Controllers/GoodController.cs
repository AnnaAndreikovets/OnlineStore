using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;
using OnlineStore.Data.Models;
using OnlineStore.Data;

namespace OnlineStore.Controllers
{
    public class GoodController : Controller
    {
        readonly IAllGoods allGoods;
        readonly ApplicationDBContent dBContent;
        readonly IAllOrders allOrders;

        public GoodController(IAllGoods allGoods, ApplicationDBContent dBContent, IAllOrders allOrders)
        {
            this.allGoods = allGoods;
            this.dBContent = dBContent;
            this.allOrders = allOrders;
        }

        [Route("Good/Index/{id}")]
        public IActionResult Index(Guid id)
        {
            GoodViewModel obj = new GoodViewModel()
            {
                CurrentGood = allGoods.GetGood(id)
            };

            if(obj.CurrentGood is not null)
            {
                ViewData["favourite"] = obj.CurrentGood.IsFavourite ? "Dislike" : "Like";

                return View(obj);
            }

            return Redirect("/");
        }

        [HttpPost]
        public ActionResult LikeAndDislike()
        {
            Guid? id = Guid.Parse(Request?.Form["id"]!);
            Good? good = dBContent.Good.Find(id);

            if(good is not null)
            {
                good.IsFavourite = !good.IsFavourite;
                dBContent.SaveChanges();

                return Content("success");
            }
            else
            {
                return Content("failed");
            }
        }

        [Route("Good/Checkout/{id}")]
        public IActionResult Checkout(Guid id)
        {
            //Good good = allGoods.GetGood(id)!;
            return View();
        }

        [HttpPost]
        [Route("Good/Checkout2")]
        [ActionName("Checkout")]
        public IActionResult Checkout2()
        {
            Order order = new Order()
            {
                Name = Request.Form["Name"]!,
                Surname = Request.Form["Surname"]!,
                Address = Request.Form["Address"]!,
                Email = Request.Form["Email"]!,
                Phone = Request.Form["Phone"]!,
                OrderTime = DateTime.Now
            };

            allOrders.CreateOrder(order);

            return RedirectToAction("Complete");
        }

        [Route("Good/Complete")]
        public IActionResult Complete()
        {
            ViewData["Message"] = "Order successfully processed";

            return View();
        }
    }
}