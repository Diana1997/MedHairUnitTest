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
        public int CreateHair(Hair hair)
        {
            db.Hairs.Add(hair);
            db.SaveChanges();
            return hair.HairID;
        }
        public void EditHair(Hair hair)
        {
            db.Entry(hair).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteHair(int id)
        {
            Hair hair = db.Hairs.Find(id);
            db.Hairs.Remove(hair);
            db.SaveChanges();
        }
        public Hair GetHair(int id)
        {
            return db.Hairs.AsNoTracking().FirstOrDefault(x => x.HairID == id);
        }
        public IList<Hair> GetHair()
        {
            return db.Hairs.AsNoTracking().ToList();
        }
    }
}
