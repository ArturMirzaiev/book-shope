using BookStoreApp.Data.DTO;
using BookStoreApp.Features.AuthorFeatures.Queries;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Handlers
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, ActionResult<List<AuthorDTO>>>
    {
        private readonly IAuthorService _service;

        public GetAuthorsHandler(IAuthorService service)
        {
            _service = service;
        }

        public async Task<ActionResult<List<AuthorDTO>>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAuthors();
        }
    }
}
