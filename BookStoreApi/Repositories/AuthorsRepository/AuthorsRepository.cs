using System;
using System.Collections.Generic;
using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStoreApi.Repositories.AuthorsRepository
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
