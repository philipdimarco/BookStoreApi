using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories.BooksRepository
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
    }
}
