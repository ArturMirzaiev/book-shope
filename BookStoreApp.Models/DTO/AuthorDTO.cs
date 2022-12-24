namespace BookStoreApp.Data.DTO
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string YearsOfLife { get; set; }
        public List<BookShortDTO> Books { get; set; }
    }
}
