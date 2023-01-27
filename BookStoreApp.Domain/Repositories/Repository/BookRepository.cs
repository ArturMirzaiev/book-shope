using BookStoreApp.Data;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Domain.Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> DeleteBook(Guid id)
        {
            Book book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return book;
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .ToListAsync();
        }

        public async Task InsertBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
