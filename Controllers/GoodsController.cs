using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IAllGoods allGoods = null!;
        private readonly IGoodsCategory goodsCategory = null!;

        public GoodsController(IAllGoods allGoods, IGoodsCategory goodsCategory)
        {
            this.allGoods = allGoods;
            this.goodsCategory = goodsCategory;
        }

        [Route("Goods/List")]
        [Route("Goods/List/{category}")]
        public ViewResult List(string category)
        {
            var obj = new GoodsListViewModel()
            {
                AllGoods = string.IsNullOrEmpty(category) ? allGoods.AllGoods : allGoods.AllGoods.Where(g => string.Equals(category, g.Category.Name, StringComparison.OrdinalIgnoreCase)),
                CurrentCategory = category
            };

            ViewBag.Title = "Goods";

            return View(obj);
        }

    }
}