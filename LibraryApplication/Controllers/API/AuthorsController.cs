using LibraryApplication.Entities;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryApplication.Controllers.API
{
    public class AuthorsController : ApiController
    {
        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            var authors = _context.Authors.ToList();

            return Ok(authors);
        }

        [HttpGet]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult CreateAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Authors.Add(author);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorUpdated = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (authorUpdated == null)
                return NotFound();

            authorUpdated.FullName = author.FullName;
            _context.SaveChanges();

            return Ok(authorUpdated);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
                return NotFound();

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return Ok();

        }
    }
}
