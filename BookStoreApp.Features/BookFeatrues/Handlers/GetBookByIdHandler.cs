using BookStoreApp.Data.DTO;
using BookStoreApp.Features.BookFeatrues.Queries;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.BookFeatrues.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ActionResult<BookDTO>>
    {
        private readonly IBookService _service;

        public GetBookByIdHandler(IBookService service)
        {
            _service = service;
        }

        public async Task<ActionResult<BookDTO>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetBookById(request.Id);
        }
    }
}
