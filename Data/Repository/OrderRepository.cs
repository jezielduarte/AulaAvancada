using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ContextSQLite _context;

        public OrderRepository(ContextSQLite context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync(Func<Order, bool> predicate)
        {
            return _context.Orders.Where(predicate).ToList();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return _context.Orders.ToList();
        }

        public async Task<List<Customer>> GetAllAsync(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return _context.Orders.Find(id);
        }

        public async Task<List<Order>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            return _context.Orders.Where(x => x.Customer.Name.Contains(name)).Skip(itensPerPage * (page - 1)).Take(itensPerPage).ToList();
        }

        public async Task SaveAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task SaveRangeOrderItemAsync(IList<OrderItem> items)
        {
            _context.Entry(items).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
