using MediatR;
using Services.Orders.Responses;
using System.Collections.Generic;

namespace Services.Orders.Requests
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public CreateOrderRequestCustomer CreateOrderRequestCustomer { get; set; }
        public List<CreateOrderRequestItem> Items { get; set; }
    }

    public class CreateOrderRequestItem
    {
        public string Referency { get; set; }

        public int Quantity { get; set; }
    }

    public class CreateOrderRequestCustomer
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string PostCod { get; set; }
    }
}
