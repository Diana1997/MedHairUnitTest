using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            int contactId;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ContactsController(db);
                var contact = new Contact
                {
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                };

                contactId = ctrl.Create(contact);
                var contactRes = ctrl.Get(contactId);
                Assert.IsNotNull(contact);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new UsersController(db);
                user = new User
                {
                    Login = "l",
                    Password = new byte[1] { 0 },
                    ContactID = contactId,
                    LastLoginTime = DateTime.Now,
                };
              
                id = ctrl.Create(user);
                var userRes = ctrl.Get(id);
                Assert.IsNotNull(userRes);
                Assert.AreEqual("l", userRes.Login);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new UsersController(db);
                user = new User
                {
                    UserID = id,
                    Login = "l",
                    Password = new byte[1] { 0 },
                    ContactID = contactId,
                    LastLoginTime = DateTime.Now,
                };
                ctrl.Edit(user);
                var userRes = ctrl.Get(id);
                Assert.IsNotNull(userRes);
                Assert.AreEqual("l", userRes.Login);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new UsersController(db);

                ctrl.Delete(user.UserID);
                var userRes = ctrl.Get(id);
                Assert.IsNull(userRes);
            }
        }
    }
}
