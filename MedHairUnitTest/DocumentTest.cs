using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MedHairUnitTest
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void DocumentTest1()
        {
            Document document;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);

                document = new Document
                {
                    Name = "Name",
                    Content = new byte[1] { 0 },
                };
                id = ctrl.CreateDocument(document);
                var documentRes = ctrl.GetDocument(id);

                Assert.IsNotNull(documentRes);
                Assert.AreEqual("Name", documentRes.Name);
                Assert.IsTrue(new byte[1] { 0 }.SequenceEqual(documentRes.Content));
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                document.DocumentId = id;
                document.Name = "NameName";

                ctrl.EditDocument(document);
                var documentRes = ctrl.GetDocument(id);

                Assert.IsNotNull(documentRes);
                Assert.AreEqual("NameName", documentRes.Name);
                Assert.IsTrue(new byte[1] { 0 }.SequenceEqual(documentRes.Content));
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteDocument(id);
                var documentRes = ctrl.GetDocument(id);
                Assert.IsNull(documentRes);
            }
        }
    }
}
