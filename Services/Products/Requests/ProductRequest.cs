using MediatR;
using Services.Products.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Products.Requests
{
    public class ProductRequest:IRequest<ProductResponse>
    {
        public string Description { get; set; }
        public int Page { get; set; }
        public int ItensPerPage { get; set; }
    }
}
