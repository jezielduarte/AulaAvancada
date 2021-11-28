using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextSQLite _context;

        public ProductRepository(ContextSQLite context)
        {
            _context = context;
        }
        public async Task SaveAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
