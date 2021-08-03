using BookSCrud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksCrud.Models
{
    public class BooksViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(128)]
        public string Author { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        public IList<Category>  Categories { get; set; }
    }
}