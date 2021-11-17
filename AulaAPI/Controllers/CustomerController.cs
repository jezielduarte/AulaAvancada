using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Customers.Requests;
using System;


namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer))]
        [Authorize(Roles = nameof(Domain.Entity.User.DeleteCustomer))] //1 e outro
        public IActionResult Get([FromQuery] CustomerRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer) + "," + nameof(Domain.Entity.User.CreateCustomer))] // 1 ou outro
        public IActionResult Post([FromBody] CreateCustomerRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
    }
}
