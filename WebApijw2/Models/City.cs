﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class City
    {

        [Key]
        public int CityId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Circuit> Circuits { get; set; }
        public virtual ICollection<UserVisited> UserVisiteds { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Congregation> Congregations { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }

    }
}