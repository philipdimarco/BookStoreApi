using BookStoreApi.Helpers;
using BookStoreApi.Models;
using BookStoreApi.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookStoreApi.Services
{
    public class BooksService : IBooksService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var booksEntities = await _unitOfWork.BooksRepository.GetAllAsync();
            if (booksEntities == null)
            {
                return new List<BookDto>();
            }
            return booksEntities.FromBookEntities();
        }
        public async Task<BookDto> GetBookById(Guid id)
        {
            var bookEntity = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (bookEntity == null)
            {
                return new BookDto();
            }
            return bookEntity.FromBookEntity();
        }

        public async Task<BookDto> GetBookByTitle(string title)
        {
            var bookEntity = await _unitOfWork.BooksRepository.GetByTitleAsync(title);
            if (bookEntity == null)
            {
                return new BookDto();
            }
            return bookEntity.FromBookEntity();
        }
        public async Task<BookDto> AddBook(BookCreateDto bookCreateDto)
        {
            var existsBookEntity = _unitOfWork.BooksRepository.GetByTitleAsync(bookCreateDto.Title);
            if (existsBookEntity.Result == null)
            {
                return new BookDto();
            }
            var bookEntity = bookCreateDto.FromCreateBookDto();
            await _unitOfWork.BooksRepository.AddSingleAsync(bookEntity);
            await _unitOfWork.SaveChangesAsync();
            return bookEntity.FromBookEntity();
        }
        public async Task<BookDto> UpdateBook(Guid id, BookDto bookDto)
        {
            var targetBook = _unitOfWork.BooksRepository.GetByIdAsync(bookDto.Id);
            if (targetBook.Result == null)
            {
                return new BookDto();
            }
            var updatedBookEntity = bookDto.MapFromBookDto(targetBook.Result);
            _unitOfWork.BooksRepository.UpdateSingle(updatedBookEntity);
            await _unitOfWork.SaveChangesAsync();
            return bookDto;
        }
        public async Task<BookDto> DeleteBook(Guid id)
        {
            var targetBook = _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (targetBook.Result == null)
            {
                return new BookDto();
            }
            _unitOfWork.BooksRepository.RemoveSingle(targetBook.Result);
            await _unitOfWork.SaveChangesAsync();
            return targetBook.Result.FromBookEntity();

        }

    }
}
