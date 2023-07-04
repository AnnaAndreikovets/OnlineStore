using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Models;
using OnlineStore.Data.Interfaces;

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
            Good? obj = allGoods.GetGood(id);

            return obj is null ? Redirect("/") :  View(obj);
        }
    }
}