using BookStoreApp.Data.DTO;

namespace BookStoreApp.Services.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDTO> InsertBook(BookDTO bookDTO);  
        Task<BookDTO> DeleteBook(Guid id);  
        Task<List<BookDTO>> GetBooks();  
        Task<BookDTO> GetBookById(Guid id);  
        Task UpdateBook(BookDTO bookDTO);  
    }
}
