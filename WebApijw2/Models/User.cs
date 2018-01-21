using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Sex { get; set; }

        public string Address { get; set; }

        [Required]
        public int CircuitId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CongregationId { get; set; }

        [Required]
        public int StateId { get; set; }

        public virtual Congregation Congregation { get; set; }

        public virtual Circuit Circuit { get; set; }

        public virtual City City { get; set; }

        public virtual State State { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

    }
}