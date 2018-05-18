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
        public int CreatePicture(Picture picture)
        {
            db.Pictures.Add(picture);
            db.SaveChanges();
            return picture.PictureID;
        }
        public void EditPicture(Picture picture)
        {

            db.Entry(picture).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeletePicture(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
        }
        public Picture GetPicture(int id)
        {
            return db.Pictures.AsNoTracking().FirstOrDefault(x => x.PictureID == id);
        }
        public IList<Picture> GetPicture()
        {
            return db.Pictures.AsNoTracking().ToList();
        }
    }
}
