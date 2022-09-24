using BookStoreApi.Contexts;
using BookStoreApi.Repositories.AppUsersRepository;
using BookStoreApi.Repositories.AuthorsRepository;
using BookStoreApi.Repositories.BooksRepository;

namespace BookStoreApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appContext;
        public IBooksRepository BooksRepository { get; init; }
        public IAuthorsRepository AuthorsRepository { get; init; }
        public IAppUsersRepository AppUsersRepository { get; init; }

        public UnitOfWork(AppDbContext appContext, IBooksRepository booksRepository,
            IAuthorsRepository authorsRepository, IAppUsersRepository appUsersRepository)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
            BooksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            AuthorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
            AppUsersRepository = appUsersRepository ?? throw new ArgumentNullException(nameof(appUsersRepository));
        }
        public async Task<bool> SaveChangesAsync()
        {
            // true if 1 or more entities were changed
            return await _appContext.SaveChangesAsync() > 0;
        }
    }
}
