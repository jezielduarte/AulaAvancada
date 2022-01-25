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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        readonly IOrderRepository _repository;
        private readonly IUnitOfWork _unitOfW;
        public UpdateOrderHandler(IOrderRepository repository, IUnitOfWork unitOfW)
        {
            _repository = repository;
            _unitOfW = unitOfW;
        }


        public Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
