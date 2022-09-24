using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories.BooksRepository
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(Guid bookId);
        Task AddBookAsync(Book book);
        Task<bool> SaveChangesAsync();
    }
}
