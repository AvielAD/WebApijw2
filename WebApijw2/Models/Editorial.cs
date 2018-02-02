using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Editorial
    {
        [Key]
        public int MyProperty { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Brochure> Brochures { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Teatry> Teatries { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}