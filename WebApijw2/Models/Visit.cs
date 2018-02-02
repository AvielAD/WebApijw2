using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int ReportId { get; set; }

        public virtual Report Report { get; set; }
        public virtual ICollection<VisitCategory> VisitCategories { get; set; }
        public virtual ICollection<Brochure> Brochures { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<Teatry> Teatries { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<UserVisited> UserVisiteds { get; set; }

    }
}