using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Good>? Goods { get; set; }
    }
}