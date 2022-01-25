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

        public async Task<List<Product>> GetAllAsync(Func<Product, bool> predicate)
        {
            return await Task.FromResult(_context.Product.Where(predicate).ToList());
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Task.FromResult(_context.Product.ToList());
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_context.Product.Find(id));
        }

        public async Task<List<Product>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            return await Task.FromResult(_context.Product.Where(x => x.Decription.Contains(name)).Skip(itensPerPage * (page - 1)).Take(itensPerPage).ToList());
        }
        public async Task SaveAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
