using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MedHairUnitTest
{
    [TestClass]
    public class VisitTest
    {
        [TestMethod]
        public void VisitTest1()
        {
            Visit visit;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                visit = new Visit
                {
                    CommentOnTheVisits = new List<CommentOnTheVisit>
                    {
                        new CommentOnTheVisit
                        {
                            Comment = "comment1",
                            TypeOfComment = TypeOfComment.AdministratoroTheDoctor,
                        },
                         new CommentOnTheVisit
                        {
                            Comment = "comment2",
                            TypeOfComment = TypeOfComment.AdministratoroTheDoctor,
                        }
                    },
                    DateTime = DateTime.Now,
                    Documents = new List<Document>
                    {
                         new Document
                         {
                              Content = new byte[2]{0, 1},
                              Name = "Name11",
                         },
                         new Document
                         {
                              Content = new byte[2]{0, 1},
                              Name = "Name22",
                         },
                     },
                    Patient = new Patient
                    {
                        CardNumber = 77,
                        Comment = "Commment",
                        Contact = new Contact
                        {
                            Address = "adress1",
                            Birthday = DateTime.Now,
                            Comment = "comment1",
                            Degree = "degree1",
                            Education = "education1",
                            Email = "mail.ru",
                            Firstname = "name1",
                            Lastname = "lname1",
                            Gender = Gender.Femail,
                            Secondname = "sname1"
                        },
                        PatientStatus = PatientStatus.New,
                        CreationDate = DateTime.Now,
                        DateTimeNextVisit = DateTime.Now,
                        Images = new List<Image>
                            {
                                    new Image(){Title ="tile1",ImageContent = new byte[1]{0},CreatectionDateTime = DateTime.Now },
                                    new Image(){Title ="tile2",ImageContent = new byte[1]{0},CreatectionDateTime = DateTime.Now },
                                    new Image(){Title ="tile3",ImageContent = new byte[1]{0},CreatectionDateTime = DateTime.Now },
                                    new Image(){Title ="tile4",ImageContent = new byte[1]{0},CreatectionDateTime = DateTime.Now }
                            },

                    },
                    Research = new Research
                    {
                        ResearchDateTime = DateTime.Now,
                        ResearchType = ResearchType.Phototrichogram,
                        StateOfTheResearch = StateOfTheResearch.Completed,
                        Thumbnail = new byte[1] { 1 },
                        Image = new Image { CreatectionDateTime = DateTime.Now, Title = "title", ImageContent = new byte[1] { 1 }, },
                        Hairs = new List<Hair> { new Hair { Width = 1, X1 = 2, X2 = 2, Y1 = 3, Y2 = 2 } },
                        ResearchArea = ResearchArea.Crown,
                        Setting = new Setting
                        {
                            HairSizeSettings = new HairSizeSettings
                            {
                                DiameterOfTerminalsMediumThick = 1,
                                DiameterOfTerminalsThinMedium = 1,
                                DiameterOfVelusTerminal = 2,
                                LengthOfTelogenHair = 2,
                                RadiusOfFollicularUnits = 32
                            },
                            StatisticalSettings = new StatisticalSettings
                            {
                                AnagenAll = 1,
                                AnagenTerm = 1,
                                AnagenVallus = 5,
                                TelogenAll = 4,
                                TelogenTerm = 7,
                                TelogenVallus = 7
                            },
                        },
                        Comment = "comment",
                        Diagnostic = new Diagnostic { Comment = "comment", CreationDate = DateTime.Now, DiagnosticText = "DiagnosticText", DateOfLastConfirmation = DateTime.Now },
                        Documents = new List<Document> { new Document { Content = new byte[1] { 1 }, Name = "DocName", } },
                        Lens = new Lens { Name = "LenName", Scale = 4 },
                        Treatment = "Treatment",

                    },
                    User = new User
                    {
                        Contact = new Contact
                        {
                            Address = "adress1",
                            Birthday = DateTime.Now,
                            Comment = "comment1",
                            Degree = "degree1",
                            Education = "education1",
                            Email = "mail.ru",
                            Firstname = "name1",
                            Lastname = "lname1",
                            Gender = Gender.Femail,
                            Secondname = "sname1"
                        },
                        Lens = new Lens { Name = "LenName", Scale = 4 },
                        Login = "admin",
                        Password = new byte[7] { 1, 1, 1, 1, 1, 1, 1 },
                        LastLoginTime = DateTime.Now,
                        Setting = new Setting
                        {

                            HairSizeSettings = new HairSizeSettings
                            {

                                DiameterOfTerminalsMediumThick = 1,
                                DiameterOfTerminalsThinMedium = 1,
                                DiameterOfVelusTerminal = 2,
                                LengthOfTelogenHair = 2,
                                RadiusOfFollicularUnits = 32
                            },
                            StatisticalSettings = new StatisticalSettings
                            {

                                AnagenAll = 1,
                                AnagenTerm = 1,
                                AnagenVallus = 5,
                                TelogenAll = 4,
                                TelogenTerm = 7,
                                TelogenVallus = 7
                            },
                        },
                        ResearchArea = ResearchArea.Crown,
                        ReportTemplates = new List<ReportTemplate>
                        {
                             new ReportTemplate
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
                                    },

                               },
                         },
                    }
                };
                id = ctrl.CreateVisit(visit);
                var visitRes = ctrl.GetVisit(id);
                Assert.IsNotNull(visitRes);
                Assert.AreEqual("Commment", visitRes.Patient.Comment);
                Assert.AreEqual("name1", visitRes.User.Contact.Firstname);
                Assert.AreEqual(77, visitRes.Patient.CardNumber);
            }

            //using (var db = new ApplicationDbContext("DefaultConnection"))
            //{
            //    var ctrl = new MedHairController(db);
            //    var visitEdit = ctrl.GetVisit(id);
            //    //visitEdit.CommentOnTheVisits = new List<CommentOnTheVisit> {
            //    //    new CommentOnTheVisit{ Comment = "comNew1", TypeOfComment = TypeOfComment.AdministratorYourself},
            //    //    new CommentOnTheVisit {Comment="comNew2", TypeOfComment = TypeOfComment.TheDoctorHimself},
            //    //};
            //    visitEdit.CommentOnTheVisits.Add(
            //          new CommentOnTheVisit { Comment = "comNew1", TypeOfComment = TypeOfComment.AdministratorYourself }
            //        );
            //    //  visitEdit.Research.Lens.Name = "aaa";
            //    ctrl.EditVisit(visitEdit);
            //    var visitRes = ctrl.GetVisit(id);
            //    Assert.IsNotNull(visitRes);
            //    // Assert.AreEqual(4, visitRes.CommentOnTheVisits.Count);
            //    //  Assert.AreEqual("aaa", visit.Research.Lens.Name);
            //}


            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteVisit(id);
                var visitRes = ctrl.GetVisit(id);
                Assert.IsNull(visitRes);
            }
        }
    }
}
