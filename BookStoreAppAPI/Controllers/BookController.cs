using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Features.BookFeatrues.Commands;
using BookStoreApp.Features.BookFeatrues.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var query = new GetBooksQuery();
            var response = await _mediator.Send(query);

            return response.Value == null ? NoContent() : Ok(response.Value);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBookById([FromRoute] GetBookByIdQuery request)
        {
            var response = await _mediator.Send(request);

            return response.Value == null ? NotFound() : Ok(response.Value);
        }

        [HttpPost]
        public async Task<ActionResult> InsertBook([FromBody] InsertBookCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult<BookDTO>> UpdateBook([FromBody] UpdateBookCommand command)
        {
            return await _mediator.Send(command);
        }
        
    }

}
