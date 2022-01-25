using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Users.Requests;
using Services.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Handlers
{
    public class UserHandler : IRequestHandler<UserRequest, UserResponse>
    {
        IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            List<User> user = await _repository.GetByNameAsync(request.Login, request.Page, request.ItensPerPage);

            UserResponse response = new UserResponse
            {
                Data = user.Select(x => new UserResponseItem { Login = x.Login, Id = x.Id, Pass = x.Pass }).ToList(),
                Page = 1,
                PerPage = 20,
                LastPage = 10
            };

            return response;

        }
    }
}
