using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.Mocks
{
    public class MockGoods : IAllGoods
    {
        private readonly IGoodsCategory CategoryGoods = new MockCategory();

        public IEnumerable<Good> AllGoods 
        {
            get
            { 
                return new List<Good>() { new Good() {Category = CategoryGoods.AllCategories.First()} };
            }
        }
        public IEnumerable<Good> AllFavouriteGoods { get{
            return new List<Good>(){};
        } set{} }

        public Good GetGood(int id)
        {
            throw new NotImplementedException();
        }
    }
}