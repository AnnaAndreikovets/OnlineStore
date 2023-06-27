using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.Interfaces
{
    public interface IAllGoods
    {
        IEnumerable<Good> AllGoods { get; }
        IEnumerable<Good> AllFavouriteGoods { get; set; }
        Good GetGood (int id);
    }
}