using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;
using OnlineStore.Data.Models;

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

            ViewBag.Title = "Page with goods";
            /*GoodsListViewModel obj = new GoodsListViewModel();
            obj.AllGoods = allGoods.AllGoods;
            obj.CurrentCategory = "All goods";
            return View(obj);*/

            return View(obj);
        }

    }
}