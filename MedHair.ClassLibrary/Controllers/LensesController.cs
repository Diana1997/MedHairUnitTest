using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateLens(Lens lens)
        {
            db.Lenses.Add(lens);
            db.SaveChanges();
            return lens.LensID;
        }
        public void EditLens(Lens lens)
        {
            db.Entry(lens).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteLens(int id)
        {
            Lens lens = db.Lenses.Find(id);
            db.Lenses.Remove(lens);
            db.SaveChanges();
        }
        public Lens GetLens(int id)
        {
            return db.Lenses.AsNoTracking().FirstOrDefault(x => x.LensID == id);
        }
        public IList<Lens> GetLens()
        {
            return db.Lenses.AsNoTracking().ToList();
        }
    }
}
