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
    public class HairTest
    {
        [TestMethod]
        public void HairTest1()
        {
            Hair hair;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                hair = new Hair()
                {
                    Width = 1,
                    X1 = 1,
                    X2 = 1,
                    Y1 = 1,
                    Y2 = 1,
                };

                id = ctrl.CreateHair(hair);
                var hairRes = ctrl.GetHair(id);
                Assert.IsNotNull(hair);
                Assert.AreEqual(1, hairRes.X1);
                Assert.AreEqual(1, hairRes.X2);
                Assert.AreEqual(1, hairRes.Y1);
                Assert.AreEqual(1, hairRes.Y2);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                hair.HairID = id;
                hair.X2 = 2;
                ctrl.EditHair(hair);
                var hairRes  = ctrl.GetHair(id);
                Assert.IsNotNull(hair);
                Assert.AreEqual(1, hairRes.X1);
                Assert.AreEqual(2, hairRes.X2);
                Assert.AreEqual(1, hairRes.Y1);
                Assert.AreEqual(1, hairRes.Y2);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteHair(hair.HairID);
                var hairRes = ctrl.GetHair(id);
                Assert.IsNull(hairRes);
            }
        }
    }
}
