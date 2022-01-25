using MediatR;
using Services.Products.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Products.Requests
{
   public class DeleteProductRequest:IRequest<DeleteProductResponse>
    {

        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Reference { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }
    }
}
