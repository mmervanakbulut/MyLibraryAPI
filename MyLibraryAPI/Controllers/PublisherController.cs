using LibraryAPI.Models;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryAPI.Models.CreateModels;

namespace MyLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public LibraryDbContext _context;
        public PublisherController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishersAsync()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return Ok(publishers);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewPublisherAsync(PublisherCreate entity)
        {
            var publisher = new Publisher
            {
                Name = entity.Name,
            };
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return Ok(publisher);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOnePublisherAsync(int id)
        {
            var publisher = await _context.Publishers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return Ok(publisher);
        }
    }
}
