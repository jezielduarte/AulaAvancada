using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Customers.Requests;
using Services.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Customers.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer(request.Name, request.City, request.PostCod);
            customer.ReleaseSave();
            if (customer.HasErrors)
            {
                CreateCustomerResponse response = new CreateCustomerResponse
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
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                    });

                    await Task.Run(() =>
                    {
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                        _repository.SaveAsync(customer);
                    });

                    CreateCustomerResponse response = new CreateCustomerResponse
                    {
                        Message = "Customer saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    CreateCustomerResponse response = new CreateCustomerResponse
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
