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
        public int CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserID;
        }
        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.Entry(user.Contact).State = EntityState.Modified;

            if (user.Lens != null)
                db.Entry(user.Lens).State = EntityState.Modified;
            if (user.Setting != null)
            {
                db.Entry(user.Setting.HairSizeSettings).State = EntityState.Modified;
                db.Entry(user.Setting.StatisticalSettings).State = EntityState.Modified;
                db.Entry(user.Setting).State = EntityState.Modified;
            }
            db.SaveChanges();

            //ToDo update ReportTemplate collection

        }

        public void DeleteUser(int id)
        {
            User user = db.Users
                .Include(l => l.Lens)
                .Include(u => u.Contact)
                .Include(s => s.Setting.HairSizeSettings)
                .Include(s => s.Setting.StatisticalSettings)
                .Include(s => s.Setting)
                .Include(s => s.ReportTemplates.Select(x => x.Pictures))
                .Include(t => t.ReportTemplates.Select(y => y.ReportFields.Select(x => x.FieldOption)))
                .Include(s => s.ReportTemplates.Select(x => x.FieldTypes))
                .FirstOrDefault(x => x.UserID == id);

            db.Contacts.Remove(user.Contact);
            if (db.Lenses != null)
                db.Lenses.Remove(user.Lens);
            if (db.Settings != null)
            {
              //  DeleteSetting(user.Setting.SettingID);
                db.HairSizeSettings.Remove(user.Setting.HairSizeSettings);
                db.StatisticalSettings.Remove(user.Setting.StatisticalSettings);
                db.Settings.Remove(user.Setting);
            }
            
            foreach (var item in user.ReportTemplates)
            {
                //DeleteReportTemplate(item.ReportTemplateId);

                db.Pictures.RemoveRange(item.Pictures);
                db.C_FieldTypes.RemoveRange(item.FieldTypes);
                foreach (var elem in item.ReportFields)
                    db.FieldOptions.Remove(elem.FieldOption);
                db.ReportFields.RemoveRange(item.ReportFields);
            }
            //db.ReportTemplates.RemoveRange(user.ReportTemplates);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public User GetUser(int id)
        {
            return db.Users
                .Include(l => l.Lens)
                .Include(s => s.Setting.HairSizeSettings)
                .Include(s => s.Setting.StatisticalSettings)
                .Include(u => u.Contact)
                .Include(t => t.ReportTemplates.Select(y => y.Pictures))
                .Include(t => t.ReportTemplates.Select(y => y.ReportFields.Select(x => x.FieldOption)))
                .Include(t => t.ReportTemplates.Select(y => y.FieldTypes))
                .AsNoTracking()
                .FirstOrDefault(x => x.UserID == id);
        }
        public IList<User> GetUser()
        {
            return db.Users
                    .Include(l => l.Lens)
                    .Include(s => s.Setting.HairSizeSettings)
                    .Include(s => s.Setting.StatisticalSettings)
                    .Include(u => u.Contact)
                    .Include(t => t.ReportTemplates.Select(y => y.Pictures))
                    .Include(t => t.ReportTemplates.Select(y => y.ReportFields.Select(x => x.FieldOption)))
                    .Include(t => t.ReportTemplates.Select(y => y.FieldTypes))
                    .AsNoTracking().ToList();
        }
    }
}
