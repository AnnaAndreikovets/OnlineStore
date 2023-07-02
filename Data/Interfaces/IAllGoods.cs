using OnlineStore.Data.Models;

namespace OnlineStore.Data.Interfaces
{
    public interface IAllGoods
    {
        IEnumerable<Good> AllGoods { get; }
        IEnumerable<Good> AllFavouriteGoods { get; }
        Good GetGood (Guid id);
    }
}