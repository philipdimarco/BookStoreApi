using System;
using System.Collections.Generic;
using BookStoreApi.Entities;
using BookStoreApi.Repositories.BaseRepository;

namespace BookStoreApi.Repositories.BooksRepository
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        Task<Book> GetByTitleAsync(String title);
    }
}
