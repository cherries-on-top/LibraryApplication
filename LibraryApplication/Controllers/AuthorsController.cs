using LibraryApplication.Entities;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Authors
        public ActionResult Index()
        {
            var authors = _context.Authors.ToList();

            return View(authors);
        }

        public ActionResult Create()
        {
            Author newAuthor = new Author();
            return View("AuthorForm", newAuthor);
        }

        // GET: Author
        public ActionResult Edit(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
                return HttpNotFound();

            return View("AuthorForm", author);
        }
        
        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View("AuthorForm");
            }

            var authorAlreadyExists = _context.Authors.Any(a => a.FullName == author.FullName);
            if (authorAlreadyExists)
            {
                ModelState.AddModelError("FullName", "Author with this name already exists in database.");
                return View("AuthorForm");
            }

            if (author.Id == 0)
            {
                _context.Authors.Add(author);
            }
            else
            {
                var authorUpdated = _context.Authors.Single(a => a.Id == author.Id);

                authorUpdated.FullName = author.FullName;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Authors");
        }

        public ActionResult Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
                return HttpNotFound();

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return RedirectToAction("Index", "Authors");
        }
    }

    }
