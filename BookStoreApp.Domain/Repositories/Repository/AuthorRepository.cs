using BookStoreApp.Data;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Domain.Repositories.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors
                .Include(a => a.Books)
                    .ThenInclude(b => b.Categories).ToListAsync();
        }

        public async Task<Author> InsertAuthor(Author author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> RemoveAuthor(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }
    }
}
