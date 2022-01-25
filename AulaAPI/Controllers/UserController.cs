using AulaAPI.Statcs;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Customers.Requests;
using Services.Users.Requests;
using System;
using System.Threading.Tasks;

namespace AulaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize(Roles = nameof(Domain.Entity.User.CreateCustomer))]
        [Authorize(Roles = nameof(Domain.Entity.User.DeleteCustomer))] //1 e outro
        public async Task<IActionResult> Get([FromQuery] UserRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post(CreateUserRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult GenerateToken(string user, string pass)
        {
            return Ok(
                    new
                    {
                        StatusCode = 200,
                        Token = TokenService.GenerateToken(new User(user, pass, true)),
                        User = user,
                        ExpireDate = DateTime.Now.AddHours(2)
                    }
                );
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
        [HttpPut]
       public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromBody] DeleteUserRequest request) 
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
