using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }



    }
}