using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public string Remarks { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }



    }
}