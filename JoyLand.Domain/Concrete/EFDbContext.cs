using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JoyLand.Domain.Entities;

namespace JoyLand.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ShoppingDetails> ShoppingDetails { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
