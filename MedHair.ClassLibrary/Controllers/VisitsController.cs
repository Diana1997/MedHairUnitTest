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
		public int CreateVisit(Visit visit)
		{
			db.Visits.Add(visit);
			db.SaveChanges();
			return visit.VisitID;
		}
        public void EditVisit(Visit visit)
        {
            
            db.Entry(visit.Research).State = EntityState.Modified;
            db.Entry(visit).State = EntityState.Modified;
            db.SaveChanges();

            //ToDo update CommentOnTheVisits collection
            //ToDo update Documents collection

            //ToDo Research update

            //if (db.CommentOnTheVisits.Where(x => x.VisitID == null).ToList().Count > 0)
            //{
            //    db.CommentOnTheVisits.RemoveRange(db.CommentOnTheVisits.Where(x => x.VisitID == null).ToList());
            //    db.SaveChanges();
            //}
        }
        public void DeleteVisit(int id)
		{
            Visit visit = db.Visits
                .Include(x => x.CommentOnTheVisits)
                .Include(x => x.Documents)
                .Include(x => x.Research)
                .Include(x => x.Research.Image)
                .Include(x => x.Research.Hairs)
                .Include(x => x.Research.Diagnostic)
                .Include(x => x.Research.Setting.StatisticalSettings)
                .Include(x => x.Research.Setting.HairSizeSettings)
                .Include(x => x.Research.Documents)
                .Include(x => x.Research.Lens)
                .Include(x => x.Documents)
                .FirstOrDefault(x => x.VisitID == id);

            if (visit.CommentOnTheVisits.Count != 0)
                db.CommentOnTheVisits.RemoveRange(visit.CommentOnTheVisits);
            if (visit.Documents.Count != 0)
                db.Documents.RemoveRange(visit.Documents);

            db.Images.Remove(visit.Research.Image);
            db.Hairs.RemoveRange(visit.Research.Hairs);
            if (visit.Research.Diagnostic != null)
                db.Diagnostics.Remove(visit.Research.Diagnostic);
            db.Lenses.Remove(visit.Research.Lens);
            db.StatisticalSettings.Remove(visit.Research.Setting.StatisticalSettings);
            db.HairSizeSettings.Remove(visit.Research.Setting.HairSizeSettings);
            db.Settings.Remove(visit.Research.Setting);

            if (visit.Research.Documents.Count != 0)
                db.Documents.RemoveRange(visit.Research.Documents);
            db.Researches.Remove(visit.Research);
            db.Visits.Remove(visit);
            db.SaveChanges();
        }
		public Visit GetVisit(int id)
		{
			return db.Visits
				.Include(v => v.User.Contact)
                .Include(v => v.User.Setting.StatisticalSettings)
                .Include(v => v.User.Setting.HairSizeSettings)
                .Include(v => v.User.Lens)
                .Include(s => s.User.ReportTemplates.Select(x => x.Pictures))
                .Include(t => t.User.ReportTemplates.Select(y => y.ReportFields.Select(x => x.FieldOption)))
                .Include(s => s.User.ReportTemplates.Select(x => x.FieldTypes))
                .Include(x => x.CommentOnTheVisits)
				.Include(x => x.Documents)
                .AsNoTracking()
				.FirstOrDefault(x => x.VisitID == id);
		}
		public IList<Visit> GetVisit()
		{
			return db.Visits
                .Include(v => v.User.Contact)
                .Include(v => v.User.Setting.StatisticalSettings)
                .Include(v => v.User.Setting.HairSizeSettings)
                .Include(v => v.User.Lens)
                .Include(s => s.User.ReportTemplates.Select(x => x.Pictures))
                .Include(t => t.User.ReportTemplates.Select(y => y.ReportFields.Select(x => x.FieldOption)))
                .Include(s => s.User.ReportTemplates.Select(x => x.FieldTypes))
                .Include(x => x.CommentOnTheVisits)
                .Include(x => x.Documents)
                .AsNoTracking()
				.ToList();
		}
	}
}
