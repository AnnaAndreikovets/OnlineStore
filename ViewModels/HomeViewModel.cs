using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Good> AllFavouriteGoods { get; set; }
    }
}