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
            using (var db = new ApplicationDbContext("DefaultConnection"))
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
                Assert.IsNotNull(contactRes);
                Assert.AreEqual("f", contactRes.Firstname);
                Assert.AreEqual("s", contactRes.Secondname);
                Assert.AreEqual("email@gmail.com", contact.Email);
                Assert.AreEqual(Gender.Femail, contact.Gender);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                contact.ContactID = id;
                contact.Firstname =  "firstname";
                contact.Lastname = "lastname";

                ctrl.EditContact(contact);
                var contactRes = ctrl.GetContact(id);
                Assert.IsNotNull(contact);

                Assert.AreEqual("firstname", contactRes.Firstname);
                Assert.AreEqual("lastname", contactRes.Lastname);
                Assert.AreEqual("email@gmail.com", contact.Email);
                Assert.AreEqual(Gender.Femail, contact.Gender);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteContact(contact.ContactID);
                var contactRes = ctrl.GetContact(id);
                Assert.IsNull(contactRes);
            }
        }
    }
}
