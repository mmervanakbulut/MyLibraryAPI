using LibraryAPI.Models;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryAPI.Models.CreateModels;

namespace MyLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public LibraryDbContext _context;
        public AuthorController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(authors);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewAuthorAsync(AuthorCreate entity)
        {
            var author = new Author {
                Name = entity.Name,
                Surname = entity.Surname
            };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return Ok(author);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOneAuthorAsync(int id)
        {
            var author = await _context.Authors.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return Ok(author);
        }

    }
}
