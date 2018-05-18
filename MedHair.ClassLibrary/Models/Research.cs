using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Research
    {
        public int ResearchID { set; get; }
        [Required]
        public ResearchType ResearchType { set; get; }
        [Required]
        public StateOfTheResearch StateOfTheResearch { set; get; }
        [Required]
        public byte[] Thumbnail { set; get; }
		[Required]
		public virtual Image Image { set; get; }
        [Required]
        public ICollection<Hair> Hairs { set; get; }
        [Required]
        public ResearchArea ResearchArea { set; get; }
		[MaxLength(2000)]
        public string Comment { set; get; }
		[Required]
		public DateTime ResearchDateTime { set; get; }
        public Diagnostic Diagnostic { set; get; }
		[MaxLength(2000)]
        public string Treatment { set; get; }
        [Required]
        public Setting Setting { set; get; }
        [Required]
        public Lens Lens { set; get; }
        public ICollection<Document> Documents { set; get; }
	}
}
