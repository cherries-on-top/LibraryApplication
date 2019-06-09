using LibraryApplication.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApplication.ViewModels;
using LibraryApplication.Entities;

namespace LibraryApplication.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).Include(b => b.Author).ToList();

            return View(books);
        }

        public ActionResult Create()
        {
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel()
            {
                Authors = authors,
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        // GET: Book
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BookFormViewModel()
            {
                Name = book.Name,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Authors = _context.Authors.ToList(),
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);
        }
        
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Name = book.Name,
                    AuthorId = book.AuthorId,
                    GenreId = book.GenreId,
                    Authors = _context.Authors.ToList(),
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            if(book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var bookUpdated = _context.Books.Single(b => b.Id == book.Id);

                bookUpdated.Name = book.Name;
                bookUpdated.AuthorId = book.AuthorId;
                bookUpdated.GenreId = book.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if(book == null)            
                return HttpNotFound();           

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
    }
}