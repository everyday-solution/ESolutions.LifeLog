using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class SuccessLog
	{
		//Properties
		#region Type
		public SuccessLogTypes Type
		{
			get
			{
				return (SuccessLogTypes)this.type;
			}
			set
			{
				this.type = (int)value;
			}
		}
		#endregion

		//Constructors
		#region SuccessLog
		internal SuccessLog()
		{
			this.Guid = Guid.NewGuid();
		}
		#endregion

		#region SuccessLog
		public SuccessLog(Models.User user)
			: this()
		{
			this.UserGuid = user.Guid;
		}
		#endregion

		//Methods
		#region LoadAll
		public static List<SuccessLog> LoadAll(User user)
		{
			var result = from current in MyDataContext.Default.SuccessLogs
							 where current.UserGuid == user.Guid
							 select current;
			return new List<SuccessLog>(result.ToArray());
		}
		#endregion

		#region LoadSingle
		public static SuccessLog LoadSingle(System.Guid argument)
		{
			return MyDataContext.Default.SuccessLogs.SingleOrDefault(current => current.Guid == argument);
		}
		#endregion

		#region LoadLatest
		public static SuccessLog FindLatest(Models.User user)
		{
			var result = from runner in MyDataContext.Default.SuccessLogs
							 where runner.UserGuid == user.Guid
							 orderby runner.Date descending
							 select runner;
			return result.FirstOrDefault();
		}
		#endregion
	}
}
