using BookStoreApp.Data.Entities;

namespace BookStoreApp.Domain.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> RemoveCategory(Guid id);
        Task<Category> InsertCategory(Category category);
    }
}
