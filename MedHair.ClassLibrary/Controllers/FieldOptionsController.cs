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
        public int CreateFieldOption(FieldOption fieldOption)
        {
            db.FieldOptions.Add(fieldOption);
            db.SaveChanges();
            return fieldOption.FieldOptionID;
        }
        public void EditFieldOption(FieldOption fieldOption)
        {
            db.Entry(fieldOption).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteFieldOption(int id)
        {

            FieldOption fieldOption = db.FieldOptions.Find(id);
            db.FieldOptions.Remove(fieldOption);
            db.SaveChanges();

        }
        public FieldOption GetFieldOption(int id)
        {
            return db.FieldOptions.AsNoTracking().FirstOrDefault(x => x.FieldOptionID == id);
        }
        public IList<FieldOption> GetFieldOption()
        {
            return db.FieldOptions.AsNoTracking().ToList();
        }
    }
}
