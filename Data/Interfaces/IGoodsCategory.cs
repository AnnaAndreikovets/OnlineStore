using OnlineStore.Data.Models;

namespace OnlineStore.Data.Interfaces
{
    public interface IGoodsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}