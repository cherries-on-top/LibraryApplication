using LibraryApplication.Entities;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace LibraryApplication.Controllers.API
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            var books = _context.Books.Include(b => b.Genre).Include(b => b.Author).ToList();

            return Ok(books);
        }

        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.Include(b => b.Genre).Include(b => b.Author).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookUpdated = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookUpdated == null)
            {
                return NotFound();
            }

            bookUpdated.Name = book.Name;
            bookUpdated.GenreId = book.GenreId;
            bookUpdated.AuthorId = book.AuthorId;
            _context.SaveChanges();

            return Ok(bookUpdated);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok();
        }
    }
}
