using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories.AppUsersRepository
{
    public interface IAppUsersRepository : IBaseRepository<User>
    {
        Task<User> GetByUserNameAsync(String userName);
    }
}
