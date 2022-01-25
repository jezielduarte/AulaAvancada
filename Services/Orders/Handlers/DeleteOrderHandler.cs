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
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        readonly IOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderHandler(IOrderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
