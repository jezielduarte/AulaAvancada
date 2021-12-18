using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Orders.Requests;
using System;


namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
    }
}
