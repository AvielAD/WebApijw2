﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int VisitId { get; set; }

        [Required]
        public int EditorialId { get; set; }

        public virtual Editorial Editorial { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

    }
}