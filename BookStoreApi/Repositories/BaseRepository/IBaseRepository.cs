namespace BookStoreApi.Repositories.BaseRepository
{
    public interface IBaseRepository
    {
        Task<bool> SaveChangesAsync();
    }
}
