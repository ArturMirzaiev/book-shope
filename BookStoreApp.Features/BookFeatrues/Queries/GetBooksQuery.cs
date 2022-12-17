using BookStoreApp.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.BookFeatrues.Queries
{
    public class GetBooksQuery : IRequest<ActionResult<List<BookDTO>>>
    {
    }
}
