using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Data.Models
{
    public class ShopCart
    {
        readonly ApplicationDBContent applicationDBContent;

        public ShopCart(ApplicationDBContent content)
        {
            applicationDBContent = content;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var content = service.GetRequiredService<ApplicationDBContent>();

            if(string.IsNullOrEmpty(session.GetString("CartId")))
            {
                session.SetString("CartId", Guid.NewGuid().ToString());
            }

            return new ShopCart(content){ ShopCartId = session.GetString("CartId")};
        }

        public void AddToCart(Good good)
        {
            applicationDBContent.ShopCartItem.Add(
                new ShopCartItem()
                {
                    Id = Guid.NewGuid(),
                    Good = good,
                    Price = good.Price,
                    ShopCartId = ShopCartId
                });

            applicationDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return applicationDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Good).ToList();
        }
    }
}