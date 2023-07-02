using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;

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