using BookStoreApp.Data.Entities;

namespace BookStoreApp.Domain.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> RemoveAuthor(Guid id);
        Task<Author> InsertAuthor(Author author);
    }
}
