using BookStoreApp.Data;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Domain.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> InsertCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> RemoveCategory(Guid id)
        {
            Category category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
