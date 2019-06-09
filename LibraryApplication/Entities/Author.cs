using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApplication.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Author Name")]
        public string FullName { get; set; }
    }
}