using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.BooksRepository
{
    public class BooksRepository : IBooksRepository
    {
        private AppDbContext _booksContext;

        public BooksRepository(AppDbContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(_booksContext));
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _booksContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid bookId)
        {
            return await _booksContext.Books.FindAsync(bookId);
        }


        public async Task AddBookAsync(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                throw new ArgumentNullException(nameof(bookToAdd));
            }
            await _booksContext.Books.AddAsync(bookToAdd);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _booksContext.SaveChangesAsync() > 0;
        }
    }
}
