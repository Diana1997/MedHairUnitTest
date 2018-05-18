using System;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class Contact
    {
        public int ContactID { set; get; }
        [Required]
        [MaxLength(100)]
        public string Firstname { set; get; }
        [Required]
        [MaxLength(100)]
        public string Secondname { set; get; }
        [Required]
        [MaxLength(100)]
        public string Lastname { set; get; }
        [Required]
        public Gender Gender { set; get; }
        [Required]
        public DateTime Birthday { set; get; }
		[MaxLength(50)]
        public string Phone { set; get; }
		[MaxLength(100)]
		public string Email { set; get; }
		[MaxLength(300)]
		public string Address { set; get; }
		[MaxLength(100)]
		public string Position { set; get; }
		[MaxLength(100)]
		public string Specialty { set; get; }
		[MaxLength(100)]
		public string Education { set; get; }
		[MaxLength(1000)]
		public string Comment { set; get; }
		[MaxLength(100)]
		public string Degree { set; get; }
    }
}
