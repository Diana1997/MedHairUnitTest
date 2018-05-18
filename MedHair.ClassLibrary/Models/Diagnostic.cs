using System;
using System.ComponentModel.DataAnnotations;


namespace MedHair.ClassLibrary.Models
{
	public class Diagnostic
    {
        public int DiagnosticID { set; get; }
        [Required]
        [MaxLength(2000)]
        public string DiagnosticText { set; get; }
        [Required]
        public DateTime CreationDate { set; get; }
        [Required]
        public DateTime DateOfLastConfirmation { set; get; }
		[MaxLength(1000)]
        public string Comment { set; get; }
    }
}
