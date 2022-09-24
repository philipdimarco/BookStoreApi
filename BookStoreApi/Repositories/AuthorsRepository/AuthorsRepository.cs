using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.AuthorsRepository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private BookStoreAppContext _appContext;

        public AuthorsRepository(BookStoreAppContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _appContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorAsync(Guid authorId)
        {
            return await _appContext.Authors.FindAsync(authorId);
        }

        public async Task AddAuthorAsync(Author authorToAdd)
        {
            if (authorToAdd == null)
            {
                throw new ArgumentNullException(nameof(authorToAdd));
            }
            await _appContext.Authors.AddAsync(authorToAdd);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _appContext.SaveChangesAsync() > 0;
        }
    }
}
