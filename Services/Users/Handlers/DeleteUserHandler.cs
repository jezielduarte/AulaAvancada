using Data.UnityOfWork;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Users.Requests;
using Services.Users.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetByIdAsync(request.Id);
            user.ReleaseRemove ();

            if (user.HasErrors)
            {
                DeleteUserResponse response = new DeleteUserResponse
                {
                    Erros = user.Errors,
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
                    await _repository.SaveAsync(user);
                    _unitOfWork.Commit();
                    DeleteUserResponse response = new DeleteUserResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    DeleteUserResponse response = new DeleteUserResponse
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
