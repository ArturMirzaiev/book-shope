using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;

namespace BookStoreApp.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<Category> RemoveCategory(Guid id);
        Task<Category> InsertCategory(Category category);
    }
}
