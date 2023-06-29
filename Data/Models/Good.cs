using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Good
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = null!;
        public ushort Price { get; set; }
        public string LongDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Image { get; set; } = null!;
        public bool IsFavourite { get; set; }
        public bool Availible { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}