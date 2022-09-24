using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(User user);
        Task AddUserAsync(User user);
        Task<bool> SaveChangesAsync();
    }
}
