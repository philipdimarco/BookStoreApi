using BookStoreApi.Helpers;
using BookStoreApi.Models;
using BookStoreApi.Repositories.UnitOfWork;

namespace BookStoreApi.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task<BookDto> GetBookById(Guid id);
        Task<BookDto> GetBookByTitle(string title);
        Task<BookDto> AddBook(BookCreateDto bookCreateDto);
    }
}
