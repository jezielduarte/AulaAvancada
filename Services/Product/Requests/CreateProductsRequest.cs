using MediatR;
using Services.Customers.Responses;
using Services.Products.Responses;

namespace Services.Products.Requests
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Reference { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
