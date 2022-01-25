using Domain.Repository;
using MediatR;
using Services.Products.Requests;
using Services.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Product.Handlers
{
    public class ProductHandler : IRequestHandler<ProductRequest, ProductResponse>
    {
        IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entity.Product> product = await _repository.GetByNameAsync(request.Description, request.Page, request.ItensPerPage);

            ProductResponse response = new ProductResponse
            {
                Data = product.Select(x => new ProductResponseItem { Decription = x.Decription, Id = x.Id, Reference = x.Reference, Price = x.Price }).ToList(),
                Page = 1,
                PerPage = 20,
                LastPage = 10
            };
            return response;
        }
    }
}
