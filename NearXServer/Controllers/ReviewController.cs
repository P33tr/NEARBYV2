using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NearXServer.Data;
using NearXShared.Models;

namespace NearXServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly MariaDbContext _context;

        public ReviewController(MariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reviews = await _context.Reviews.ToListAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return Ok(review.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = new Review { Id = id };
            _context.Remove(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
