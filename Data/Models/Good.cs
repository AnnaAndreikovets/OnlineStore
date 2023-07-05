using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineStore.Data.Models
{
    public class Good
    {
        [BindRequired]
        public Guid Id { get; set; } 
        [BindRequired]
        public string Name { get; set; } = null!;
        [BindRequired]
        public ushort Price { get; set; }
        [BindRequired]
        public string LongDescription { get; set; } = null!;
        [BindRequired]
        public string ShortDescription { get; set; } = null!;
        [BindRequired]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; } = null!;
        [BindRequired]
        public bool IsFavourite { get; set; }
        [BindRequired]
        public bool Availible { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}