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
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksService _booksService;

        public BooksController(IUnitOfWork unitOfWork, IBooksService booksService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        [HttpGet("GetBooks"), AllowAnonymous]
        public async Task<IActionResult> GetBooks()
        {
            var booksDto = await _booksService.GetBooks();
            if (!booksDto.Any())
            {
                return NotFound();
            }
            return Ok(booksDto);
        }

        [HttpGet]
        [Route("{id:Guid}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var bookDto = await _booksService.GetBookById(id);
            if (bookDto.Id.Equals(Guid.Empty))
            {
                return NotFound();
            }
            return Ok(bookDto);
        }

        [HttpGet]
        [Route("{title:alpha}", Name = "GetBookByTitle")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var bookDto = await _booksService.GetBookByTitle(title);
            if (bookDto.Id.Equals(Guid.Empty))
            {
                return NotFound();
            }
            return Ok(bookDto);
        }

        [HttpPost("AddBook"), Authorize]
        public async Task<IActionResult> AddBook([FromBody] BookCreateDto bookCreateDto)
        {
            var bookDto = await _booksService.AddBook(bookCreateDto);
            if (bookDto.Id.Equals(Guid.Empty))
            {
                return BadRequest("This book title already exists");
            }
            return CreatedAtRoute("GetBook", new { id = bookDto.Id }, bookDto);
        }

        //[HttpPut("{id:Guid}"), Authorize]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] BookDto bookDto)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest("Invalid book id");
            }
            var updatedBookDto = await _booksService.UpdateBook(id, bookDto);
            if (updatedBookDto.Id.Equals(Guid.Empty))
            {
                return BadRequest("Cannot update a book that does not exist");
            }
            return NoContent();
        }

        //[HttpDelete("{id:Guid}"), Authorize]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest("Invalid book id");
            }
            var deletedBookDto = await _booksService.DeleteBook(id);
            if (deletedBookDto.Id.Equals(Guid.Empty))
            {
                return BadRequest("Cannot delete a book that does not exist");
            }
            return NoContent();
        }
    }
}
