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
        private readonly IAllGoods AllGoods = null!;
        private readonly IGoodsCategory GoodsCategory = null!;

        public GoodsController(IAllGoods allGoods, IGoodsCategory goodsCategory)
        {
            AllGoods = allGoods;
            GoodsCategory = goodsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Page with goods";
            GoodsListViewModel obj = new GoodsListViewModel();
            obj.AllGoods = AllGoods.AllGoods;
            obj.CurrentCategory = "All goods";
            return View(obj);
        }

    }
}