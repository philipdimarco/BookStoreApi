using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.BooksRepository
{
    public class BooksRepository : BaseRepository<Book>,  IBooksRepository
    {
        public BooksRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
