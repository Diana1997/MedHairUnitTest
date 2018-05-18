using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateHairSizeSettings(HairSizeSettings hairSizeSettings)
        {
            db.HairSizeSettings.Add(hairSizeSettings);
            db.SaveChanges();
            return hairSizeSettings.HairSizeSettingsId;
        }

        public void EditHairSizeSettings(HairSizeSettings hairSizeSettings)
        {
            db.Entry(hairSizeSettings).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteHairSizeSettings(int id)
        {
            HairSizeSettings hairSizeSettings = db.HairSizeSettings.Find(id);
            db.HairSizeSettings.Remove(hairSizeSettings);
            db.SaveChanges();
        }
        public HairSizeSettings GetHairSizeSettings(int id)
        {
            return db.HairSizeSettings.AsNoTracking().FirstOrDefault(x => x.HairSizeSettingsId == id);
        }
        public IList<HairSizeSettings> GetHairSizeSettings()
        {
            return db.HairSizeSettings.AsNoTracking().ToList();
        }
    }
}
