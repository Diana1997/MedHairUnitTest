using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class CommentOnTheVisit
    {
        public int CommentOnTheVisitID { set; get; }
        [Required]
        public TypeOfComment TypeOfComment { set; get; }
        [Required]
        [MaxLength(2000)]
        public string Comment { set; get; }
        //public int? VisitID { set; get; }
    }
}
