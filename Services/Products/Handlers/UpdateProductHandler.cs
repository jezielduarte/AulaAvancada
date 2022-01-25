using Data.UnityOfWork;
using Domain.Repository;
using MediatR;
using Services.Products.Requests;
using Services.Products.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Product product =  await _repository.GetByIdAsync(request.Id);
            product.SetProduct(request.Description,decimal.Parse(request.Price));
            product.ReleaseUpdate();
            if (product.HasErrors)
            {
                UpdateProductResponse response = new UpdateProductResponse
                {
                    Erros = product.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return response;
            }
            else
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    await _repository.SaveAsync(product);
                    _unitOfWork.Commit();
                    UpdateProductResponse response = new UpdateProductResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    UpdateProductResponse response = new UpdateProductResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return await Task.FromResult(response);
                }
            }
        }
    }
}
