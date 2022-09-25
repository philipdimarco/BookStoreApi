using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using BookStoreApi.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.BooksRepository
{
    public class BooksRepository : BaseRepository<Book>,  IBooksRepository
    {
        private readonly AppDbContext _appDbContext;

        public BooksRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<Book> GetByTitleAsync(String title)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(r => r.Title.ToLower() == title.ToLower());
        }
    }
}
