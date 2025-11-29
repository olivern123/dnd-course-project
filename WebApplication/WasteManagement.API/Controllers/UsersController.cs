using Microsoft.AspNetCore.Mvc;
using WasteManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using WasteManagement.API.Data;


namespace WasteManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
    

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserDto dto)
        {
            
            var foundUser = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Username == dto.Username &&
                 u.Password == dto.Password);

            if (foundUser == null) 
                return Unauthorized("Invalid credentials.");
            

            
            // Important: You should not return the password in production
            return Ok(foundUser);
        }
    }
}
