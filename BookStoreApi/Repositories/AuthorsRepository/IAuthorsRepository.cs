using System;
using System.Collections.Generic;
using BookStoreApi.Entities;

namespace BookStoreApi.Repositories.AuthorsRepository
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(Guid authorId);
        Task AddAuthorAsync(Author author);
    }
}
