using _20250317.Factories;
using _20250317.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _20250317.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController
    {
        private readonly PostFactory _postFactory;

        public PostController(PostFactory postFactory)
        {
            _postFactory = postFactory;
        }

        public async Task<IActionResult> GetPostAPI (int pagination)
        {
            try {
                var factory = _postFactory.GetData(pagination);
                var data = await factory.GetPost(pagination);

                return Ok(data);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        private IActionResult BadRequest(object value)
        {
            throw new NotImplementedException();
        }

        private IActionResult Ok(List<PostResponse> data)
        {
            throw new NotImplementedException();
        }
    }
}
