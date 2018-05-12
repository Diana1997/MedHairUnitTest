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
            using (var db = new ApplicationDbContext())
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

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                fieldOption = new FieldOption
                {
                    FieldOptionID = id,
                    Title = "title",
                    Selected = false,
                    Text = "Text",
                };
                ctrl.EditFieldOption(fieldOption);
                var fieldOptionRes = ctrl.GetFieldOption(id);
                Assert.IsNotNull(fieldOptionRes);
                Assert.AreEqual("title", fieldOptionRes.Title);
                Assert.AreEqual(false, fieldOptionRes.Selected);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteFieldOption(fieldOption.FieldOptionID);
                var fieldOptionRes = ctrl.GetFieldOption(id);
                Assert.IsNull(fieldOptionRes);
            }
        }
    }
}
