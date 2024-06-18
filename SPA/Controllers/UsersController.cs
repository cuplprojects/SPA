using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA;
using SPA.Data;
using SPA.Models;
using SPA.Services;
using SPA.Encryptions;
using Newtonsoft.Json;

namespace SPA.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static int _globalUserIdCounter;
        private static int _globalUserAuthIdCounter; 
        private readonly FirstDbContext _firstDbcontext;
        private readonly SecondDbContext _secondDbContext;
        private readonly IChangeLogger _changeLogger;

        public UsersController(FirstDbContext firstDbcontext, SecondDbContext secondDbContext, IChangeLogger changeLogger)
        {
            _firstDbcontext = firstDbcontext;
            _secondDbContext = secondDbContext;
            _changeLogger = changeLogger;
            _globalUserIdCounter = 0;
            _globalUserAuthIdCounter = 0;
        }

        // GET: api/Users
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                return await _firstDbcontext.Users.ToListAsync();
            }
            else
            {
                return await _secondDbContext.Users.ToListAsync();
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id, string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                var user = await _firstDbcontext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            else
            {
                var user = await _secondDbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user, string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                if (id != user.UserId)
                {
                    return BadRequest();
                }
                _firstDbcontext.Entry(user).State = EntityState.Modified;
            }
            else
            {
                if (id != user.UserId)
                {
                    return BadRequest();
                }
                _secondDbContext.Entry(user).State = EntityState.Modified;
            }
            try
            {
                if (WhichDatabase == "Local")
                {
                    await _firstDbcontext.SaveChangesAsync();
                }
                else
                {
                    await _secondDbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id, WhichDatabase))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user, string WhichDatabase)
        {
            int newUserId = GetNextUserId(WhichDatabase);
            user.UserId = newUserId;

            if (WhichDatabase == "Local")
            {
                _firstDbcontext.Users.Add(user);
            }
            else
            {
                _secondDbContext.Users.Add(user);
            }

            try
            {
                if (WhichDatabase == "Local")
                {
                    await _firstDbcontext.SaveChangesAsync();
                }
                else
                {
                    await _secondDbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId, WhichDatabase))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            int newAuthId = GetNextUserAuthId(WhichDatabase);

            string generatedPassword = PasswordGenerate.GeneratePassword();
            string hashedPassword = Sha256Hasher.ComputeSHA256Hash(generatedPassword);

            UserAuth userAuth = new UserAuth
            {
                UserAuthId = newAuthId,
                UserId = newUserId,
                Password = hashedPassword,
                AutogenPass = true
            };

            if (WhichDatabase == "Local")
            {
                _firstDbcontext.UserAuths.Add(userAuth);
            }
            else
            {
                _secondDbContext.UserAuths.Add(userAuth);
            }

            try
            {
                if (WhichDatabase == "Local")
                {
                    await _firstDbcontext.SaveChangesAsync();
                }
                else
                {
                    await _secondDbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                if (UserAuthExists(newAuthId, WhichDatabase))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            string userJson = JsonConvert.SerializeObject(user);
            string userAuthJson = JsonConvert.SerializeObject(userAuth);

            _changeLogger.LogForDBSync("Insert","Users", $"{userJson}", WhichDatabase);
            _changeLogger.LogForDBSync("Insert","UserAuths", $"{userAuthJson}", WhichDatabase);

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                var user = await _firstDbcontext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _firstDbcontext.Users.Remove(user);
                await _firstDbcontext.SaveChangesAsync();
            }
            else
            {
                var user = await _secondDbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _secondDbContext.Users.Remove(user);
                await _secondDbContext.SaveChangesAsync();
            }

            return NoContent();
        }

        private bool UserExists(int id, string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                return _firstDbcontext.Users.Any(e => e.UserId == id);
            }
            else
            {
                return _secondDbContext.Users.Any(e => e.UserId == id);
            }
        }
        private bool UserAuthExists(int id, string WhichDatabase)
        {
            if (WhichDatabase == "Local")
            {
                return _firstDbcontext.UserAuths.Any(e => e.UserAuthId == id);
            }
            else
            {
                return _secondDbContext.UserAuths.Any(e => e.UserAuthId == id);
            }
        }

        private int GetNextUserId(string WhichDatabase)
        {
            int maxUserIdLocal = _firstDbcontext.Users.Any() ? _firstDbcontext.Users.Max(u => u.UserId) : 0;
            int maxUserIdSecond = _secondDbContext.Users.Any() ? _secondDbContext.Users.Max(u => u.UserId) : 0;

            int maxUserId = Math.Max(maxUserIdLocal, maxUserIdSecond);

            return maxUserId + 1;
        }
        private int GetNextUserAuthId(string WhichDatabase)
        {
            int maxUserIdLocal = _firstDbcontext.UserAuths.Any() ? _firstDbcontext.Users.Max(u => u.UserId) : 0;
            int maxUserIdSecond = _secondDbContext.UserAuths.Any() ? _secondDbContext.Users.Max(u => u.UserId) : 0;

            int maxUserId = Math.Max(maxUserIdLocal, maxUserIdSecond);

            return maxUserId + 1;
        }

    }
}