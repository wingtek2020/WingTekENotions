using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekENotions.API.Data;

namespace TekENotions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatternsController : ControllerBase
    {
        private readonly TekENotionsContext _context;

        public PatternsController(TekENotionsContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task <IActionResult> GetPatterns()
        {
            var patterns = await _context.InspiredPatterns.ToListAsync();
            return Ok(patterns);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatterns(int id)
        {
            var patterns = await _context.InspiredPatterns
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(patterns);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
