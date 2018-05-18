using MedHair.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary.Controllers
{
    public partial class MedHairController
    {
        ApplicationDbContext db { get; set; }
        public MedHairController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
    }
}
