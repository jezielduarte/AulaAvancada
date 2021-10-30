using Services.Customer.Requests;
using Services.Customer.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customer.Handlers
{
    public interface ICustomerHandler
    {
        CustomerResponse Handler(CustomerRequest request);
    }
}
