using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreateCommentOnTheVisit(CommentOnTheVisit commentOnTheVisit)
        {
            db.CommentOnTheVisits.Add(commentOnTheVisit);
            db.SaveChanges();
            return commentOnTheVisit.CommentOnTheVisitID;
        }
        public void EditCommentOnTheVisit(CommentOnTheVisit commentOnTheVisit)
        {
            db.Entry(commentOnTheVisit).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCommentOnTheVisit(int id)
        {
            CommentOnTheVisit commentOnTheVisit = db.CommentOnTheVisits.Find(id);
            db.CommentOnTheVisits.Remove(commentOnTheVisit);
            db.SaveChanges();
        }
        public CommentOnTheVisit GetCommentOnTheVisit(int id)
        {
            return db.CommentOnTheVisits.AsNoTracking().FirstOrDefault(x => x.CommentOnTheVisitID == id);
        }
        public IList<CommentOnTheVisit> GetCommentOnTheVisit()
        {
            return db.CommentOnTheVisits.AsNoTracking().ToList();
        }
    }
}
