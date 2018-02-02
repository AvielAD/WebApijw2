using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class VisitCategory
    {
        [Key]
        public int VisitCategoryId { get; set; }

        public string Description { get; set; }

        [Required]
        public int VisitId { get; set; }

        public virtual Visit Visit { get; set; }

    }
}