using Microsoft.AspNetCore.Http;

namespace BookStoreApp.Data.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
    }
}
