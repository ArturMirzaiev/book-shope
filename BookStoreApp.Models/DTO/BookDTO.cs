namespace BookStoreApp.Data.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
    }
}
