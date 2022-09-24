using BookStoreApi.Contexts;
using BookStoreApi.Helpers;
using BookStoreApi.Models;
using BookStoreApi.Repositories.BooksRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksContext)
        {
            _booksRepository = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var booksEntities = await _booksRepository.GetAllAsync();
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
            var booksEntity = await _booksRepository.GetByIdAsync(id);
            if (booksEntity == null)
            {
                return NotFound();
            }
            return Ok(booksEntity);
        }
/*
        [HttpPost(Name = "CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookDto)
        {
            var bookEntity = ObjectMapperExtension.FromCreateBookDto(bookDto);
            await _booksRepository.AddBookAsync(bookEntity);
            await _booksRepository.SaveChangesAsync();
            return CreatedAtRoute("GetBook", new { id = bookEntity.Id }, bookEntity);
        }
*/

    }
}
