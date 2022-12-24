using BookStoreApp.Data.Classes;

namespace BookStoreApp.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
