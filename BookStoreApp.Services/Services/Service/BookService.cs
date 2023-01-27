using AutoMapper;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using BookStoreApp.Services.Services.Interfaces;

namespace BookStoreApp.Services.Services.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDTO> DeleteBook(Guid id)
        {
            var book = await _repository.DeleteBook(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> GetBookById(Guid id)
        {
            var book = await _repository.GetBookById(id);

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var books = await _repository.GetBooks();

            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> InsertBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            await _repository.InsertBook(book);

            return bookDTO;
        }

        public async Task UpdateBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            await _repository.UpdateBook(book);
        }
    }
}
