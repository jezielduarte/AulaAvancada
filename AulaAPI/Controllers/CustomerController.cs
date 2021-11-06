using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Customers.Requests;
using System;


namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CustomerRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
    }
}
