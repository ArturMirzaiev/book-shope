using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;

namespace BookStoreApp.Services.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAuthors();
        Task<Author> RemoveAuthor(Guid id);
        Task<Author> InsertAuthor(Author author);
    }
}
