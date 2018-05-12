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
    public class ImageTest
    {
        [TestMethod]
        public void ImageTest1()
        {
            Image image;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                image = new Image()
                {
                    DateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                };

                id = ctrl.CreateImage(image);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("title", imageRes.Title);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                image = new Image()
                {
                    ImageID = id,
                    DateTime = DateTime.Now,
                    Title = "name",
                    ImageContent = new byte[2] { 0, 1 },
                };
                ctrl.EditImage(image);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("name", imageRes.Title);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteImage(image.ImageID);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNull(imageRes);
            }
        }
    }
}
