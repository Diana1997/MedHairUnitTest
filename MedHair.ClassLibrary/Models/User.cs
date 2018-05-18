using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHair.ClassLibrary.Models
{
	public class User
	{
		public int UserID { set; get; }
		[Required]
		[MaxLength(50)]
		public string Login { set; get; }
		[Required]
		[MaxLength(256)]
		public byte[] Password { set; get; }
		[Required]
		public DateTime LastLoginTime { set; get; }
        public Lens Lens { set; get; }
        public ResearchArea ResearchArea { set; get; }
        public Setting Setting { set; get; }
        [Required]
        public Contact Contact { set; get; }
        public ICollection<ReportTemplate> ReportTemplates { set; get; }
    }
}
