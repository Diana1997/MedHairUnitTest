using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHair.ClassLibrary
{
	public class Settings
	{
		public static string connectionString = ConfigurationManager.ConnectionStrings["EntityDb"].ConnectionString;


		public const string REG_KEY_PATH = "HKEY_CURRENT_USER\\Software\\Nautilus\\Nautilus PHT";
		public const string REG_HAIR_SETTINGSID = "REG_HAIR_SETTINGSID";
	}
}
