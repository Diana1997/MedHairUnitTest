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

            using (var db = new ApplicationDbContext())
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
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                reportField = new ReportField
                {
                    ReportFieldID = id,
                    Name = "name",
                    FieldType = FieldType.DescriptionOfTheClinic,
                    FieldOption = new FieldOption
                    {
                        Text = "Text",
                        Selected = true,
                        Title = "title",
                    }
                };
                ctrl.EditReportField(reportField);
                var reportFieldRes = ctrl.GetReportField(id);
                Assert.IsNotNull(reportFieldRes);
                Assert.AreEqual("name", reportFieldRes.Name);
                Assert.AreEqual(FieldType.DescriptionOfTheClinic, reportFieldRes.FieldType);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);

                ctrl.DeleteReportField(reportField.ReportFieldID);
                var reportFieldRes = ctrl.GetReportField(id);
                Assert.IsNull(reportFieldRes);
            }
        }
    }
}
