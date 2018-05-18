using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary.Models
{
    public class FieldOption
    {
        public int FieldOptionID { set; get; }
		[MaxLength(100)]
        public string Title { set; get; }
        public bool? Selected { set; get; }
		[MaxLength(2000)]
		public string Text { set; get; }

    }
}
