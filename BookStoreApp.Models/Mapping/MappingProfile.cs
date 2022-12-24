using AutoMapper;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;

namespace BookStoreApp.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Author, AuthorDTO>().ReverseMap();

            CreateMap<Book, BookShortDTO>().ReverseMap();
        }
    }
}
