using Data.UnityOfWork;
using Domain.Repository;
using MediatR;
using Services.Orders.Requests;
using Services.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Orders.Handlers
{
    public class OrderHandler : IRequestHandler<OrderRequest, OrderResponse>
    {
        readonly IOrderRepository _repository;
       
        public OrderHandler(IOrderRepository repository, IUnitOfWork unitOfW)
        {
            _repository = repository;
           
        }


        public Task<OrderResponse> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
