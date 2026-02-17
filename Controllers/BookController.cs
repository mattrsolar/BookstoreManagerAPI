using BookstoreManagerAPI.Enums;
using BookstoreManagerAPI.Models;
using BookstoreManagerAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = new Book();
                if (id <= 0)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredBook), StatusCodes.Status201Created)]
        public IActionResult CreateBook([FromBody]Book request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest();
                }
                if (request.Title.Length < 2 && request.Title.Length > 120)
                { 
                    return BadRequest("Title must be between 2 and 120 characters.");
                }
                if (request.Author.Length < 2 && request.Author.Length > 120)
                {
                    return BadRequest("Author must be between 2 and 120 characters.");
                }
                if (request.Price < 0)
                {
                    return BadRequest("Price cannot be negative.");
                }
                if (request.Stock < 0)
                {
                    return BadRequest("Stock cannot be negative.");
                }
                if (!Enum.TryParse<Genre>(request.Genre, true, out var genre)) {
                    return BadRequest("Invalid Genre.");
                }

                var response = new ResponseRegisteredBook
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };


                return Created(string.Empty, response);
            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateBook([FromRoute]int id, [FromBody]Book request)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (request == null)
                {
                    return BadRequest();
                }
                if (request.Title.Length < 2 && request.Title.Length > 120)
                {
                    return BadRequest("Title must be between 2 and 120 characters.");
                }
                if (request.Author.Length < 2 && request.Author.Length > 120)
                {
                    return BadRequest("Author must be between 2 and 120 characters.");
                }
                if (request.Price < 0)
                {
                    return BadRequest("Price cannot be negative.");
                }
                if (request.Stock < 0)
                {
                    return BadRequest("Stock cannot be negative.");
                }
                if (!Enum.TryParse<Genre>(request.Genre, true, out var genre))
                {
                    return BadRequest("Invalid Genre.");
                }


            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteBook([FromRoute]int id)
        {
            try 
            { 
                if (id <= 0)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
            
        }


    }
}
