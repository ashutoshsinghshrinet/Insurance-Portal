using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsurancePortal.Data;
using InsurancePortal.Models;

namespace InsurancePortal.Areas.Manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Policies1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Policies1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Policies1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPollicies()
        {
            return await _context.Pollicies.ToListAsync();
        }

        // GET: api/Policies1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _context.Pollicies.FindAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // PUT: api/Policies1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/Policies1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            _context.Pollicies.Add(policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicy", new { id = policy.PolicyId }, policy);
        }

        // DELETE: api/Policies1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Policy>> DeletePolicy(int id)
        {
            var policy = await _context.Pollicies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _context.Pollicies.Remove(policy);
            await _context.SaveChangesAsync();

            return policy;
        }

        private bool PolicyExists(int id)
        {
            return _context.Pollicies.Any(e => e.PolicyId == id);
        }
    }
}
