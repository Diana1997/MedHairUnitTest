using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
    public partial class MedHairController
    {
        public int CreateReportField(ReportField reportField)
        {
            db.ReportFields.Add(reportField);
            db.SaveChanges();
            return reportField.ReportFieldID;
        }
        public void EditReportField(ReportField reportField)
        {
            db.Entry(reportField).State = EntityState.Modified;
            db.Entry(reportField.FieldOption).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteReportField(int id)
        {
            ReportField reportField = db.ReportFields.Include(r => r.FieldOption).FirstOrDefault(x => x.ReportFieldID == id);
            db.FieldOptions.Remove(reportField.FieldOption);
            db.ReportFields.Remove(reportField);
            db.SaveChanges();
        }
        public ReportField GetReportField(int id)
        {
            return db.ReportFields.Include(r => r.FieldOption).AsNoTracking().FirstOrDefault(x => x.ReportFieldID == id);
        }
        public IList<ReportField> GetReportField()
        {
            return db.ReportFields.Include(r => r.FieldOption).AsNoTracking().ToList();
        }
    }
}
