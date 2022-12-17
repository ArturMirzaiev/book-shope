using BookStoreApp.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Commands
{
    public class RemoveCategoryCommand : IRequest<ActionResult<Category>>
    {
        public Guid Id { get; set; }
    }
}
