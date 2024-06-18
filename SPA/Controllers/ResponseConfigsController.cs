using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA;
using SPA.Data;

namespace SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseConfigsController : ControllerBase
    {
        private readonly FirstDbContext _context;

        public ResponseConfigsController(FirstDbContext context)
        {
            _context = context;
        }

        // GET: api/ResponseConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseConfig>>> GetResponseConfigs()
        {
            return await _context.ResponseConfigs.ToListAsync();
        }

        // GET: api/ResponseConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseConfig>> GetResponseConfig(int id)
        {
            var responseConfig = await _context.ResponseConfigs.FindAsync(id);

            if (responseConfig == null)
            {
                return NotFound();
            }

            return responseConfig;
        }

        // PUT: api/ResponseConfigs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponseConfig(int id, ResponseConfig responseConfig)
        {
            if (id != responseConfig.ResponseId)
            {
                return BadRequest();
            }

            _context.Entry(responseConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseConfigExists(id))
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

        // POST: api/ResponseConfigs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseConfig>> PostResponseConfig(ResponseConfig responseConfig)
        {
            _context.ResponseConfigs.Add(responseConfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponseConfig", new { id = responseConfig.ResponseId }, responseConfig);
        }

        // DELETE: api/ResponseConfigs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponseConfig(int id)
        {
            var responseConfig = await _context.ResponseConfigs.FindAsync(id);
            if (responseConfig == null)
            {
                return NotFound();
            }

            _context.ResponseConfigs.Remove(responseConfig);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponseConfigExists(int id)
        {
            return _context.ResponseConfigs.Any(e => e.ResponseId == id);
        }
    }
}
