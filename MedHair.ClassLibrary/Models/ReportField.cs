using System.ComponentModel.DataAnnotations;


namespace MedHair.ClassLibrary.Models
{
    public class ReportField
    {
        public int ReportFieldID { set; get; }
        [Required]
		[MaxLength(1000)]
        public string Name { set; get; }
        [Required]
        public FieldType FieldType { set; get; }
        [Required]
        public FieldOption FieldOption { set; get; }
    }
}
