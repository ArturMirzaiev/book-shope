using BookStoreApp.Data.DTO;
using BookStoreApp.Features.BookFeatrues.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Features.BookFeatrues.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ActionResult<BookDTO>>
    {
        private readonly IBookService _bookService;

        public DeleteBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<ActionResult<BookDTO>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookService.DeleteBook(request.Id);
        }
    }
}
