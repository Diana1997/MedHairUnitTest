using MedHair.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary.Controllers
{
    public partial class MedHairController
    {
        public int CreateImage(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
            return image.ImageID;
        }
        public void EditImage(Image image)
        {
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
        }

        public Image GetImage(int id)
        {
            return db.Images.AsNoTracking().FirstOrDefault(x => x.ImageID == id);
        }
        public IList<Image> GetImage()
        {
            return db.Images.AsNoTracking().ToList();
        }
    }
}
