using OnlineStore.Data.Models;

namespace OnlineStore.ViewModels
{
    public class FavouriteGoodsListViewModel
    {
        public IEnumerable<Good> AllFavouriteGoods { get; set; } = null!;
    }
}