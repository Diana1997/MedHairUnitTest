using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHairUnitTest
{
    [TestClass]
    public class ReportTemplateTest
    {
        [TestMethod]
        public void ReportTemplateTest1()
        {
            ReportTemplate reportTemplate;
            int id;

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                reportTemplate = new ReportTemplate
                {
                    FieldTypes = new List<C_FieldType>()
                     {
                         new C_FieldType{ FieldType = FieldType.Comments},
                         new C_FieldType{ FieldType = FieldType.DescriptionOfTheClinic},
                         new C_FieldType{FieldType = FieldType.Logo},

                     },
                    Pictures = new List<Picture>
                     {
                          new Picture{ Title = "Title1", Selected = true, Data = new byte[2]{0,1}, },
                          new Picture{ Title = "Title2", Selected = true, Data = new byte[2]{0,1}, },
                          new Picture{ Title = "Title3", Selected = true, Data = new byte[2]{0,1}, },

                     },
                    ReportFields = new List<ReportField>
                    {
                         new ReportField{ FieldType = FieldType.Comments, Name = "Name",
                             FieldOption  = new FieldOption{ Selected = true, Text = "Text", Title = "Title"}
                         },
                    }
                      
                };

                id = ctrl.CreateReportTemplate(reportTemplate);
                var reportTemplateRes = ctrl.GetReportTemplate(id);
                Assert.IsNotNull(reportTemplateRes);
                Assert.AreEqual(3, reportTemplateRes.FieldTypes.Count);
                Assert.AreEqual(3, reportTemplateRes.Pictures.Count);
                Assert.AreEqual("Title1", reportTemplateRes.Pictures.First().Title);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                reportTemplate.ReportTemplateId = id;
                reportTemplate.ReportFields.Add(
                    new ReportField
                    {
                        FieldType = FieldType.Comments,
                        Name = "Name22",
                        FieldOption = new FieldOption { Selected = true, Text = "Text22", Title = "Title22" }
                    }
                );
                ctrl.EditReportTemplate(reportTemplate);
                var reportTemplateRes = ctrl.GetReportTemplate(id);
                Assert.IsNotNull(reportTemplateRes);
                Assert.AreEqual(3, reportTemplateRes.FieldTypes.Count);
                Assert.AreEqual(4, reportTemplateRes.ReportFields.Count);
            }

                using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteReportTemplate(id);
                var reportTemplateRes = ctrl.GetReportTemplate(id);
                Assert.IsNull(reportTemplateRes);
            }
        }
    }
}
