using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customer.Responses
{
    public class CustomerResponseItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string PostCod { get; set; }

    }

    public class CustomerResponse
    {
        public List<CustomerResponseItem> Data { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public int LastPage { get; set; }
    }
}
