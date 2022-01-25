using MediatR;
using Services.Users.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Users.Requests
{
     public class UserRequest:IRequest<UserResponse>
    {
        public string Login { get; set; }
        public int Page { get; set; }
        public int ItensPerPage { get; set; }

        public class UserResonse
        {
        }
    }
}
