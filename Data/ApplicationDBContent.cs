using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class ApplicationDBContent : DbContext
    {
        public DbSet<Good> Good { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;

        public ApplicationDBContent(DbContextOptions<ApplicationDBContent> options) : base(options)
        {
            Database.EnsureCreated();
        }

        
    }
}