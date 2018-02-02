using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int BrochureId { get; set; }

        [Required]
        public int MagazineId { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        public int TeatryId { get; set; }

        [Required]
        public int EditorialId { get; set; }

    }
}