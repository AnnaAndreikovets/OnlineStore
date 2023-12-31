using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data.Repository
{
    public class GoodRepository : IAllGoods
    {
        public ApplicationDBContent DBContent { get; set; } = null!;

        public GoodRepository(ApplicationDBContent dBContent)
        {
            DBContent = dBContent;
        }

        public IEnumerable<Good> AllGoods => DBContent.Good.Include(c => c.Category);

        public IEnumerable<Good> AllFavouriteGoods => DBContent.Good.Where(g => g.IsFavourite).Include(c => c.Category);

        public Good? GetGood(Guid id) => DBContent.Good.FirstOrDefault(g => g.Id.CompareTo(id) == 0);

    }
}