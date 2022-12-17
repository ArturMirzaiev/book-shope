using BookStoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApp.Data.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(k => k.Authors)
                .WithMany(k => k.Books);

            builder.HasMany(d => d.Categories)
                .WithMany(k => k.Books);

            builder.HasData(
                new Book
                {
                    Id = new Guid("f263bf34-92ff-4422-bfcd-08dad63ed3e4"),
                    Title = "The Call of the Wild",
                    Description = "Buck is a dog born to luxury, but he is betrayed and sold as a sled dog in the harsh and frozen Yukon. But Buck is stronger than any man knew, and he escapes captivity and rises above his enemies to become the leader of a wolf pack.",
                    Price = 6.85M,
                    Quantity = 3
                },

                new Book
                {
                    Id = new Guid("c073dcc4-2755-4a26-6449-08dad700b701"),
                    Title = "Factotum",
                    Description = "One of Bukowski's best, this beer-soaked, deliciously degenerate novel follows the wanderings of aspiring writer Henry Chinaski across World War II-era America. Deferred from military service, Chinaski travels from city to city, moving listlessly from one odd job to another, always needing money but never badly enough to keep a job. His day-to-day existence spirals into an endless litany of pathetic whores, sordid rooms, dreary embraces, and drunken brawls, as he makes his bitter, brilliant way from one drink to the next.",
                    Price = 12.49M,
                    Quantity = 2
                },

                new Book
                {
                    Id = new Guid("f371dd81-e486-410c-9b66-b5a261c979bc"),
                    Title = "Martin Eden",
                    Description = "Martin Eden is an impoverished sailor who pursues, obsessively and aggressively, dreams of education and literary fame. He educates himself feverishly and becomes a writer, hoping to acquire the respectability sought by his society-girl sweetheart.",
                    Price = 4.99M,
                    Quantity = 1
                },

                new Book
                {
                    Id = new Guid("5d841405-a9bb-4d33-8ec8-3823a991eb12"),
                    Title = "The Pleasures of the Damned",
                    Description = "Edited by John Martin, the legendary publisher of Black Sparrow Press and a close friend of Bukowski's, The Pleasures of the Damned is a selection of the best works from Bukowski's long poetic career, including the last of his never-before-collected poems. Celebrating the full range of the poet's extra-ordinary and surprising sensibility, and his uncompromising linguistic brilliance, these poems cover a rich lifetime of experiences and speak to Bukowski's \"immense intelligence, the caring heart that saw through the sham of our pretenses and had pity on our human condition\" (The New York Quarterly). The Pleasures of the Damned is an astonishing poetic treasure trove, essential reading for both longtime fans and those just discovering this unique and legendary American voice.",
                    Price = 4M,
                    Quantity = 1
                },

                new Book
                {
                    Id = new Guid("9a561a1a-763b-431d-b8b1-8158c4c473c6"),
                    Title = "Ham on Rye",
                    Description = "Ham on Rye is a 1982 semi-autobiographical novel by American author and poet Charles Bukowski. Written in the first person, the novel follows Henry Chinaski, Bukowski's thinly veiled alter ego, during his early years. Written in Bukowski's characteristically straightforward prose, the novel tells of his coming-of-age in Los Angeles during the Great Depression.",
                    Price = 10.99M,
                    Quantity = 1
                }
                );
        }
    }
}
