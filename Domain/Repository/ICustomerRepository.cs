using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);

        void Update(Customer customer);

        Customer GetById(Guid id);

        List<Customer> GetAll(Func<Customer, bool> predicate);

        List<Customer> GetAll();

        List<Customer> GetByName(string name, int page, int itensPerPage);
    }
}
