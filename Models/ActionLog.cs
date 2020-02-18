using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class ActionLog
	{
		//Classes
		#region Properties
		public static class Properties
		{
			public const String UserGuid = "UserGuid";
		}
		#endregion

		//Constructors
		#region ActionLog
		internal ActionLog()
		{
			this.Guid = Guid.NewGuid();
		}
		#endregion

		#region ActionLog
		public ActionLog(Models.User user)
			: this()
		{
			this.UserGuid = user.Guid;
		}
		#endregion

		//Methods
		#region FindAll
		public static ActionLogCollection FindAll(Models.User user)
		{
			var result = from current in MyDataContext.Default.ActionLogs
							 where current.UserGuid == user.Guid
							 orderby current.Date descending
							 select current;
			return new ActionLogCollection(result.ToArray());
		}
		#endregion

		#region FindAllOfUserBetweenDates
		public static ActionLogCollection FindAllOfUserBetweenDates(User user, DateTime from, DateTime until)
		{
			DateTime adjustedFrom = from.Date;
			DateTime adjustedUntil = until.Date.AddDays(1).AddSeconds(-1);

			var result = from current in ActionLog.FindAll(user)
							 where current.Date >= adjustedFrom
							 && current.Date <= adjustedUntil
							 orderby current.Date descending
							 select current;
			return new ActionLogCollection(result.ToArray());
		}
		#endregion

		#region CalcConsumption
		/// <summary>
		/// Calcs the consumption.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		public Int32 CalcConsumption()
		{
			BodyMeasure lastKnownEntry = BodyMeasure.FindNearestToDate(this.User, this.Date);

			Double result = 0;

			if (lastKnownEntry != null)
			{
				Double weight = lastKnownEntry.Weight;
				Double duration = this.DurationInMinutes;
				Double factor = this.Action.Consumption;

				result = weight * duration * factor;
			}

			return Convert.ToInt32(result);
		}
		#endregion

		#region GetSportKcalOfDay
		public static Double GetSportKcalOfDay(User user, DateTime day)
		{
			DateTime adjustedDate = day.Date.AddDays(1).AddSeconds(-1);
			var result = from current in MyDataContext.Default.ActionLogs.ToList()
							 where current.UserGuid == user.Guid
							 && current.Date.Date == adjustedDate
							 select current;
			return result.Sum(current => current.CalcConsumption());
		}
		#endregion

		#region FindLatest
		public static ActionLog FindLatest(User user)
		{
			var result = from current in MyDataContext.Default.ActionLogs
							 where current.UserGuid == user.Guid
							 orderby current.Date descending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion
	}
}
