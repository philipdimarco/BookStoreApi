﻿using BookStoreApi.Helpers;
using BookStoreApi.Models;
using BookStoreApi.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

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

    }
}
