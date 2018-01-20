using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class UserVisited
    {
        [Key]
        public int UserVisitedId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public int CircuitId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int VisitId { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual Circuit Circuit { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }


    }
}