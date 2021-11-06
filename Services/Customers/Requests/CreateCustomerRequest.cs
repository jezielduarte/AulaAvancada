using MediatR;
using Services.Customers.Responses;

namespace Services.Customers.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string PostCod { get; set; }
    }
}
