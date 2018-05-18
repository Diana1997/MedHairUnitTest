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
        public int CreateDiagnostic(Diagnostic diagnostic)
        {
            db.Diagnostics.Add(diagnostic);
            db.SaveChanges();
            return diagnostic.DiagnosticID;
        }
        public void EditDiagnostic(Diagnostic diagnostic)
        {

            db.Entry(diagnostic).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void DeleteDiagnostic(int id)
        {

            Diagnostic diagnostic = db.Diagnostics.Find(id);
            db.Diagnostics.Remove(diagnostic);
            db.SaveChanges();

        }
        public Diagnostic GetDiagnostic(int id)
        {
            return db.Diagnostics.AsNoTracking().FirstOrDefault(x => x.DiagnosticID == id);

        }
        public IList<Diagnostic> GetDiagnostic()
        {
            return db.Diagnostics.AsNoTracking().ToList();
        }
    }
}
