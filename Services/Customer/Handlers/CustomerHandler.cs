using Domain.Repository;
using Services.Customer.Requests;
using Services.Customer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Customer.Handlers
{
    public class CustomerHandler : ICustomerHandler
    {
        ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerResponse Handler(CustomerRequest request)
        {
            List<Domain.Entity.Customer> customers = _repository.GetByName(request.Name, request.Page, request.ItensPerPage);
            return new CustomerResponse
            {
                Data = customers.Select(x => new CustomerResponseItem { City = x.City, Id = x.Id, Name = x.Name, PostCod = x.PostCod }).ToList(),
                Page = 1,
                PerPage = 20,
                LastPage = 10
            };
        }
    }
}
