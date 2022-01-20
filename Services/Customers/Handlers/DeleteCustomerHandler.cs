using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Customers.Requests;
using Services.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Customers.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        readonly ICustomerRepository _repository;

        public DeleteCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer = await _repository.GetByIdAsync(request.Id);
           
            //customer.SetAderess(request.City, request.PostCod);
            //customer.SetName(request.Name);
            customer.ReleaseRemove();
            if (customer.HasErrors)
            {
                DeleteCustomerResponse response = new DeleteCustomerResponse
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
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                    });

                    await Task.Run(() =>
                    {
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                        _repository.RemoveAsync(customer);
                    });

                    DeleteCustomerResponse response = new DeleteCustomerResponse
                    {
                        Message = "Customer saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    DeleteCustomerResponse response = new DeleteCustomerResponse
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

