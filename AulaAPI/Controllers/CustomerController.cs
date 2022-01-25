using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Customers.Requests;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get([FromQuery] CustomerRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }

        [HttpPost]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer) + "," + nameof(Domain.Entity.User.CreateCustomer))] // 1 ou outro
        public IActionResult Post([FromBody] CreateCustomerRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer) + "," + nameof(Domain.Entity.User.CreateCustomer))] // 1 ou outro
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request)
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer) + "," + nameof(Domain.Entity.User.CreateCustomer))] // 1 ou outro
        public  IActionResult Remove([FromRoute] Guid id, [FromBody] DeleteCustomerRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(Task.FromResult(response));
        }

    }
}
