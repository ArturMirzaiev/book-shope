using BookStoreApp.Data.DTO;
using BookStoreApp.Features.CategoryFeatures.Queries;
using BookStoreApp.Services.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, ActionResult<List<CategoryDTO>>>
    {
        private readonly ICategoryService _service;

        public GetCategoriesHandler(ICategoryService service)
        {
            _service = service;
        }

        public async Task<ActionResult<List<CategoryDTO>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetCategories();
        }
    }
}
