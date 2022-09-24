using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreApi.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {  }
    }
}