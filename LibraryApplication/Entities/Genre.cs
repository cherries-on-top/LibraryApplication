using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApplication.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}