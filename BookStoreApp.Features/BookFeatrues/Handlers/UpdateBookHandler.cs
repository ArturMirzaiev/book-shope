using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Features.BookFeatrues.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var authors = await _context.Authors
                .Where(a => request.AuthorIds.Contains(a.Id))
                .ToListAsync();

            var categories = await _context.Categories
                .Where(c => request.CategoryIds.Contains(c.Id))
                .ToListAsync();

            var bookContext = await _context.Books.FindAsync(request.Id);

            bookContext.Title = request.Title;
            bookContext.Description = request.Description;
            bookContext.ImageUrl = request.ImageUrl;
            bookContext.Price = request.Price;
            bookContext.Quantity = request.Quantity;
            bookContext.Authors = authors;
            bookContext.Categories = categories;

            await _context.SaveChangesAsync();

            return _mapper.Map<BookDTO>(bookContext);
        }
    }
}
