using _20250317.Factories;
using Microsoft.AspNetCore.Mvc;

namespace _20250317.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountFactory _factory;

        public AccountController(AccountFactory factory)
        {
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(string accountName)
        {
            try
            {
                await _factory.AddAccount(accountName);
                return Ok(new { Message = "Account created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                var data = await _factory.GetAccount(id);

                if (data == null)
                {
                    return NotFound(new { Message = "Account not found." });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAccount(int id, string accountName)
        {
            try
            {
                await _factory.EditAccountAsync(id, accountName);
                return Ok(new { Message = "Account has been edited successfully" });
            }
            catch (Exception ex) 
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _factory.DeleteAccountAsync(id);
                return Ok(new { Message = "Account has been deleted successfully" });
            }

            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
      
    }
}
