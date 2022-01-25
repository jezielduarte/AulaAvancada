using MediatR;
using Services.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Orders.Requests
{
   public class UpdateOrderRequest:IRequest<UpdateOrderResponse>
    {
    }
}
