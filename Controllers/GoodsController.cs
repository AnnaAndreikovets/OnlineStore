using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;

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
            var good = AllGoods.AllGoods;
            return View(AllGoods.AllGoods);
        }

    }
}