using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SqLite
{
    public class ContextSQLite : DbContext
    {
        public ContextSQLite(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
