using BookStoreApp.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Features.BookFeatrues.Commands
{
    public class DeleteBookCommand : IRequest<ActionResult<BookDTO>>
    {
        public Guid Id { get; set; }
    }
}
