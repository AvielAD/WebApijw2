﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int VisitId { get; set; }

    }
}