using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Interfaces;
using OnlineStore.ViewModels;
using OnlineStore.Data.Models;

namespace OnlineStore.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IAllGoods allGoods = null!;
        private readonly IGoodsCategory goodsCategory = null!;

        public GoodsController(IAllGoods allGoods, IGoodsCategory goodsCategory)
        {
            this.allGoods = allGoods;
            this.goodsCategory = goodsCategory;
        }

        [Route("Goods/List/")]
        public ViewResult List()
        {
            string? request = Request.Form["request"];
            string category = Request.Form["category"]!;

            IEnumerable<Good> _allGoods = category == "All" ? allGoods.AllGoods : allGoods.AllGoods.Where(g => string.Equals(category, g.Category.Name));
            IEnumerable<Good> Search()
            {
                List<Tuple<Good, int>> result = new List<Tuple<Good, int>>();
                string[] keyword = request.Split(new char[] {'-', ' ', '_'}).Where(c => c.Length == 1 ? !Char.IsPunctuation(Char.Parse(c)) : true).Distinct().ToArray();

                foreach(var good in _allGoods)
                {
                    int count = 0;

                    foreach(var key in keyword)
                    {
                        if (good.Name.Contains(key, StringComparison.OrdinalIgnoreCase)) count++;
                    }

                    if(count > 0) 
                    {
                        result.Add(new Tuple<Good, int>(good, count));
                    }
                }
            
                return result.OrderBy(g => g.Item2).Select(g => g.Item1);
            }

            if(!string.IsNullOrEmpty(request))
            {
                _allGoods = Search();
            }

            var obj = new GoodsListViewModel()
            {
                AllGoods = _allGoods,
                CurrentCategory = category
            };
            
            ViewBag.Title = "Goods";

            return View(obj);
        }
    }
}