using AulaAPI.Models;
using AulaAPI.Querys;
using AulaAPI.Statcs;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Customer.Handlers;
using Services.Customer.Requests;
using System;


namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerHandler _handler;

        public CustomerController(ICustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromHeader] string token, [FromQuery] CustomerRequest request)
        {
            if (token != Token.Get)
                return Unauthorized("Você nao tem autorização para acessar este recurso");
            var response = _handler.Handler(request);
            return Ok(response);
        }


        [HttpPost]
        public IActionResult Post([FromHeader] string token, [FromBody] Customer customer)
        {
            return Ok(customer);
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
