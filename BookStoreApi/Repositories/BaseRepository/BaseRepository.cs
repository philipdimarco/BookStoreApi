﻿using BookStoreApi.Contexts;

namespace BookStoreApi.Repositories.BaseRepository
{
    public class BaseRepository : IBaseRepository
    {
        private BookStoreAppContext _appContext;

        public BaseRepository(BookStoreAppContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }
        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _appContext.SaveChangesAsync() > 0;
        }
    }
}