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
    public class GenresController : ApiController
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetGenres()
        {
            var genres = _context.Genres.ToList();

            return Ok(genres);
        }

        [HttpGet]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IHttpActionResult CreateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genreUpdated = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreUpdated == null)
                return NotFound();

            genreUpdated.Name = genre.Name;
            _context.SaveChanges();

            return Ok(genreUpdated);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return NotFound();

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return Ok();
        }
    }
}
