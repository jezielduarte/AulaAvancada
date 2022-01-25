using Data.UnityOfWork;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Users.Requests;
using Services.Users.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUserRepository respository, IUnitOfWork unitOfWork)
        {
            _repository = respository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetByIdAsync(request.Id);
            user.SetLogin(request.Login, request.Pass);
            user.ReleaseUpdate();
            if (user.HasErrors)
            {
                UpdateUserResponse response = new UpdateUserResponse
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
                    UpdateUserResponse response = new UpdateUserResponse
                    {
                        Message = "User saved success",
                        StatusCode = 200
                    };
                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    UpdateUserResponse response = new UpdateUserResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return  await Task.FromResult(response);
                }
            }
        }
    }
}
