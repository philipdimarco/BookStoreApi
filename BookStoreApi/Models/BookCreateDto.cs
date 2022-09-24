namespace BookStoreApi.Models
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
    }
}
