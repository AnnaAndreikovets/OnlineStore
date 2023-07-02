using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using OnlineStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGoods allGoods;

        public HomeController(IAllGoods allGoods)
        {
            this.allGoods = allGoods;
        }

        public IActionResult Index()
        {
            var homeGoods = new HomeViewModel() { AllFavouriteGoods = allGoods.AllFavouriteGoods};

            return View(homeGoods);
        }
    }
}