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

        public UpdateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
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
                    await Task.Run(() =>
                    {
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                    });

                    await Task.Run(() =>
                    {
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                        _repository.UpdateAsync(customer);
                    });

                    UpdateCustommerResponse response = new UpdateCustommerResponse
                    {
                        Message = "Customer saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    UpdateCustommerResponse response = new UpdateCustommerResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return response;
                }
            }
        } 
        
    }
}
