using BookStoreApp.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.AuthorFeatures.Commands
{
    public class InsertAuthorCommand : IRequest<ActionResult<Author>>
    {
        public string FullName { get; set; }
        public string YearsOfLife { get; set; }
    }
}
