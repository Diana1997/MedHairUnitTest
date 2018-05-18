using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class StatisticalSettings
    {
        public int StatisticalSettingsID { set; get; }
        [Required]
        public int AnagenAll { set; get; }
        [Required]
        public int TelogenAll { set; get; }
        [Required]
        public int AnagenTerm { set; get; }
        [Required]
        public int TelogenTerm { set; get; }
        [Required]
        public int AnagenVallus { set; get; }
        [Required]
        public int TelogenVallus { set; get; }
    }
}
