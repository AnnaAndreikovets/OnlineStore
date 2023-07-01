using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public ViewResult List()
        {
            ViewBag.Title = "Page with goods";
            GoodsListViewModel obj = new GoodsListViewModel();
            obj.AllGoods = allGoods.AllGoods;
            obj.CurrentCategory = "All goods";
            return View(obj);
        }

    }
}