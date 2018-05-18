using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedHairUnitTest
{
    [TestClass]
    public class FieldOptionTest
    {
        [TestMethod]
        public void FieldOptionTest1()
        {
            FieldOption fieldOption;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                fieldOption = new FieldOption
                {
                    Title = "title",
                    Selected = true,
                    Text = "Text",
                     
                };

                id = ctrl.CreateFieldOption(fieldOption);
                var fieldOptionRes = ctrl.GetFieldOption(id);

                Assert.IsNotNull(fieldOptionRes);
                Assert.AreEqual("title", fieldOptionRes.Title);
                Assert.AreEqual(true, fieldOptionRes.Selected);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                fieldOption.FieldOptionID = id;
                fieldOption.Selected = false;
                fieldOption.Title = "title1";

                ctrl.EditFieldOption(fieldOption);
                var fieldOptionRes = ctrl.GetFieldOption(id);

                Assert.IsNotNull(fieldOptionRes);
                Assert.AreEqual("title1", fieldOptionRes.Title);
                Assert.AreEqual(false, fieldOptionRes.Selected);
                Assert.AreEqual("Text", fieldOptionRes.Text);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteFieldOption(fieldOption.FieldOptionID);
                var fieldOptionRes = ctrl.GetFieldOption(id);
                Assert.IsNull(fieldOptionRes);
            }
        }
    }
}
