using Domain.Repository;
using MediatR;
using Services.Customers.Requests;
using Services.Customers.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Customers.Handlers
{
    public class CustomerHandler : IRequestHandler<CustomerRequest, CustomerResponse>
    {
        ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerResponse> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entity.Customer> customers = await _repository.GetByNameAsync(request.Name, request.Page, request.ItensPerPage);

            CustomerResponse response = new CustomerResponse
            {
                Data = customers.Select(x => new CustomerResponseItem { City = x.City, Id = x.Id, Name = x.Name, PostCod = x.PostCod }).ToList(),
                Page = 1,
                PerPage = 20,
                LastPage = 10
            };
            return response;
        }
    }
}
