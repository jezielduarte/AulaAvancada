using AulaAPI.Models;
using AulaAPI.Querys;
using AulaAPI.Statcs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromHeader] string token)
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] Guid id, [FromQuery] ClienteQuery query, [FromHeader] string token)
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

        [HttpPost]
        public IActionResult Post([FromHeader] string token, [FromBody] Cliente cliente)
        {
            return Ok();
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
