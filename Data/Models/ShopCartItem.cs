using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class ShopCartItem
    {
        public Guid Id { get; set; }
        public Good Good { get; set; } = null!;
        public int Price { get; set; }

        public string ShopCartId { get; set; } = null!;
    }
}