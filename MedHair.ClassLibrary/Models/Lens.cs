using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Lens
    {
        public int LensID { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        public int Scale { set; get; }
    }
}
