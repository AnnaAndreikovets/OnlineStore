using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Repository;
using OnlineStore.Data.Models;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{
    public class ShopCartController : Controller
    {
        readonly IAllGoods goodRepository;
        readonly ShopCart shopCart;

        public ShopCartController(IAllGoods goodRepository, ShopCart shopCart)
        {
            this.goodRepository = goodRepository;
            this.shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = shopCart.GetShopCartItems();
            shopCart.ListShopItems = items;

            ShopCartViewModel obj = new ShopCartViewModel()
            {
                ShopCart = shopCart
            };

            return View(obj);
        }

         public RedirectToActionResult AddToCart(Guid id)
         {
            Good item = goodRepository.GetGood(id);

            if(item != null)
            {
                shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
         }
    }
}