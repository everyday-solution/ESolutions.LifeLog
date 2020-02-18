using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class BloodPressure
	{
		//Classes
		#region Properties
		private static class Properties
		{
			public const String UserGuid = "UserGuid";
			public const String Date = "Date";
		}
		#endregion

		//Methods
		#region FindLatest
		public static BloodPressure FindLatest(User user)
		{
			var result = from current in MyDataContext.Default.BloodPressures
							 where current.UserGuid == user.Guid
							 orderby current.Date descending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region FindAll
		public static List<BloodPressure> FindAll(User user)
		{
			var result = from current in MyDataContext.Default.BloodPressures
							 where current.UserGuid == user.Guid
							 orderby current.Date descending
							 select current;
			return new List<BloodPressure>(result.ToArray());
		}
		#endregion
	}
}

