using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customer.Requests
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int ItensPerPage { get; set; }
    }
}
