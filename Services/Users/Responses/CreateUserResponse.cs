using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Customers.Responses
{
    public class CreateUserResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
