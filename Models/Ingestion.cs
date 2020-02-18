using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ESolutions.LifeLog.Models
{
	public partial class Ingestion
	{
		//Classes
		#region PerDay
		public class PerDay
		{
			//Properties
			#region Date
			public DateTime Date
			{
				get;
				set;
			}
			#endregion

			#region Ingestions
			public IEnumerable<Ingestion> Ingestions
			{
				get;
				set;
			}
			#endregion

			//Constructors
			#region PerDay
			public PerDay()
			{
				this.Ingestions = new List<Ingestion>();
			}
			#endregion
		}
		#endregion

		//Constructors
		#region Ingestion
		internal Ingestion()
		{
			this.Guid = Guid.NewGuid();
		}
		#endregion

		#region Ingestion
		public Ingestion(Models.User user)
			: this()
		{
			this.UserGuid = user.Guid;
		}
		#endregion

		//Methods
		#region LoadIngestionsPerDay
		public static object LoadIngestionsPerDay(DateTime fromDate, DateTime untilDate)
		{
			List<PerDay> result = new List<PerDay>();

			DateTime runner = untilDate.Date;
			while (runner >= fromDate.Date)
			{
				DateTime lowerDayBound = runner.Date;
				DateTime upperDayBound = runner.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
				var ingestionsPerDay = from current in MyDataContext.Default.Ingestions
											  where lowerDayBound <= current.Date && current.Date <= upperDayBound
											  orderby current.Date
											  select current;

				if (ingestionsPerDay.Count() > 0)
				{
					PerDay newDay = new PerDay();
					newDay.Date = runner;
					newDay.Ingestions = ingestionsPerDay;
					result.Add(newDay);
				}

				runner = runner.AddDays(-1);
			}

			return result;
		}
		#endregion

		#region SaveImage
		public void SaveImage(byte[] fileData)
		{
			Models.PictureHandler.SaveImage(fileData, this.PictureGuid);
		}
		#endregion

		#region GetPictureUrl
		public string GetPictureUrl()
		{
			return String.Format(
				LifeLogSettings.Default.RealtivePictureUrlPattern,
				this.PictureGuid.ToString());
		}
		#endregion

		#region FindLatest
		public static List<Ingestion> FindLastest(Models.User user)
		{
			DateTime? lastRecordDay = null;
			List<Ingestion> result = new List<Ingestion>();

			try
			{
				lastRecordDay = user.Ingestions.Max(runner => runner.Date);
				var temp = from runner in user.Ingestions
							  where runner.Date.Date == lastRecordDay.Value.Date
							  && runner.UserGuid == user.Guid
							  orderby runner.Date descending
							  select runner;
				result = temp.ToList();
			}
			catch { }

			return result;
		}
		#endregion
	}
}
