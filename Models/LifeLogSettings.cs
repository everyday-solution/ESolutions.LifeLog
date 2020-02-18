using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ESolutions.Security.Cryptography;
using System.Xml;

namespace ESolutions.LifeLog.Models
{
	public class LifeLogSettings : IConfigurationSectionHandler
	{
		//Fields
		#region a
		private const String a = "22274691-f850-4b36-a9ef-5f04229474ad";
		#endregion

		#region b
		private const String b = "99c08d33-68c8-4a0e-98e5-619fe0f7e09b";
		#endregion

		//Properties
		#region helper
		private static Rijndael Helper
		{
			get
			{
				Rijndael result = new Rijndael();
				result.EncryptionSecret = a;
				result.EncryptionIV = b;
				return result;
			}
		}
		#endregion

		#region Default
		/// <summary>
		/// Returns the applications default settings object.
		/// </summary>
		/// <value>The default.</value>
		public static LifeLogSettings Default
		{
			get
			{
				return (LifeLogSettings)ConfigurationManager.GetSection("esolutions.lifelog");
			}
		}
		#endregion

		#region DatabaseUser
		public String DatabaseUser
		{
			get;
			private set;
		}
		#endregion

		#region DatabasePassword
		public String DatabasePassword
		{
			get;
			private set;
		}
		#endregion

		#region DataSource
		public String DataSource
		{
			get;
			private set;
		}
		#endregion

		#region InitialCatalog
		public String InitialCatalog
		{
			get;
			private set;
		}
		#endregion

		#region AbsolutePicturePathPattern
		public String AbsolutePicturePathPattern
		{
			get;
			private set;
		}
		#endregion

		#region RealtivePictureUrlPattern
		public String RealtivePictureUrlPattern
		{
			get;
			private set;
		}
		#endregion

		#region DefaultSystolic
		public Int32 DefaultSystolic
		{
			get;
			private set;
		}
		#endregion

		#region DefaultDiastolic
		public Int32 DefaultDiastolic
		{
			get;
			private set;
		}
		#endregion

		#region DefaultHeartRate
		public Int32 DefaultHeartRate
		{
			get;
			private set;
		}
		#endregion

		//Methods
		#region Create
		/// <summary>
		/// Creates a configuration section handler.
		/// </summary>
		/// <param name="parent">Parent object.</param>
		/// <param name="configContext">Configuration context object.</param>
		/// <param name="section">Section XML node.</param>
		/// <returns>The created section handler object.</returns>
		public object Create(object parent, object configContext, XmlNode section)
		{
			LifeLogSettings result = new LifeLogSettings();

			result.DatabaseUser = LifeLogSettings.Helper.Decrypt(section["DatabaseUser"].InnerText);
			result.DatabasePassword = LifeLogSettings.Helper.Decrypt(section["DatabasePassword"].InnerText);
			result.DataSource = LifeLogSettings.Helper.Decrypt(section["DataSource"].InnerText);
			result.InitialCatalog = LifeLogSettings.Helper.Decrypt(section["InitialCatalog"].InnerText);
			result.AbsolutePicturePathPattern = section["AbsolutePicturePathPattern"].InnerText;
			result.RealtivePictureUrlPattern = section["RealtivePictureUrlPattern"].InnerText;
			result.DefaultSystolic = section["DefaultSystolic"].InnerText.ToInt32();
			result.DefaultDiastolic = section["DefaultDiastolic"].InnerText.ToInt32();
			result.DefaultHeartRate = section["DefaultHeartRate"].InnerText.ToInt32();

			return result;
		}
		#endregion
	}
}