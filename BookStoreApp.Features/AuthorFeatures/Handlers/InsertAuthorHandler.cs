using BookStoreApp.Data.Entities;
using BookStoreApp.Features.AuthorFeatures.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Handlers
{
    public class InsertAuthorHandler : IRequestHandler<InsertAuthorCommand, ActionResult<Author>>
    {
        private readonly IAuthorService _service;

        public InsertAuthorHandler(IAuthorService service)
        {
            _service = service;
        }

        public async Task<ActionResult<Author>> Handle(InsertAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                FullName = request.FullName,
                YearsOfLife = request.YearsOfLife
            };

            return await _service.InsertAuthor(author);
        }
    }
}
