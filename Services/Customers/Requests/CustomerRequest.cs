using MediatR;
using Services.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customers.Requests
{
    public class CustomerRequest : IRequest<CustomerResponse>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int ItensPerPage { get; set; }
    }
}
