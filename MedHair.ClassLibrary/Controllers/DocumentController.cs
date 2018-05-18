using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateDocument(Document document)
        {
            db.Documents.Add(document);
            db.SaveChanges();
            return document.DocumentId;
        }
        public void EditDocument(Document document)
        {
            db.Entry(document).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteDocument(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
        }
        public Document GetDocument(int id)
        {
            return db.Documents.AsNoTracking().FirstOrDefault(x => x.DocumentId == id);
        }
        public IList<Document> GetDocument()
        {
            return db.Documents.AsNoTracking().ToList();
        }
    }
}
