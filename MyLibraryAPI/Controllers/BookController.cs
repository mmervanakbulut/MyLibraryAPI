﻿using LibraryAPI.Models;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryAPI.Models.CreateModels;

namespace MyLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController: ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Publishers)
                .Include(b => b.Authors)
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Description,
                    b.PageNumber,
                    AuthorsName = b.Authors.Name,
                    AuthorsSurname = b.Authors.Surname,
                    PublisherName = b.Publishers.Name
                }).ToListAsync();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBookAsync(BookCreate newBook)
        {
            var book = new Book
            {
                Title = newBook.Title,
                Description = newBook.Description,
                PageNumber = newBook.PageNumber,
                PublisherId = newBook.PublisherId,
                AuthorId = newBook.AuthorId,
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Ok(book);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateOneBookAsync(int id, BookCreate bookCreate)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id.Equals(id));
            book.Title = bookCreate.Title;
            book.Description = bookCreate.Description;
            book.PageNumber = bookCreate.PageNumber;
            book.PublisherId = bookCreate.PublisherId;
            book.AuthorId = bookCreate.AuthorId;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOneBookAsync(int id)
        {
            var book = await _context.Books.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
