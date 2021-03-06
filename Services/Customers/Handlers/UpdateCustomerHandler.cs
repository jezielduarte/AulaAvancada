using Data.UnityOfWork;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Customers.Requests;
using Services.Customers.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Customers.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustommerResponse>
    {
        readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandler(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustommerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer = await _repository.GetByIdAsync(request.Id);
            customer.SetAderess(request.City, request.PostCod);
            customer.SetName(request.Name);
            customer.ReleaseUpdate();
            if (customer.HasErrors)
            {
                UpdateCustommerResponse response = new UpdateCustommerResponse
                {
                    Erros = customer.Errors,
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
                    await _repository.SaveAsync(customer);
                    _unitOfWork.Commit();
                    UpdateCustommerResponse response = new UpdateCustommerResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    UpdateCustommerResponse response = new UpdateCustommerResponse
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
