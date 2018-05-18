using System;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Image
    {
        public int ImageID { set; get; }
        [Required]
        public DateTime CreatectionDateTime { set; get; }
		[MaxLength(100)]
        public string Title { set; get; }
        [Required]
        public byte[] ImageContent { set; get; }
    }
}
