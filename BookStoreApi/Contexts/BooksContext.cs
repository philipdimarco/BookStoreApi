using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreApi.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                    FirstName = "Martin",
                    LastName = "Fowler",
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Id = Guid.Parse("863117BB-62AD-4A22-85FA-6E8A5F89D855"),
                            Title = "Refactoring",
                            Description = "Martin Fowler",
                            Price = 29.99M,
                            AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                            Author = new Author()
                        },
                        new Book()
                        {
                            Id = Guid.Parse("D77ACBDD-0675-48D0-A16D-347777924AB5"),
                            Title = "Domain Specific Languages",
                            Description = "Martin Fowler",
                            Price = 45.29M,
                            AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                            Author = new Author()
                        }
                    }
                });

            modelBuilder.Entity<Book>().HasData(
                        new Book()
                        {
                            Id = Guid.Parse("863117BB-62AD-4A22-85FA-6E8A5F89D855"),
                            Title = "Refactoring",
                            Description = "Martin Fowler",
                            Price = 29.99M,
                            AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                            Author = new Author()
                        },
                        new Book()
                        {
                            Id = Guid.Parse("D77ACBDD-0675-48D0-A16D-347777924AB5"),
                            Title = "Domain Specific Languages",
                            Description = "Martin Fowler",
                            Price = 45.29M,
                            AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                            Author = new Author()
                        }
                 );
        }

    }
}