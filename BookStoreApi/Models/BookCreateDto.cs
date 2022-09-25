using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1800)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
