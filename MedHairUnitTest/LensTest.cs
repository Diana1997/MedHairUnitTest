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
    public class LensTest
    {
        [TestMethod]
        public void LensTest1()
        {
            Lens lens;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                lens = new Lens()
                {
                    Name = "name",
                    Scale = 1
                };

                id = ctrl.CreateLens(lens);
                var lensRes = ctrl.GetLens(id);
                Assert.IsNotNull(lensRes);
                Assert.AreEqual("name", lensRes.Name);
                Assert.AreEqual(1, lensRes.Scale);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                lens.LensID = id;
                lens.Name = "lens";
                ctrl.EditLens(lens);
                var lensRes = ctrl.GetLens(id);
                Assert.IsNotNull(lensRes);
                Assert.AreEqual("lens", lensRes.Name);
                Assert.AreEqual(1, lensRes.Scale);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteLens(lens.LensID);
                var lensRes = ctrl.GetLens(id);
                Assert.IsNull(lensRes);
            }
        }
    }
}
