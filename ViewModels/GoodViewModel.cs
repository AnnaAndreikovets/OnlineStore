using OnlineStore.Data.Models;
using OnlineStore.Data;

namespace OnlineStore.ViewModels
{
    public class GoodViewModel
    {
        public Good? CurrentGood { get; set; }
        readonly ApplicationDBContent dBContent;

        public GoodViewModel(ApplicationDBContent dBContent )
        {
            this.dBContent = dBContent;
        }

        public object LikeAndDislike()
        {
            CurrentGood.IsFavourite = !CurrentGood.IsFavourite;
            dBContent.SaveChanges();

            return null;
        }
    }
}