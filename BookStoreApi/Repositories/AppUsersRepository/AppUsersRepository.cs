using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using BookStoreApi.Repositories.BaseRepository;
using BookStoreApi.Repositories.BooksRepository;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.AppUsersRepository
{
    public class AppUsersRepository : BaseRepository<User>, IAppUsersRepository
    {
        private readonly AppDbContext _appDbContext;

        public AppUsersRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<User> GetByUserNameAsync(String userName)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(r => r.Username.ToLower() == userName.ToLower());
        }
    }
}
