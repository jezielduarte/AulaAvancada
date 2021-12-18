using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Order
    {
        public Order()
        {
            Errors = new List<BrokenRoles>();
        }
        public Guid Id { get; private set; }

        public DateTime Date { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public IList<OrderItem> OrderItems { get; private set; }

        public void Create(Guid customerId)
        {
            OrderItems = new List<OrderItem>();
            Date = DateTime.Today;
            CustomerId = customerId;
        }

        public void AddItem(Guid productId, int quantity, decimal price)
        {
            OrderItem item = new OrderItem(Id, productId, quantity, price);
            OrderItems.Add(item);
        }

        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            Date = DateTime.Today;

            if (CustomerId == null)
                AddError(nameof(Customer), "can not null");
        }
        public void ReleaseUpdate()
        {
            if (CustomerId == null)
                AddError(nameof(Customer), "can not null");
        }
    }
}
