using BookStoreApp.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Queries
{
    public class GetAuthorsQuery : IRequest<ActionResult<List<AuthorDTO>>>
    {
    }
}
