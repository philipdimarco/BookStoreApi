using System;
using System.Collections.Generic;
using BookStoreApi.Entities;
using BookStoreApi.Repositories.BaseRepository;

namespace BookStoreApi.Repositories.AuthorsRepository
{
    public interface IAuthorsRepository : IBaseRepository<Author>
    {
        Task<Author> GetByFullNameAsync(String fullName);
    }
}
