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
        public int CreateStatisticalSettings(StatisticalSettings statisticalSettings)
        {
            db.StatisticalSettings.Add(statisticalSettings);
            db.SaveChanges();
            return statisticalSettings.StatisticalSettingsID;
        }
        public void EditStatisticalSettings(StatisticalSettings statisticalSettings)
        {
            db.Entry(statisticalSettings).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStatisticalSettings(int id)
        {
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            db.StatisticalSettings.Remove(statisticalSettings);
            db.SaveChanges();
        }
        public StatisticalSettings GetStatisticalSettings(int id)
        {
            return db.StatisticalSettings.AsNoTracking().FirstOrDefault(x => x.StatisticalSettingsID == id);
        }
        public IList<StatisticalSettings> GetStatisticalSettings()
        {
            return db.StatisticalSettings.AsNoTracking().ToList();
        }
    }
}
