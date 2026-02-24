using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootwearInventory.Api.Data;
using FootwearInventory.Api.Models;

namespace FootwearInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootwearController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FootwearController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footwear>>> GetAll()
        {
            return await _context.Footwears.ToListAsync();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Footwear>> GetById(int id)
        {
            var item = await _context.Footwears.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult<Footwear>> Create(Footwear footwear)
        {
            _context.Footwears.Add(footwear);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = footwear.Id }, footwear);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Footwear footwear)
        {
            if (id != footwear.Id) return BadRequest();

            _context.Entry(footwear).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Footwears.FindAsync(id);
            if (item == null) return NotFound();

            _context.Footwears.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}