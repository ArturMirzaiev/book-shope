using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Features.BookFeatrues.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.BookFeatrues.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ActionResult<BookDTO>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UpdateBookHandler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<BookDTO>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var authors = _context.Authors.Where(a => request.AuthorIds.Contains(a.Id)).ToList();
            var categories = _context.Categories.Where(c => request.CategoryIds.Contains(c.Id)).ToList();

            var book = new Book

            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                Authors = authors,
                Categories = categories
            };

            var dbBook = _context.Books.FirstOrDefault(s => s.Id == book.Id);

            _context.Entry(dbBook).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return _mapper.Map<BookDTO>(book);
        }
    }
}
