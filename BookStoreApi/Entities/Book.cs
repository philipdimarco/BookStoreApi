using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
    public class Book
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = String.Empty;

        [MaxLength(1800)]
        public string Description { get; set; } = String.Empty;

        public decimal Price { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = new Author();

        public Guid AuthorId { get; set; }
    }
}
