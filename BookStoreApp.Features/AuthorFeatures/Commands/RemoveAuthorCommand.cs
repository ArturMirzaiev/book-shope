using BookStoreApp.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Commands
{
    public class RemoveAuthorCommand : IRequest<ActionResult<Author>>
    {
        public Guid Id { get; set; }
    }
}
