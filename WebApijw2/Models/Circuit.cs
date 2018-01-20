using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Circuit
    {
        [Key]
        public int CircuitId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<UserVisited> UserVisiteds{ get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Congregation> Congregations { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }

    }
}