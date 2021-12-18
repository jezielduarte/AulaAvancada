using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Exist(string reference)
        {
            return _context.Product.Where(x => x.Reference == reference).Any();
        }

        public async Task SaveAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
