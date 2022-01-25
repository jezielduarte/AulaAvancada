using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        Task SaveAsync(Product product);
        bool Exist(string reference);

        Task UpdateAsync(Product product);
        Task RemoveAsync(Product product);

        Task<Product> GetByIdAsync(Guid id);

        Task<List<Product>> GetAllAsync(Func<Product, bool> predicate);

        Task<List<Product>> GetAllAsync();

        Task<List<Product>> GetByNameAsync(string name, int page, int itensPerPage);
    }
}
