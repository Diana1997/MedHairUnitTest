﻿using MedHair.ClassLibrary.Controllers;
using MedHair.ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHairUnitTest
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void PatientTest1()
        {
            int id;
            Patient newPatient;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                newPatient = new Patient
                {
                    CardNumber = 1,
                    Comment = "comment",
                    CreationDate = DateTime.Now,
                    DateTimeNextVisit = DateTime.Now,
                    PatientStatus = PatientStatus.New,
                    Images = new List<Image> {
                        new Image { Title = "title1", DateTime = DateTime.Now, ImageContent = new byte[1] { 0 } },
                        new Image { Title = "title2", DateTime = DateTime.Now, ImageContent = new byte[1] { 0 } },
                        new Image { Title = "title3", DateTime = DateTime.Now, ImageContent = new byte[1] { 0 } },
                    },
                    Contact = new Contact
                    {
                        Firstname = "firstname",
                        Secondname = "secondname",
                        Lastname = "lastname",
                        Gender = Gender.Femail,
                        Birthday = DateTime.Now,
                    }
                };
                id = ctrl.CreatePatient(newPatient);
                var patient = ctrl.GetPatient(id);
                Assert.IsNotNull(patient);
                Assert.AreEqual(1, patient.CardNumber);
                Assert.AreEqual("comment", patient.Comment);
            }
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new MedHairController(db);

                newPatient = new Patient
                {
                    PatientID = id,
                    CardNumber = 777,
                    PatientStatus = PatientStatus.InTheService,
                    CreationDate = DateTime.Now,
                    DateTimeNextVisit = DateTime.Now,
                    Contact = new Contact
                    {
                        //ContactID = ctrl.GetPatient(id).Contact.ContactID,
                        Firstname = "test",
                        Secondname = "secondname",
                        Lastname = "lastname",
                        Gender = Gender.Femail,
                        Birthday = DateTime.Now,
                    }
                };
                ctrl.EditPatient(newPatient);
                id = ctrl.CreatePatient(newPatient);
                var patient = ctrl.GetPatient(id);
                Assert.IsNotNull(patient);
            }
        }
    }
}
