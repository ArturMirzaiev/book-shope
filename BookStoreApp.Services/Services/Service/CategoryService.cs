using AutoMapper;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using BookStoreApp.Domain.Repositories.Interfaces;
using BookStoreApp.Services.Services.Interfaces;

namespace BookStoreApp.Services.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            var categories = await _repository.GetCategories();

            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<Category> InsertCategory(Category category)
        {
            return await _repository.InsertCategory(category);
        }

        public async Task<Category> RemoveCategory(Guid id)
        {
            return await _repository.RemoveCategory(id);
        }
    }
}
