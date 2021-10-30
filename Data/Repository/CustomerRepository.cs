using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextSQLite _context;

        public CustomerRepository(ContextSQLite context)
        {
            _context = context;
        }

        public List<Customer> GetAll(Func<Customer, bool> predicate)
        {
            return _context.Customers.Where(predicate).ToList();
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public List<Customer> GetByName(string name, int page, int itensPerPage)
        {
            return _context.Customers.Where(x => x.Name.Contains(name)).Skip(itensPerPage * (page - 1)).Take(itensPerPage).ToList();
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
