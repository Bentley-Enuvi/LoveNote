using LoveNote_Chat.Server.Data;
using LoveNote_Chat.Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoveNote_Chat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly LoveNoteChatDbContext _context;

        public UsersController(LoveNoteChatDbContext context)
        {
            _context = context;
        }


        [HttpGet("get-all-users")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }


        [HttpGet("get-user-by-id/{userId}")]
        public async Task<ActionResult<AppUser>> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
