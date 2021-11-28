using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        Task SaveAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task<Customer> GetByIdAsync(Guid id);

        Task<List<Customer>> GetAllAsync(Func<Customer, bool> predicate);

        Task<List<Customer>> GetAllAsync();

        Task<List<Customer>> GetByNameAsync(string name, int page, int itensPerPage);
    }
}
