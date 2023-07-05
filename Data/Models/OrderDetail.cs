using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineStore.Data.Models
{
    public class OrderDetail
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Guid OrderId { get; set; }
        [BindRequired]
        public Guid GoodId { get; set; }
        [BindRequired]
        public uint Price { get; set; }
        public virtual Good Good { get; set; } = null!;
        public virtual Order order { get; set; } = null!;
    }
}