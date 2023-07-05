using System.Linq;
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
        public void CreateOrder(Order order, Guid goodId)
        {
            order.OrderTime = DateTime.Now;
            dbContent.Order.Add(order);

            Good good = allGoods.GetGood(goodId);

            OrderDetail orderDetail = new OrderDetail()
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                GoodId = good.Id,
                Price = good.Price
            };

            dbContent.OrderDetail.Add(orderDetail);

            dbContent.SaveChanges();
        }
    }
}