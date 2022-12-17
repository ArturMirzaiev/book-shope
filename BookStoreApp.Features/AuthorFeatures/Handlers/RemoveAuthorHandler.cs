using BookStoreApp.Data.Entities;
using BookStoreApp.Features.AuthorFeatures.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Handlers
{
    public class RemoveAuthorHandler : IRequestHandler<RemoveAuthorCommand, ActionResult<Author>>
    {
        private readonly IAuthorService _service;

        public RemoveAuthorHandler(IAuthorService service)
        {
            _service = service;
        }

        public async Task<ActionResult<Author>> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _service.RemoveAuthor(request.Id);

            return author;
        }
    }
}
