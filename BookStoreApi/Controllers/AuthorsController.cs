//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using BookStoreApi.Models;
//using BookStoreApi.Entities;
//using BookStoreApi.Repositories;

//namespace BookStoreApi.Controllers
//{
//    [Route("api/authors")]
//    public class AuthorsController : Controller
//    {
//        private IAuthorBookRepository _authorBookRepository;

//        public AuthorsController(IAuthorBookRepository authorBookRepository)
//        {
//            _authorBookRepository = authorBookRepository;
//        }

//        [HttpGet("{id}", Name ="GetAuthor")]
//        public IActionResult GetAuthor(Guid id, [FromQuery] string fields)
//        {
//            var authorFromRepo = _authorBookRepository.GetAuthor(id);

//            if (authorFromRepo == null)
//            {
//                return NotFound();
//            }

//            var author = Mapper.Map<AuthorDto>(authorFromRepo);

//            return Ok(linkedResourceToReturn);
//        }

//        [HttpPost(Name = "CreateAuthor")]
//        public IActionResult CreateAuthor([FromBody] AuthorDto author)
//        {
//            if (author == null)
//            {
//                return BadRequest();
//            }

//            var authorEntity = Mapper.Map<Author>(author);

//            _authorBookRepository.AddAuthor(authorEntity);

//            if (!_authorBookRepository.Save())
//            {
//                throw new Exception("Creating an author failed on save.");
//               // return StatusCode(500, "A problem happened with handling your request.");
//            }

//            var authorToReturn = Mapper.Map<AuthorDto>(authorEntity);

//            return CreatedAtRoute("GetAuthor",
//                new { id = linkedResourceToReturn["Id"] },
//                linkedResourceToReturn);
//        }


//        [HttpPost(Name = "CreateAuthorWithDateOfDeath")]
//        public IActionResult CreateAuthorWithDateOfDeath(
//            [FromBody] AuthorDto author)
//        {
//            if (author == null)
//            {
//                return BadRequest();
//            }

//            var authorEntity = Mapper.Map<Author>(author);

//            _authorBookRepository.AddAuthor(authorEntity);

//            if (!_authorBookRepository.Save())
//            {
//                throw new Exception("Creating an author failed on save.");
//                // return StatusCode(500, "A problem happened with handling your request.");
//            }

//            var authorToReturn = Mapper.Map<AuthorDto>(authorEntity);

//            var links = CreateLinksForAuthor(authorToReturn.Id, null);

//            var linkedResourceToReturn = authorToReturn.ShapeData(null)
//                as IDictionary<string, object>;

//            linkedResourceToReturn.Add("links", links);

//            return CreatedAtRoute("GetAuthor",
//                new { id = linkedResourceToReturn["Id"] },
//                linkedResourceToReturn);
//        }

//        [HttpPost("{id}")]
//        public IActionResult BlockAuthorCreation(Guid id)
//        {
//            if (_authorBookRepository.AuthorExists(id))
//            {
//                return new StatusCodeResult(StatusCodes.Status409Conflict);
//            }

//            return NotFound();
//        }

//        [HttpDelete("{id}", Name = "DeleteAuthor")]
//        public IActionResult DeleteAuthor(Guid id)
//        {
//            var authorFromRepo = _authorBookRepository.GetAuthor(id);
//            if (authorFromRepo == null)
//            {
//                return NotFound();
//            }

//            _authorBookRepository.DeleteAuthor(authorFromRepo);

//            if (!_authorBookRepository.Save())
//            {
//                throw new Exception($"Deleting author {id} failed on save.");
//            }
//            return NoContent();
//        }
//    }
//}
