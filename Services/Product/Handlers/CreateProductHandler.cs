using Data.UnityOfWork;
using Domain.Entity;
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

namespace Services.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product Product = new Product(request.Reference, request.Description, request.Price);
            Product.ReleaseSave();
            if (Product.HasErrors)
            {
                CreateProductResponse response = new CreateProductResponse
                {
                    Erros = Product.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return Task.FromResult(response);
            }
            else
            {
                try
                {
                    _unitOfWork.BeginTransaction();

                    _repository.Save(Product);

                    _unitOfWork.Commit();

                    CreateProductResponse response = new CreateProductResponse
                    {
                        ProductId = Product.Id,
                        Message = "Product saved success",
                        StatusCode = 200
                    };
                    return Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    CreateProductResponse response = new CreateProductResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return Task.FromResult(response);
                }
            }
        }
    }
}
