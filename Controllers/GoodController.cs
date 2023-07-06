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
            GoodViewModel obj = new GoodViewModel(dBContent) 
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

        [Route("Good/Checkout/{id}")]
        public IActionResult Checkout(Guid id)
        {
            Good good = allGoods.GetGood(id)!;

            return View(good);
        }

        [HttpPost]
        [Route("Good/Checkout2/{id}")]
        [ActionName("Checkout")]
        public IActionResult Checkout2(Guid id)
        {
            Good good = allGoods.GetGood(id)!;

            Order order = new Order()
            {
                Name = Request.Form["Name"]!,
                Surname = Request.Form["Surname"]!,
                Address = Request.Form["Address"]!,
                Email = Request.Form["Email"]!,
                Phone = Request.Form["Phone"]!,
                OrderTime = DateTime.Now,
                //Item = Request.Form["Phone"]!
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