using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Document
    {
        public int DocumentId { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public byte[] Content { set; get; }
    }
}
