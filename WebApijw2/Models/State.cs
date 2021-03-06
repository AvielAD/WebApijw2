﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        public string Description { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Congregation> Congregations { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }

    }
}