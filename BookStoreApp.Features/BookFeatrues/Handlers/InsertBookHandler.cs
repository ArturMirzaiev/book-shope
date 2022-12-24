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
    public class InsertBookHandler : IRequestHandler<InsertBookCommand, ActionResult<BookDTO>>
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public InsertBookHandler(IBookService service, IMapper mapper, DataContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<BookDTO>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var authors = _context.Authors.Where(a => request.AuthorIds.Contains(a.Id)).ToList();
            var categories = _context.Categories.Where(c => request.CategoryIds.Contains(c.Id)).ToList();

            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                Authors = authors,
                Categories = categories,
                ImageUrl = request.ImageUrl
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return _mapper.Map<BookDTO>(book);
        }
    }
}
