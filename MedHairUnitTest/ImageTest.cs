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
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                image = new Image()
                {
                    CreatectionDateTime = DateTime.Now,
                    Title = "title",
                    ImageContent = new byte[2] { 0, 1 },
                };

                id = ctrl.CreateImage(image);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("title", imageRes.Title);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                image.ImageID = id;
                image.Title = "title1";
                ctrl.EditImage(image);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNotNull(imageRes);
                Assert.AreEqual("title1", imageRes.Title);
                Assert.IsTrue(new byte[2] { 0, 1 }.SequenceEqual(imageRes.ImageContent));
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteImage(image.ImageID);
                var imageRes = ctrl.GetImage(id);
                Assert.IsNull(imageRes);
            }
        }
    }
}
