using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary.Models
{
    public class Setting
    {
        public int SettingID { set; get; }
        [Required]
        public HairSizeSettings HairSizeSettings { set; get; }
        [Required]
        public StatisticalSettings StatisticalSettings { set; get; }
    }
}
