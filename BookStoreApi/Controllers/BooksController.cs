using BookStoreApi.Contexts;
using BookStoreApi.Helpers;
using BookStoreApi.Models;
using BookStoreApi.Repositories.UnitOfWork;
using BookStoreApi.Repositories.BooksRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet("GetBooks"), AllowAnonymous]
        public async Task<IActionResult> GetBooks()
        {
            var booksEntities = await _unitOfWork.BooksRepository.GetAllAsync();
            if (booksEntities == null)
            {
                return NotFound();
            }
            return Ok(booksEntities);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var booksEntity = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (booksEntity == null)
            {
                return NotFound();
            }
            return Ok(booksEntity);
        }

        [HttpGet]
        [Route("{title}", Name = "GetBookByTitle")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var booksEntity = await _unitOfWork.BooksRepository.GetByTitleAsync(title);
            if (booksEntity == null)
            {
                return NotFound();
            }
            return Ok(booksEntity);
        }

        [HttpPost("AddBook"), Authorize]
        public async Task<IActionResult> AddBook([FromBody] BookCreateDto bookDto)
        {
            // Validate AuthorId GUID
            var existingBook = _unitOfWork.BooksRepository.GetByTitleAsync(bookDto.Title);
            if (existingBook != null && existingBook.Result.AuthorId.Equals(bookDto.AuthorId))
            {
                return BadRequest("This book title already exists");
            }
            var bookEntity = bookDto.FromCreateBookDto();
            await _unitOfWork.BooksRepository.AddSingleAsync(bookEntity);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtRoute("GetBook", new { id = bookEntity.Id }, bookEntity);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] BookDto bookDto)
        {
            // Validate AuthorId GUID
            var targetBook = _unitOfWork.BooksRepository.GetByIdAsync(bookDto.Id);
            if (targetBook == null || targetBook.Result == null)
            {
                return BadRequest("Cannot update a book that does not exist");
            }
            var updatedBookEntity = bookDto.MapFromBookDto(targetBook.Result);
            _unitOfWork.BooksRepository.UpdateSingle(updatedBookEntity);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var targetBook = _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (targetBook == null)
            {
                return BadRequest("Cannot delete a book that does not exist");
            }
            _unitOfWork.BooksRepository.RemoveSingle(targetBook.Result);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
