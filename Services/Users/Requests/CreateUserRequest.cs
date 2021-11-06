using MediatR;
using Services.Customers.Responses;

namespace Services.Customers.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Login { get; set; }

        public string Pass { get; set; }

        public bool CreateCustomer { get; set; }

        public bool UpdateCustomer { get; set; }

        public bool DeleteCustomer { get; set; }
    }
}
