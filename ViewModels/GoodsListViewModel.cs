using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Models;

namespace OnlineStore.ViewModels
{
    public class GoodsListViewModel
    {
        public IEnumerable<Good> AllGoods { get; set; } = null!;
        public string CurrentCategory { get; set; } = null!;
    }
}