namespace BookStoreApp.Data.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string YearsOfLife { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
