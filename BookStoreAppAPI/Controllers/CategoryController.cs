using BookStoreApp.Data.DTO;
using BookStoreApp.Features.CategoryFeatures.Commands;
using BookStoreApp.Features.CategoryFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            var query = new GetCategoriesQuery();
            var response = await _mediator.Send(query);

            return response.Value == null ? NotFound() : Ok(response.Value);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> RemoveCategory([FromRoute] RemoveCategoryCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCategory([FromBody] InsertCategoryCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
