using BookStoreApp.Data.Entities;
using BookStoreApp.Features.CategoryFeatures.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Handlers
{
    public class InsertCategoryHandler : IRequestHandler<InsertCategoryCommand, ActionResult<Category>>
    {
        private readonly ICategoryService _service;

        public InsertCategoryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<ActionResult<Category>> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Books = new List<Book>(),
            };

            return await _service.InsertCategory(category);
        }
    }
}
