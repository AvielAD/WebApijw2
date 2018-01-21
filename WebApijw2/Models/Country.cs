using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Country
    {

        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<UserVisited> UserVisiteds { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Congregation> Congregations { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }


    }
}