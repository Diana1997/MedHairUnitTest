using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MedHairUnitTest
{
    [TestClass]
    public class PictureTest
    {
        [TestMethod]
        public void PictureTest1()
        {
            Picture picture;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                picture = new Picture
                {
                    Title = "title",
                    Selected = true,
                    Data = new byte[1] { 0 },
                };

                id = ctrl.CreatePicture(picture);
                var pictureRes = ctrl.GetPicture(id);
                Assert.IsNotNull(pictureRes);
                Assert.AreEqual("title", pictureRes.Title);
                Assert.AreEqual(true, pictureRes.Selected);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                picture = new Picture
                {
                    PictureID = id,
                    Title = "title11",
                    Selected = false,
                    Data = new byte[1] { 0 },
                };
                ctrl.EditPicture(picture);
                var pictureRes = ctrl.GetPicture(id);
                Assert.IsNotNull(pictureRes);
                Assert.AreEqual("title11", pictureRes.Title);
                Assert.AreEqual(false, pictureRes.Selected);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);

                ctrl.DeletePicture(picture.PictureID);
                var pictureRes = ctrl.GetPicture(id);
                Assert.IsNull(pictureRes);
            }
        }
    }
}

