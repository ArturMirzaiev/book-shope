using AutoMapper;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using BookStoreApp.Services.Services.Interfaces;

namespace BookStoreApp.Services.Services.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDTO>> GetAuthors()
        {
            var authors = await _repository.GetAuthors();

            return _mapper.Map<List<AuthorDTO>>(authors);
        }

        public async Task<Author> InsertAuthor(Author author)
        {
            return await _repository.InsertAuthor(author);
        }

        public async Task<Author> RemoveAuthor(Guid id)
        {
            return await _repository.RemoveAuthor(id);
        }
    }
}
