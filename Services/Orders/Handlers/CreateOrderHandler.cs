using Data.UnityOfWork;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using Services.Orders.Requests;
using Services.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        readonly IOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(IOrderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = new Order();
            order.ReleaseSave();
            if (order.HasErrors)
            {
                CreateOrderResponse response = new CreateOrderResponse
                {
                    Erros = order.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return Task.FromResult(response);
            }
            else
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    _repository.SaveAsync(order);
                    _unitOfWork.Commit();
                    CreateOrderResponse response = new CreateOrderResponse
                    {
                        Message = "Order saved success",
                        StatusCode = 200
                    };
                    return Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    CreateOrderResponse response = new CreateOrderResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return Task.FromResult(response);
                }
            }
        }
    }
}
