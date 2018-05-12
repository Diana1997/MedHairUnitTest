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
    public class ContactTest
    {
        [TestMethod]
        public void ContactTest1()
        {
            Contact  contact;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                contact = new Contact
                {
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                    Phone = "45454",
                    Email = "email@gmail.com",
                    Address = "a",
                    Position = "p",
                    Specialty = "s",
                    Education = "e",
                    Comment = "c",
                    Degree = "D",
                };

                id = ctrl.CreateContact(contact);
                var contactRes = ctrl.GetContact(id);
                Assert.IsNotNull(contact);
                Assert.AreEqual("f", contactRes.Firstname);
                Assert.AreEqual("s", contactRes.Secondname);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                contact = new Contact
                {
                    ContactID = id,
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                    Phone = "45454",
                    Email = "email@gmail.com",
                    Address = "a",
                    Position = "p",
                    Specialty = "s",
                    Education = "e",
                    Comment = "c",
                    Degree = "D",
                };
                ctrl.EditContact(contact);
                var contactRes = ctrl.GetContact(id);
                Assert.IsNotNull(contact);
                Assert.AreEqual("f", contactRes.Firstname);
                Assert.AreEqual("s", contactRes.Secondname);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteContact(contact.ContactID);
                var contactRes = ctrl.GetContact(id);
                Assert.IsNull(contactRes);
            }
        }
    }
}
