using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class HairSizeSettings
    {
        public int HairSizeSettingsId { set; get; }
        [Required]
        public int LengthOfTelogenHair { set; get; }
        [Required]
        public int DiameterOfVelusTerminal { set; get; }
        [Required]
        public int DiameterOfTerminalsThinMedium { set; get; }
        [Required]
        public int DiameterOfTerminalsMediumThick { set; get; }
        [Required]
        public int RadiusOfFollicularUnits { set; get; }
    }
}
