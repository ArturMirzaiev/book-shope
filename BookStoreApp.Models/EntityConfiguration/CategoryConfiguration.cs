using BookStoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApp.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(k => k.Books)
                .WithMany(k => k.Categories);

            builder.HasData(
                new Category
                {
                    Id = new Guid("a41c1b1b-e67e-4d7b-a6d5-14e3eae1366d"),
                    Name = "Autobiography"
                },

                new Category
                {
                    Id = new Guid("defaf2ca-511a-4a23-8b01-480fbd8a68ee"),
                    Name = "Poetry"
                },

                new Category
                {
                    Id = new Guid("b7fed066-9ded-4be5-9801-95eed87fc048"),
                    Name = "Adventure"
                },

                new Category
                {
                    Id = new Guid("f7b4126d-9149-40cb-867f-f464163ffe26"),
                    Name = "Romance"
                });
        }
    }
}
