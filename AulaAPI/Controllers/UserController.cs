using AulaAPI.Statcs;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Customers.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return Ok(TokenService.GenerateToken(new User(user,pass)));
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
