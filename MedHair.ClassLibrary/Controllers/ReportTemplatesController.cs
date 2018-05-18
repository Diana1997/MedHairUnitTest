using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateReportTemplate(ReportTemplate reportTemplate)
        {
            db.ReportTemplates.Add(reportTemplate);
            db.SaveChanges();
            return reportTemplate.ReportTemplateId;
        }
        public void EditReportTemplate(ReportTemplate reportTemplate)
        {
            db.Entry(reportTemplate).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteReportTemplate(int id)
        {
            ReportTemplate reportTemplate = db.ReportTemplates
                .Include(p => p.Pictures)
                .Include(f => f.FieldTypes)
                .Include(r => r.ReportFields.Select(y => y.FieldOption))
                .FirstOrDefault(x => x.ReportTemplateId == id);

            db.C_FieldTypes.RemoveRange(reportTemplate.FieldTypes);
            db.Pictures.RemoveRange(reportTemplate.Pictures);
            foreach (var elem in reportTemplate.ReportFields)
                db.FieldOptions.Remove(elem.FieldOption);
            db.ReportFields.RemoveRange(reportTemplate.ReportFields);
            db.ReportTemplates.Remove(reportTemplate);
            db.SaveChanges();
        }
        public ReportTemplate GetReportTemplate(int id)
        {
            return db.ReportTemplates
				.Include(p=>p.Pictures)
				.Include(f => f.FieldTypes)
				.Include(r => r.ReportFields.Select(y => y.FieldOption))
				.AsNoTracking().FirstOrDefault(x => x.ReportTemplateId == id);
        }
        public IList<ReportTemplate> GetReportTemplate()
        {
            return db.ReportTemplates
				.Include(p => p.Pictures)
				.Include(f => f.FieldTypes)
				.Include(r => r.ReportFields.Select(y => y.FieldOption))
				.AsNoTracking().ToList();
        }
    }
}
