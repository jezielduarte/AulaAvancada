using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextSQLite _context;

        public ProductRepository(ContextSQLite context)
        {
            _context = context;
        }
        public void Save(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }
    }
}
