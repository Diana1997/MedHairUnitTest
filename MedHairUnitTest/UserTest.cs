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
    public class UserTest
    {
        [TestMethod]
        public void UserTest1()
        {
            User user;
            int id;


            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                user = new User
                {
                    Login = "login",
                    Password = new byte[2] { 0, 1 },
                    LastLoginTime = DateTime.Now,
                    Contact = new Contact
                    {
                        Firstname = "firstname",
                        Secondname = "secondname",
                        Lastname = "lastname",
                        Birthday = DateTime.Now,
                    },
                    Lens = new Lens
                    {
                        Name = "name",
                        Scale = 1,
                    },
                    Setting=  new Setting
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

                    }
                }

                };
                id = ctrl.CreateUser(user);
                var userRes = ctrl.GetUser(id);
                Assert.IsNotNull(userRes);
                Assert.AreEqual("login", user.Login);
                Assert.AreEqual("firstname", user.Contact.Firstname);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                user.UserID = id;
                user.Contact.Firstname = "Anna";

                ctrl.EditUser(user);
                var userRes = ctrl.GetUser(id);
                Assert.IsNotNull(userRes);
                Assert.AreEqual("login", user.Login);
                Assert.AreEqual("Anna", user.Contact.Firstname);
            }


                using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteUser(id);
                var userRes = ctrl.GetUser(id);
                Assert.IsNull(userRes);
            }
        }
    }
}
