using AulaAPI.Models;
using AulaAPI.Statcs;
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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromHeader] string token, [FromRoute] Guid id, [FromBody] Cliente cliente)
        {
            if (id == null)
            {
                return NotFound("Cliente nao encontrador !!");
            }
            if (token != Token.Get)
                return Unauthorized("Você nao tem autorização para acessar este recurso");

            cliente.Id = id;

            return Ok(cliente);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromHeader] string token, [FromRoute] Guid id)
        {
            if (token != Token.Get)
                return Unauthorized("Você nao tem autorização para acessar este recurso");

            Cliente cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "UCHOA MURADA SA SILVA"
            };
            return Ok(cliente);
        }
    }
}
