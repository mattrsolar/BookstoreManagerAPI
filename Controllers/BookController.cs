using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            return Ok();
        }
    }
}
