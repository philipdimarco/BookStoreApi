using BookStoreApi.Entities;

namespace BookStoreApi.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddSingleAsync(T type);
    }
}
