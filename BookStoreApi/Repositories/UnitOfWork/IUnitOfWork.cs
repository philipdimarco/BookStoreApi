using BookStoreApi.Repositories.AppUsersRepository;
using BookStoreApi.Repositories.AuthorsRepository;
using BookStoreApi.Repositories.BooksRepository;

namespace BookStoreApi.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; init; }
        IAuthorsRepository AuthorsRepository { get; init; }
        IAppUsersRepository AppUsersRepository { get; init; }

        Task<bool> SaveChangesAsync();
    }
}
