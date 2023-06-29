using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using OnlineStore.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data.Repository
{
    public class CategoryRepository : IGoodsCategory
    {
        public ApplicationDBContent DBContent { get; set; } = null!;

        public CategoryRepository(ApplicationDBContent dBContent)
        {
            DBContent = dBContent;
        }

        public IEnumerable<Category> AllCategories => DBContent.Category;
    }
}