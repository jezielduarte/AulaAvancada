using MediatR;
using Services.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customers.Requests
{
   public class DeleteCustomerRequest :IRequest<DeleteCustomerResponse>
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
