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
    public class DiagnosticsTest
    {
        [TestMethod]
        public void DiagnosticsTest1()
        {
            Diagnostic diagnostic;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                diagnostic = new Diagnostic
                {
                    DiagnosticText = "text",
                    CreationDate = DateTime.Now,
                    DateOfLastConfirmation = DateTime.Now,
                    Comment = "comment",
                };

                id = ctrl.CreateDiagnostic(diagnostic);
                var diagnosticRes = ctrl.GetDiagnostic(id);
                Assert.IsNotNull(diagnosticRes);
                Assert.AreEqual("text", diagnosticRes.DiagnosticText);
                Assert.AreEqual("comment", diagnosticRes.Comment);

            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                diagnostic = new Diagnostic
                {
                    DiagnosticID = id,
                    DiagnosticText = "text",
                    CreationDate = DateTime.Now,
                    DateOfLastConfirmation = DateTime.Now,
                    Comment = "comment",
                };

                ctrl.EditDiagnostic(diagnostic);
                var diagnosticRes = ctrl.GetDiagnostic(id);
                Assert.IsNotNull(diagnosticRes);
                Assert.AreEqual("text", diagnosticRes.DiagnosticText);
                Assert.AreEqual("comment", diagnosticRes.Comment);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);

                ctrl.DeleteDiagnostic(diagnostic.DiagnosticID);
                var diagnosticRes = ctrl.GetDiagnostic(id);
                Assert.IsNull(diagnosticRes);
            }
        }
    }
}
