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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            User user = new User(request.Login, request.Pass, request.CreateCustomer, request.UpdateCustomer, request.DeleteCustomer);
            user.ReleaseSave();
            if (user.HasErrors)
            {
                CreateUserResponse response = new CreateUserResponse
                {
                    Erros = user.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return Task.FromResult(response);
            }
            else
            {
                try
                {
                    _repository.SaveAsync(user);
                    CreateUserResponse response = new CreateUserResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    CreateUserResponse response = new CreateUserResponse
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
