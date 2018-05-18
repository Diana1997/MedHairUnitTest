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
        public int CreateSetting(Setting setting)
        {
            db.Settings.Add(setting);
            db.SaveChanges();
            return setting.SettingID;
        }
        public void EditSetting(Setting setting)
        {
            db.Entry(setting).State = EntityState.Modified;
            db.Entry(setting.HairSizeSettings).State = EntityState.Modified;
            db.Entry(setting.StatisticalSettings).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteSetting(int id)
        {
            Setting setting = db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).FirstOrDefault(x => x.SettingID == id);
            db.HairSizeSettings.Remove(setting.HairSizeSettings);
            db.StatisticalSettings.Remove(setting.StatisticalSettings);
            db.Settings.Remove(setting);
            db.SaveChanges();
        }

        public Setting GetSetting(int id)
        {
            return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).AsNoTracking().FirstOrDefault(x => x.SettingID == id);
        }
        public IList<Setting> GetSetting()
        {
            return db.Settings.Include(s => s.HairSizeSettings).Include(s => s.StatisticalSettings).AsNoTracking().ToList();
        }
    }
}
