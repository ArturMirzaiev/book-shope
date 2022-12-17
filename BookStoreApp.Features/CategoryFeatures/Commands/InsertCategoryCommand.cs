using BookStoreApp.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Commands
{
    public class InsertCategoryCommand : IRequest<ActionResult<Category>>
    {
        public string Name { get; set; }
    }
}
