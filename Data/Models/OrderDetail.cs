using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid GoodId { get; set; }
        public uint Price { get; set; }
        public virtual Good Good { get; set; } = null!;
        public virtual Order order { get; set; } = null!;
    }
}