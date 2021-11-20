using System;

namespace Domain.Entity
{
    public class OrderItem
    {
        public OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total => Quantity * Total; 
        public virtual Order Order { get; private set; }
        public virtual Product Product { get; private set; }

    }
}