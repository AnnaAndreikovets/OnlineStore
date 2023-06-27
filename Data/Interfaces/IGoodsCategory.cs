using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.Interfaces
{
    public interface IGoodsCategory
    {
        IEnumerable<Category> AllCategories {get; }
    }
}