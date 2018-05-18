using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Visit
    {
        public int VisitID { set; get; }
        [Required]
        public User User { set; get; }
        [Required]
        public virtual Patient Patient { set; get; }
        [Required]
        public DateTime DateTime { set; get; }
        public ICollection<CommentOnTheVisit> CommentOnTheVisits { set; get; }
        [Required]
        public virtual Research Research { set; get; }
        public ICollection<Document> Documents { set; get; } 
    }
}
