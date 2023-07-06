using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineStore.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindRequired]
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
    }
}