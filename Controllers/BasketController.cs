using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{
    public class BasketController : Controller
    {
        readonly IAllGoods allGoods;
        public BasketController(IAllGoods allGoods)
        {
            this.allGoods = allGoods;
        }

        [Route("Basket/")]
        [Route("Basket/Index")]
        public IActionResult Index()
        {
            FavouriteGoodsListViewModel obj = new FavouriteGoodsListViewModel()
            {
                AllFavouriteGoods = allGoods.AllFavouriteGoods
            };

            ViewBag.Title = "Basket";

            return View(obj);
        }
    }
}