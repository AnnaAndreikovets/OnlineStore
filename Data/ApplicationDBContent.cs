using OnlineStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class ApplicationDBContent : DbContext
    {
        public DbSet<Good> Good { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public ApplicationDBContent(DbContextOptions<ApplicationDBContent> options) : base(options)
        {
        }
        
    }
}