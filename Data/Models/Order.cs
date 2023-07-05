using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Data.Models
{
    public class Order
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        [Display(Name = "Enter your name")]
        public string Name { get; set; } = null!;
        [BindRequired]
        public string Surname { get; set; } = null!;
        [BindRequired]
        public string Address { get; set; } = null!;
        [BindRequired]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [BindRequired]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}