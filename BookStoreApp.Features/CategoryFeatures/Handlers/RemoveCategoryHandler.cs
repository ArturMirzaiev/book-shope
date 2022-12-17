using BookStoreApp.Data.Entities;
using BookStoreApp.Features.CategoryFeatures.Commands;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Handlers
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand, ActionResult<Category>>
    {
        private readonly ICategoryService _service;

        public RemoveCategoryHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<ActionResult<Category>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _service.RemoveCategory(request.Id);

            return category;
        }
    }
}
