using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MedHairUnitTest
{
    [TestClass]
    public class CommentOnTheVisitTest
    {
        [TestMethod]
        public void CommentOnTheVisitTest1()
        {
            CommentOnTheVisit commentOnTheVisit;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                commentOnTheVisit = new CommentOnTheVisit()
                {
                     Comment = "Comment",
                     TypeOfComment = TypeOfComment.AdministratoroTheDoctor,
                };
                id = ctrl.CreateCommentOnTheVisit(commentOnTheVisit);
                var commentOnTheVisitRes = ctrl.GetCommentOnTheVisit(id);
                Assert.IsNotNull(commentOnTheVisitRes);
                Assert.AreEqual("Comment", commentOnTheVisitRes.Comment);
                Assert.AreEqual(TypeOfComment.AdministratoroTheDoctor, commentOnTheVisitRes.TypeOfComment);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                commentOnTheVisit.CommentOnTheVisitID = id;
                commentOnTheVisit.Comment = "Comment1";
                ctrl.EditCommentOnTheVisit(commentOnTheVisit);
                var commentOnTheVisitRes = ctrl.GetCommentOnTheVisit(id);
                Assert.IsNotNull(commentOnTheVisitRes);
                Assert.AreEqual("Comment1", commentOnTheVisitRes.Comment);
                Assert.AreEqual(TypeOfComment.AdministratoroTheDoctor, commentOnTheVisitRes.TypeOfComment);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteCommentOnTheVisit(commentOnTheVisit.CommentOnTheVisitID);
                var commentOnTheVisitRes = ctrl.GetCommentOnTheVisit(id);
                Assert.IsNull(commentOnTheVisitRes);
            }
        }
    }
}
