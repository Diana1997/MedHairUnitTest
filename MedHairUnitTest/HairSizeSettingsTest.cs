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
    public class HairSizeSettingsTest
    {
        [TestMethod]
        public void HairSizeSettingsTest1()
        {
            HairSizeSettings  hairSizeSettings;
            int id;
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                hairSizeSettings = new HairSizeSettings
                {
                    DiameterOfTerminalsMediumThick = 1,
                    DiameterOfTerminalsThinMedium = 1,
                    DiameterOfVelusTerminal = 1,
                    LengthOfTelogenHair = 1,
                    RadiusOfFollicularUnits = 1,

                };

                id = ctrl.CreateHairSizeSettings(hairSizeSettings);
                var hairSizeSettingsRes = ctrl.GetHairSizeSettings(id);
                Assert.IsNotNull(hairSizeSettingsRes);
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, hairSizeSettingsRes.DiameterOfTerminalsThinMedium);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                hairSizeSettings.HairSizeSettingsId = id;
                hairSizeSettings.DiameterOfTerminalsMediumThick = 2;
                hairSizeSettings.DiameterOfTerminalsThinMedium = 2;

                ctrl.EditHairSizeSettings(hairSizeSettings);
                var hairSizeSettingsRes = ctrl.GetHairSizeSettings(id);

                Assert.IsNotNull(hairSizeSettingsRes);
                Assert.AreEqual(2, hairSizeSettingsRes.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(2, hairSizeSettingsRes.DiameterOfTerminalsThinMedium);
                Assert.AreEqual(1, hairSizeSettings.DiameterOfVelusTerminal);
                Assert.AreEqual(1, hairSizeSettings.LengthOfTelogenHair);
            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteHairSizeSettings(hairSizeSettings.HairSizeSettingsId);
                var hairSizeSettingsRes = ctrl.GetHairSizeSettings(id);

                Assert.IsNull(hairSizeSettingsRes);
            }
        }
    }
}
