using BookStoreApp.Data.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Features.CategoryFeatures.Queries
{
    public class GetCategoriesQuery : IRequest<ActionResult<List<CategoryDTO>>>
    {
    }
}
