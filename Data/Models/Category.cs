using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineStore.Data.Models
{
    public class Category
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public string Name { get; set; } = null!;

        public List<Good>? Goods { get; set; }
    }
}