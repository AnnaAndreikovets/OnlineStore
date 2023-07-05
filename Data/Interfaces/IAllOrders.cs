using OnlineStore.Data.Models;

namespace OnlineStore.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order, Guid goodId);
    }
}