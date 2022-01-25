using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Products.Responses
{
   public class DeleteProductResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid ProductId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
