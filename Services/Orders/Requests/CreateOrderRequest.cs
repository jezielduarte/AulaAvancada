using FluentValidation.Results;
using MediatR;
using Services.Customers.Requests;
using Services.Orders.Responses;
using Services.Orders.Validations;
using System.Collections.Generic;

namespace Services.Orders.Requests
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public CreateCustomerRequest Customer { get; set; }
        public List<CreateOrderRequestItem> Items { get; set; }

        public ValidationResult Validate()
        {
            return new CreateOrderValidator().Validate(this);
        }
    }

    public class CreateOrderRequestItem
    {
        public string Referency { get; set; }

        public int Quantity { get; set; }
    }

}
