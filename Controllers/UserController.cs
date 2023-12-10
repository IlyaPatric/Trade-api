using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeApi.Tables;

namespace TradeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetMoreUsersById(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users users)
        {
            _context.users.Add(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateUser),new { id = users.id }, users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
