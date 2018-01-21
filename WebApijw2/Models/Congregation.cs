using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Congregation
    {
        [Key]
        public int CongregationId { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        [Required]
        public int CircuitId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual Circuit Circuit { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }


    }
}