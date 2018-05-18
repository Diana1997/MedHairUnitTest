using System;
using System.Collections.Generic;
using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MedHairUnitTest
{
    [TestClass]
    public class ResearchTest
    {
        [TestMethod]
        public void ResearchTest1()
        {
            Research research;
            int id;

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                research = new Research
                {
                    ResearchType = ResearchType.Phototrichogram,
                    StateOfTheResearch = StateOfTheResearch.Completed,
                    Thumbnail = new byte[1] { 0 },
                    ResearchDateTime = DateTime.Now,
                    Image = new Image
                    {
                        Title = "Title",
                        CreatectionDateTime = DateTime.Now,
                        ImageContent = new byte[1] { 0 },
                    },
                    Comment = "Comment",
                    Diagnostic = new Diagnostic
                    {
                        DiagnosticText = "text",
                        Comment = "Comment",
                        CreationDate = DateTime.Now,
                        DateOfLastConfirmation = DateTime.Now,

                    },
                    Lens = new Lens
                    {
                        Name = "name",
                        Scale = 4,
                    },
                    Treatment = "Treatment",
                    Setting = new Setting
                    {
                        HairSizeSettings = new HairSizeSettings
                        {
                            DiameterOfTerminalsMediumThick = 1,
                            DiameterOfTerminalsThinMedium = 1,
                            DiameterOfVelusTerminal = 1,
                            LengthOfTelogenHair = 1,
                            RadiusOfFollicularUnits = 1,
                        },
                        StatisticalSettings = new StatisticalSettings
                        {
                            AnagenAll = 1,
                            TelogenAll = 1,
                            AnagenTerm = 1,
                            AnagenVallus = 1,
                            TelogenTerm = 1,
                            TelogenVallus = 1,
                        }

                    },
                    ResearchArea = ResearchArea.Crown,
                    Documents = new List<Document>
                         {
                             new Document
                             {
                                  Name = "Name1", Content = new byte[1]{0},
                             },
                             new Document
                             {
                                  Name = "Name2", Content = new byte[1]{0},
                             }
                         },
                    Hairs = new List<Hair>
                          {
                              new Hair{ Width = 1, X1 = 1, X2 = 2, Y1 = 1, Y2 = 1 }
                          }

                };
                id = ctrl.CreateResearch(research);
                var researchRes = ctrl.GetResearch(id);
                Assert.IsNotNull(researchRes);
                Assert.AreEqual(ResearchType.Phototrichogram, researchRes.ResearchType);
                Assert.AreEqual("name", researchRes.Lens.Name);
                Assert.AreEqual(2, researchRes.Documents.Count);
                Assert.AreEqual(1, researchRes.Setting.HairSizeSettings.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, researchRes.Setting.StatisticalSettings.AnagenAll);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                research.ResearchID = id;
                research.Lens.Name = "Name2";
                research.ResearchArea = ResearchArea.Forehead;
                research.Setting.StatisticalSettings.AnagenAll = 55;
                research.Documents.Add(
                    new Document
                    {
                        Name = "Name3",
                        Content = new byte[1] { 0 },

                    }
                );
                research.Setting.HairSizeSettings.DiameterOfTerminalsMediumThick = 55;
                ctrl.EditResearch(research);
             
                var researchRes = ctrl.GetResearch(id);
                Assert.IsNotNull(researchRes);
                Assert.AreEqual("Name2", researchRes.Lens.Name);
                Assert.AreEqual(ResearchArea.Forehead, research.ResearchArea);
                Assert.AreEqual(ResearchType.Phototrichogram, researchRes.ResearchType);
                Assert.AreEqual(55, researchRes.Setting.HairSizeSettings.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(55, researchRes.Setting.StatisticalSettings.AnagenAll);
            //    Assert.AreEqual(3, researchRes.Documents.Count);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteResearch(id);
                var researchRes = ctrl.GetResearch(id);
                Assert.IsNull(researchRes);
            }
        }
    }
}
