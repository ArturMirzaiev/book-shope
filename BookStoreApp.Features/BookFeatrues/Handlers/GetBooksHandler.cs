using BookStoreApp.Data.DTO;
using BookStoreApp.Features.BookFeatrues.Queries;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.BookFeatrues.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, ActionResult<List<BookDTO>>>
    {
        private readonly IBookService _service;

        public GetBooksHandler(IBookService service)
        {
            _service = service;
        }

        public async Task<ActionResult<List<BookDTO>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetBooks();
        }
    }
}
