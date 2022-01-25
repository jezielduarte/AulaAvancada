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
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Product product = await _repository.GetByIdAsync(request.Id);
            product.ReleaseRemove();
            if (product.HasErrors)
            {
                DeleteProductResponse response = new DeleteProductResponse
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
                    DeleteProductResponse response = new DeleteProductResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    DeleteProductResponse response = new DeleteProductResponse
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
