using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IOrderRepository
    {
        Task SaveAsync(Order order);

        Task SaveRangeOrderItemAsync(IList<OrderItem> items);

        Task UpdateAsync(Order order);

        Task<Order> GetByIdAsync(Guid id);

        Task<List<Order>> GetAllAsync(Func<Order, bool> predicate);

        Task<List<Order>> GetAllAsync();

        Task<List<Order>> GetByNameAsync(string name, int page, int itensPerPage);

    }
}
