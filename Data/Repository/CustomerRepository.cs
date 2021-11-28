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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextSQLite _context;

        public CustomerRepository(ContextSQLite context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync(Func<Customer, bool> predicate)
        {
            return await Task.FromResult(_context.Customers.Where(predicate).ToList());
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public async Task<List<Customer>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            return _context.Customers.Where(x => x.Name.Contains(name)).Skip(itensPerPage * (page - 1)).Take(itensPerPage).ToList();
        }

        public async Task SaveAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
