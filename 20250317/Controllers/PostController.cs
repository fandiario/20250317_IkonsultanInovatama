using _20250317.Factories;
using _20250317.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _20250317.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostFactory _postFactory;

        public PostController(PostFactory postFactory)
        {
            _postFactory = postFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostAPI( int pagination, int sizes)
        {
            try
            {
                var factory = _postFactory.GetData(pagination, sizes);
                var data = await factory.GetPost(pagination, sizes);

                return Ok(data); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message }); 
            }
        }


    }
}
