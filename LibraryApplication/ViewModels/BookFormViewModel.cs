using LibraryApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApplication.ViewModels
{
    public class BookFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            AuthorId = book.AuthorId;
            GenreId = book.GenreId;
        }
    }
}