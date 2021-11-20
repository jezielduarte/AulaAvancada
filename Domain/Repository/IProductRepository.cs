using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        void Save(Product product);
    }
}
