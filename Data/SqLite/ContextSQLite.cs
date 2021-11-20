using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.SqLite
{
    public class ContextSQLite : DbContext
    {
        public ContextSQLite(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
