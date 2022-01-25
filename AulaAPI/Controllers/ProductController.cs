using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Products.Requests;
using System;
using System.Threading.Tasks;

namespace AulaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
       
        public IActionResult Remove([FromRoute] Guid id, [FromBody] DeleteProductRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(Task.FromResult(response));
        }
    }
}
