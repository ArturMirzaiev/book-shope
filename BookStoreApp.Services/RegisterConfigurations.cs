using BookStoreApp.Domain.Repositories.Interfaces;
using BookStoreApp.Domain.Repositories.Repository;
using BookStoreApp.Services.Services.Interfaces;
using BookStoreApp.Services.Services.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApp.Services
{
    public class RegisterConfigurations
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
