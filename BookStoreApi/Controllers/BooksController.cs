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

        [HttpGet("GetBooks"), Authorize]
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
