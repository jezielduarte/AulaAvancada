using MediatR;
using Services.Users.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Users.Requests
{
    public class DeleteUserRequest:IRequest<DeleteUserResponse>
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Login { get; set; }

        public string Pass { get; set; }
    }
}
