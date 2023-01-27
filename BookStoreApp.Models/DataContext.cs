using BookStoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            modelBuilder.Entity<User>()
                .HasKey(u => u.PasswordHash);
        }
    }
}
