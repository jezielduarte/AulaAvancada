using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Orders.Responses
{
    public class DeleteOrderResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid OrderId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
