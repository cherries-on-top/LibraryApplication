using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApplication.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}