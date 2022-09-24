using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private AppDbContext _appContext;

        public AuthRepository(AppDbContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _appContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(User user)
        {
            return await _appContext.Users.FindAsync(user.Username);
        }

        public async Task AddUserAsync(User userToAdd)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException(nameof(userToAdd));
            }
            await _appContext.Users.AddAsync(userToAdd);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _appContext.SaveChangesAsync() > 0;
        }
    }
}
