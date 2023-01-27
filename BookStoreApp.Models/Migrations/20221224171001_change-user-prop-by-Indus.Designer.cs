﻿// <auto-generated />
using System;
using BookStoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221224171001_change-user-prop-by-Indus")]
    partial class changeuserpropbyIndus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BooksId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("BookStoreApp.Data.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearsOfLife")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"),
                            FullName = "Jack London",
                            YearsOfLife = "1876-1916"
                        },
                        new
                        {
                            Id = new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"),
                            FullName = "Charles Bukowski",
                            YearsOfLife = "1920-1994"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Data.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f263bf34-92ff-4422-bfcd-08dad63ed3e4"),
                            Description = "Buck is a dog born to luxury, but he is betrayed and sold as a sled dog in the harsh and frozen Yukon. But Buck is stronger than any man knew, and he escapes captivity and rises above his enemies to become the leader of a wolf pack.",
                            ImageUrl = "https://static.yakaboo.ua/media/catalog/product/9/7/9781509841769.jpg",
                            Price = 6.85m,
                            Quantity = 3,
                            Title = "The Call of the Wild"
                        },
                        new
                        {
                            Id = new Guid("c073dcc4-2755-4a26-6449-08dad700b701"),
                            Description = "One of Bukowski's best, this beer-soaked, deliciously degenerate novel follows the wanderings of aspiring writer Henry Chinaski across World War II-era America. Deferred from military service, Chinaski travels from city to city, moving listlessly from one odd job to another, always needing money but never badly enough to keep a job. His day-to-day existence spirals into an endless litany of pathetic whores, sordid rooms, dreary embraces, and drunken brawls, as he makes his bitter, brilliant way from one drink to the next.",
                            ImageUrl = "http://www.impawards.com/2005/posters/factotum_ver3_xlg.jpg",
                            Price = 12.49m,
                            Quantity = 2,
                            Title = "Factotum"
                        },
                        new
                        {
                            Id = new Guid("f371dd81-e486-410c-9b66-b5a261c979bc"),
                            Description = "Martin Eden is an impoverished sailor who pursues, obsessively and aggressively, dreams of education and literary fame. He educates himself feverishly and becomes a writer, hoping to acquire the respectability sought by his society-girl sweetheart.",
                            ImageUrl = "https://assets1.bmstatic.com/assets/books-covers/20/ac/Rjh6zuzI-ipad.jpeg?image_hash=f5e5a384f549c9d17707c91d8153e68e",
                            Price = 4.99m,
                            Quantity = 1,
                            Title = "Martin Eden"
                        },
                        new
                        {
                            Id = new Guid("5d841405-a9bb-4d33-8ec8-3823a991eb12"),
                            Description = "Edited by John Martin, the legendary publisher of Black Sparrow Press and a close friend of Bukowski's, The Pleasures of the Damned is a selection of the best works from Bukowski's long poetic career, including the last of his never-before-collected poems. Celebrating the full range of the poet's extra-ordinary and surprising sensibility, and his uncompromising linguistic brilliance, these poems cover a rich lifetime of experiences and speak to Bukowski's \"immense intelligence, the caring heart that saw through the sham of our pretenses and had pity on our human condition\" (The New York Quarterly). The Pleasures of the Damned is an astonishing poetic treasure trove, essential reading for both longtime fans and those just discovering this unique and legendary American voice.",
                            ImageUrl = "https://www.booktopia.com.au/covers/600/9781786895226/8489/the-pleasures-of-the-damned.jpg",
                            Price = 4m,
                            Quantity = 1,
                            Title = "The Pleasures of the Damned"
                        },
                        new
                        {
                            Id = new Guid("9a561a1a-763b-431d-b8b1-8158c4c473c6"),
                            Description = "Ham on Rye is a 1982 semi-autobiographical novel by American author and poet Charles Bukowski. Written in the first person, the novel follows Henry Chinaski, Bukowski's thinly veiled alter ego, during his early years. Written in Bukowski's characteristically straightforward prose, the novel tells of his coming-of-age in Los Angeles during the Great Depression.",
                            ImageUrl = "https://pictures.abebooks.com/isbn/9781841951638-us-300.jpg",
                            Price = 10.99m,
                            Quantity = 1,
                            Title = "Ham on Rye"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Data.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a41c1b1b-e67e-4d7b-a6d5-14e3eae1366d"),
                            Name = "Autobiography"
                        },
                        new
                        {
                            Id = new Guid("defaf2ca-511a-4a23-8b01-480fbd8a68ee"),
                            Name = "Poetry"
                        },
                        new
                        {
                            Id = new Guid("b7fed066-9ded-4be5-9801-95eed87fc048"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("f7b4126d-9149-40cb-867f-f464163ffe26"),
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Data.Entities.User", b =>
                {
                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(900)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PasswordHash");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BookStoreApp.Data.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("BookStoreApp.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
