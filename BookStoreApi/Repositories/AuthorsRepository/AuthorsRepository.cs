using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using BookStoreApi.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.AuthorsRepository
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuthorsRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<Author> GetByFullNameAsync(String fullName)
        {
            return await _appDbContext.Authors.FirstOrDefaultAsync(r => ((r.FirstName+r.LastName).ToLower() == fullName.ToLower()));
        }
    }
}
