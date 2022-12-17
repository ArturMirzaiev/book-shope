using BookStoreApp.Data.DTO;
using BookStoreApp.Features.AuthorFeatures.Commands;
using BookStoreApp.Features.AuthorFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var query = new GetAuthorsQuery();
            var response = await _mediator.Send(query);

            return response.Value == null ? NotFound() : Ok(response.Value);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> RemoveAuthor([FromRoute] RemoveAuthorCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveAuthor([FromBody] InsertAuthorCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
