using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }

        public DateTime Date { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public IList<OrderItem> OrderItems { get; private set; }

        public void Create(Guid customerId)
        {
            OrderItems = new List<OrderItem>();
            Date = DateTime.Today;
        }

        public void AddItem(Guid productId, int quantity, decimal price)
        {
            OrderItem item = new OrderItem(Id, productId, quantity, price);
            OrderItems.Add(item);
        }

    }
}
