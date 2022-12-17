using BookStoreApp.Data.Entities;

namespace BookStoreApp.Domain.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task InsertBook(Book book); 
        Task DeleteBook(Guid id);  
        Task<IEnumerable<Book>> GetBooks(); 
        Task<Book> GetBookById(Guid id);  
        Task UpdateBook(Book book);
    }
}
