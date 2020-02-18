using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace ESolutions.LifeLog.Models
{
	public partial class MyDataContext
	{
		//Constants
		#region ItemKey
		private const String ItemKey = "{2FD539A0-8066-459C-9E53-B4AB04BD285B}";
		#endregion

		//Fields
		#region dataContextOutsideWebApplications
		private static MyDataContext dataContextOutsideWebApplications = null;
		#endregion

		//Properties
		#region Default
		public static MyDataContext Default
		{
			get
			{
				MyDataContext result = null;

				if (HttpContext.Current != null)
				{
					if (HttpContext.Current.Items[MyDataContext.ItemKey] == null)
					{
						HttpContext.Current.Items[MyDataContext.ItemKey] = MyDataContext.Create();
					}

					result = HttpContext.Current.Items[MyDataContext.ItemKey] as MyDataContext;
				}
				else
				{
					if (MyDataContext.dataContextOutsideWebApplications == null)
					{
						MyDataContext.dataContextOutsideWebApplications = MyDataContext.Create();
					}

					result = MyDataContext.dataContextOutsideWebApplications;
				}

				return result;
			}
		}
		#endregion

		#region Create
		private static MyDataContext Create()
		{
#if DEBUG
			return new MyDataContext();
#else
			SqlConnectionStringBuilder connString2Builder = new SqlConnectionStringBuilder();
			connString2Builder.DataSource = LifeLogSettings.Default.DataSource;
			connString2Builder.InitialCatalog = LifeLogSettings.Default.InitialCatalog;
			connString2Builder.Encrypt = false;
			connString2Builder.TrustServerCertificate = false;
			connString2Builder.UserID = LifeLogSettings.Default.DatabaseUser;
			connString2Builder.Password = LifeLogSettings.Default.DatabasePassword;

			EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
			builder.Provider = "System.Data.SqlClient";
			builder.ProviderConnectionString = connString2Builder.ConnectionString;
			builder.Metadata = @"res://*/MyDataContext.csdl|res://*/MyDataContext.ssdl|res://*/MyDataContext.msl";
									   

			return new MyDataContext(builder.ToString());
#endif
		}
		#endregion
	}
}