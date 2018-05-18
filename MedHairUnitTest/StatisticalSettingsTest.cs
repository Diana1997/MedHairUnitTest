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
    public class StatisticalSettingsTest
    {
        [TestMethod]
        public void StatisticalSettingsTest1()
        {
            StatisticalSettings  statisticalSettings;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                statisticalSettings = new StatisticalSettings
                {
                    AnagenAll = 1,
                    TelogenAll = 1,
                    AnagenTerm = 1,
                    TelogenTerm = 1,
                    AnagenVallus = 1,
                    TelogenVallus = 1,
                };

                id = ctrl.CreateStatisticalSettings(statisticalSettings);
                var statisticalSettingsRes = ctrl.GetStatisticalSettings(id);

                Assert.IsNotNull(statisticalSettingsRes);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenAll);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenVallus);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                statisticalSettings.StatisticalSettingsID = id;
                statisticalSettings.AnagenAll = 55;
                statisticalSettings.AnagenVallus = 55;

                ctrl.EditStatisticalSettings(statisticalSettings);
                var statisticalSettingsRes = ctrl.GetStatisticalSettings(id);
                Assert.IsNotNull(statisticalSettingsRes);
                Assert.AreEqual(55, statisticalSettingsRes.AnagenAll);
                Assert.AreEqual(55, statisticalSettingsRes.AnagenVallus);
                Assert.AreEqual(1, statisticalSettingsRes.AnagenTerm);
                Assert.AreEqual(1, statisticalSettingsRes.TelogenAll);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteStatisticalSettings(statisticalSettings.StatisticalSettingsID);
                var statisticalSettingsRes = ctrl.GetStatisticalSettings(id);
                Assert.IsNull(statisticalSettingsRes);
            }
        }
    }
}
