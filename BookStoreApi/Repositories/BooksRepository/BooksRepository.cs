using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.BooksRepository
{
    public class BooksRepository : BaseRepository<Book>,  IBooksRepository
    {
        private AppDbContext _appDbContext;

        public BooksRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        //public async Task<IEnumerable<Book>> GetBooksAsync()
        //{
        //    return await _booksContext.Books.ToListAsync();
        //}

        //public async Task<Book> GetByIdAsync(Guid bookId)
        //{
        //    return await _booksContext.Books.FindAsync(bookId);
        //}


        //public async Task AddBookAsync(Book bookToAdd)
        //{
        //    if (bookToAdd == null)
        //    {
        //        throw new ArgumentNullException(nameof(bookToAdd));
        //    }
        //    await _booksContext.Books.AddAsync(bookToAdd);
        //}

        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
