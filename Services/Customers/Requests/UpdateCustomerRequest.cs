using MediatR;
using Services.Customers.Responses;
using System;

namespace Services.Customers.Requests
{
    public class UpdateCustomerRequest : IRequest<UpdateCustommerResponse>
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }

        public string City { get; set; }

        public string PostCod { get; set; }
    }
}
