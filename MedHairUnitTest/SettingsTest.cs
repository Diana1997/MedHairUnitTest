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
    public class SettingsTest
    {
        [TestMethod]
        public void SettingsTest1()
        {
            Setting setting;
            int id;

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                setting = new Setting
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

                };

                id = ctrl.CreateSetting(setting);
                var settingsRes = ctrl.GetSetting(id);
                Assert.IsNotNull(settingsRes);

                Assert.AreEqual(1, settingsRes.HairSizeSettings.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, settingsRes.StatisticalSettings.TelogenVallus);
            }

            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                setting.SettingID = id;
                setting.HairSizeSettings.DiameterOfTerminalsMediumThick = 15;
                setting.StatisticalSettings.AnagenAll = 15;

                ctrl.EditSetting(setting);
                var settingRes = ctrl.GetSetting(id);

                Assert.IsNotNull(settingRes);
                Assert.AreEqual(15, settingRes.StatisticalSettings.AnagenAll);
                Assert.AreEqual(15, settingRes.HairSizeSettings.DiameterOfTerminalsMediumThick);
                Assert.AreEqual(1, settingRes.StatisticalSettings.AnagenTerm);
                Assert.AreEqual(1, settingRes.HairSizeSettings.DiameterOfVelusTerminal);

            }
            using (var db = new ApplicationDbContext("DefaultConnection"))
            {
                var ctrl = new MedHairController(db);
                ctrl.DeleteSetting(setting.SettingID);
                var settingRes = ctrl.GetSetting(id);
                Assert.IsNull(settingRes);
            }
        }
    }
}
