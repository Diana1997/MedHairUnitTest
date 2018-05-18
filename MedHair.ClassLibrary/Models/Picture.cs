using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Picture
    {
        public int PictureID { set; get; }
        [Required]
        public bool Selected { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public byte[] Data { set; get; }
    }
}
