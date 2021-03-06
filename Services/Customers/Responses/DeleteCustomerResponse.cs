using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customers.Responses
{
    public class DeleteCustomerResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid CustomerId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
