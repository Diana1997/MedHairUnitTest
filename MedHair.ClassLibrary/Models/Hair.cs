using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary.Models
{
    public class Hair
    {
        public int HairID { set; get; }
        [Required]
        public int Width { set; get; }
        [Required]
        public int X1 { set; get; }
        [Required]
        public int X2 { set; get; }
        [Required]
        public int Y1 { set; get; }
        [Required]
        public int Y2 { set; get; }
    }
}
