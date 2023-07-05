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

        public GoodController(IAllGoods allGoods, ApplicationDBContent dBContent)
        {
            this.allGoods = allGoods;
            this.dBContent = dBContent;
        }

        [Route("Good/Index/{id}")]
        public IActionResult Index(Guid id)
        {
            GoodViewModel obj = new GoodViewModel(dBContent) 
            {
                CurrentGood = allGoods.GetGood(id)
            };

            ViewData["favourite"] = obj.CurrentGood.IsFavourite ? "Dislike" : "Like";

            return obj.CurrentGood is null ? Redirect("/") :  View(obj);
        }

        [Route("Good/Checkout/{id}")]
        public IActionResult Checkout(Guid id)
        {
            Good good = allGoods.GetGood(id);
            return View(good);
        }
    }
}