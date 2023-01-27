using BookStoreApp.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.BookFeatrues.Commands
{
    public class UpdateBookCommand : IRequest<ActionResult<BookDTO>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid[] AuthorIds { get; set; }
        public Guid[] CategoryIds { get; set; }
    }
}
