using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedHairUnitTest
{
    [TestClass]
    public class ReportFieldTest
    {
        [TestMethod]
        public void ReportFieldTest1()
        {
            ReportField reportField;
            int id;

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                reportField = new ReportField
                {
                    Name = "name",
                    FieldType = FieldType.Conclusion,
                    FieldOption = new FieldOption
                    {
                        Text = "Text",
                        Selected = true,
                        Title = "title",
                    }
                };

                id = ctrl.CreateReportField(reportField);
                var reportFieldRes = ctrl.GetReportField(id);

                Assert.IsNotNull(reportFieldRes);
                Assert.AreEqual("name", reportFieldRes.Name);
                Assert.AreEqual(FieldType.Conclusion, reportFieldRes.FieldType);
                Assert.AreEqual("title", reportFieldRes.FieldOption.Title);
                Assert.AreEqual("Text", reportFieldRes.FieldOption.Text);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                reportField.ReportFieldID = id;
                reportField.Name = "nameName";
                reportField.FieldOption.Text = "textText";

                ctrl.EditReportField(reportField);
                var reportFieldRes = ctrl.GetReportField(id);

                Assert.IsNotNull(reportFieldRes);
                Assert.AreEqual("nameName", reportFieldRes.Name);
                Assert.AreEqual(FieldType.Conclusion, reportFieldRes.FieldType);
                Assert.AreEqual(true, reportFieldRes.FieldOption.Selected);
                Assert.AreEqual("textText", reportFieldRes.FieldOption.Text);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);

                ctrl.DeleteReportField(reportField.ReportFieldID);
                var reportFieldRes = ctrl.GetReportField(id);
                Assert.IsNull(reportFieldRes);
            }
        }
    }
}
