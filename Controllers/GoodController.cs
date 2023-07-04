using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{
    public class GoodController : Controller
    {
        readonly IAllGoods allGoods;

        public GoodController(IAllGoods allGoods)
        {
            this.allGoods = allGoods;
        }

        [Route("Good/Index/{id}")]
        public IActionResult Index(Guid id)
        {
            GoodListViewModel obj = new GoodListViewModel() 
            {
                CurrentGood = allGoods.GetGood(id)
            };

            return obj.CurrentGood is null ? Redirect("/") :  View(obj);
        }
    }
}