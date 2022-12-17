using BookStoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApp.Data.EntityConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(a => a.Books)
                .WithMany(a => a.Authors);

            builder.HasData(
                new Author
                {
                    Id = new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"),
                    FullName = "Jack London",
                    YearsOfLife = "1876-1916"
                },

                new Author
                {
                    Id = new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"),
                    FullName = "Charles Bukowski",
                    YearsOfLife = "1920-1994"
                }
            );
        }
    }
}
