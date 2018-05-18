using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class ReportTemplate
    {
       public int  ReportTemplateId { set; get; }
        [Required]
        public ICollection<Picture> Pictures { set; get; }
        [Required]
        public ICollection<C_FieldType> FieldTypes { set; get; }
        [Required]
        public ICollection<ReportField>  ReportFields { set; get; }

    }
}
