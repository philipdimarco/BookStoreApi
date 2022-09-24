namespace BookStoreApi.Repositories.BaseRepository
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
