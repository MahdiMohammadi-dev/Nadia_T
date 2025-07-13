using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NS.Application.Products.Command;
using NS.Application.Products.Queries;

namespace NS.Presentaion.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [AllowAnonymous]
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductQueries());
            return Ok(result);
        }

        [HttpPost]
     
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();

        }

        [HttpDelete("{id}")]
   
        public async Task<IActionResult> Delete(long id)
        {
             await _mediator.Send(new DeleteProductCommand(id));
            return Ok("محصول حذف شد");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("محصول ویرایش شد");
        }
    }
}
