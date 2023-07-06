using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        readonly ApplicationDBContent dbContent;
        readonly IAllGoods allGoods;

        public OrdersRepository(ApplicationDBContent dBContent, IAllGoods allGoods)
        {
            this.dbContent = dBContent;
            this.allGoods = allGoods;
        }
        public void CreateOrder(Order order)
        {   
            dbContent.Order.Add(order);

            dbContent.SaveChanges();
        }
    }
}