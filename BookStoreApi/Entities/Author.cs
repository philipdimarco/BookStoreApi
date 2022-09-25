using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
    [Table("Authors")]
    public class Author
    {
        [Key]        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(180)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [MaxLength(180)]
        public string LastName { get; set; } = String.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
