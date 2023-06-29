using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.Mocks
{
    public class MockCategory : IGoodsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>()
                {
                    new Category() { Id = Guid.NewGuid(), Name = "Toys"},
                    new Category() { Id = Guid.NewGuid(), Name = "Clothes"},
                    new Category() { Id = Guid.NewGuid(), Name = "Bags"},
                    new Category() { Id = Guid.NewGuid(), Name = "Kitchen utensils"}
                };
            }
        }
    }
}