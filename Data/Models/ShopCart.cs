using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class ShopCart
    {
        readonly ApplicationDBContent ApplicationDBContent;

        public ShopCart(ApplicationDBContent content)
        {
            ApplicationDBContent = content;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<HttpContextAccessor>()?.HttpContext.Session;
            var content = service.GetRequiredService<ApplicationDBContent>();

            if(string.IsNullOrEmpty(session.GetString("CartId")))
            {
                session.SetString("CartId", Guid.NewGuid().ToString());
            }

            return new ShopCart(content){ ShopCartId = session.GetString("CartId")};
        }

        public void AddtToCart(Good good, int amount)
        {
            ApplicationDBContent.ShopCartItem.Add(
                new ShopCartItem()
                {
                    Id = Guid.NewGuid(),
                    Good = good,
                    Price = good.Price,
                    ShopCartId = ShopCartId
                });
        }
    }
}