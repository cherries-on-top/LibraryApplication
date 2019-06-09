using LibraryApplication.Entities;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Genres
        public ActionResult Index()
        {
            var genres = _context.Genres.ToList();

            return View(genres);
        }

        public ActionResult Create()
        {
            Genre newGenre = new Genre();
            return View("GenreForm", newGenre);
        }

        // GET: Genre
        public ActionResult Edit(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return HttpNotFound();

            return View("GenreForm", genre);
        }
        
        public ActionResult Save(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View("GenreForm");
            }

            var genreAlreadyExists = _context.Genres.Any(g => g.Name == genre.Name);
            if (genreAlreadyExists)
            {
                ModelState.AddModelError("Name", "Genre with this name already exists in database.");
                return View("GenreForm");
            }

            if (genre.Id == 0)
            {              
                _context.Genres.Add(genre);
            }
            else
            {
                var genreUpdated = _context.Genres.Single(g => g.Id == genre.Id);

                genreUpdated.Name = genre.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        public ActionResult Delete(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return HttpNotFound();

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }
    }
}