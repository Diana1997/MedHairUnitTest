using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Patient
    {
        public int PatientID { set; get; }
        [Required]
        public int CardNumber { set; get; }
        [Required]
        public Contact Contact { set; get; }
        [Required]
        public PatientStatus PatientStatus { set; get; }
        [Required]
        public DateTime CreationDate { set; get; }
		[MaxLength(2000)]
        public string Comment { set; get; }
        public virtual ICollection<Image> Images { set; get; }
        public DateTime? DateTimeNextVisit { set; get; }
    }
}
