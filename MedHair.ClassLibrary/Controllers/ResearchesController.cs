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
        public int CreateResearch(Research research)
        {
            db.Researches.Add(research);
            db.SaveChanges();
            return research.ResearchID;
        }
        public void EditResearch(Research research)
        {
            db.Entry(research).State = EntityState.Modified;
            db.Entry(research.Lens).State = EntityState.Modified;
            if(research.Diagnostic != null)
                db.Entry(research.Diagnostic).State = EntityState.Modified;
            db.Entry(research.Setting.HairSizeSettings).State = EntityState.Modified;
            db.Entry(research.Setting.StatisticalSettings).State = EntityState.Modified;
            db.Entry(research.Setting).State = EntityState.Modified;
            db.Entry(research.Image).State = EntityState.Modified;
            db.SaveChanges();

            //ToDo update documents collection
            //ToDo update Hairs collection

        }
        public void DeleteResearch(int id)
        {
            Research research = db.Researches
                .Include(d => d.Diagnostic)
                .Include(s => s.Setting.HairSizeSettings)
                .Include(s => s.Setting.StatisticalSettings)
                .Include(s => s.Setting)
                .Include(h => h.Hairs)
                .Include(i => i.Image)
                .Include(d => d.Documents)
                .Include(l => l.Lens)
                .FirstOrDefault(x => x.ResearchID == id);

            if (research.Diagnostic != null)
                db.Diagnostics.Remove(research.Diagnostic);
            db.HairSizeSettings.Remove(research.Setting.HairSizeSettings);
            db.StatisticalSettings.Remove(research.Setting.StatisticalSettings);
            db.Settings.Remove(research.Setting);
            db.Hairs.RemoveRange(research.Hairs);
            if(research.Documents.Count != 0)
                db.Documents.RemoveRange(research.Documents);
            db.Lenses.Remove(research.Lens);
            db.Images.Remove(research.Image);
            db.Researches.Remove(research);
            db.SaveChanges();
        }

        public Research GetResearch(int id)
        {
            return db.Researches
				.Include(d => d.Diagnostic)
				.Include(s => s.Setting.HairSizeSettings)
                .Include(s => s.Setting.StatisticalSettings)
                //.Include(s => s.Setting)
				.Include(h => h.Hairs)
				.Include(d => d.Documents)
				.Include(l => l.Lens)
				.AsNoTracking().FirstOrDefault(x => x.ResearchID == id);
        }
        public IList<Research> GetResearches()
        {
            return db.Researches
				.Include(d => d.Diagnostic)
				.Include(s => s.Setting)
				.Include(h => h.Hairs)
				.Include(d => d.Documents)
				.Include(l => l.Lens)
				.AsNoTracking().ToList();
        }
    }
}
