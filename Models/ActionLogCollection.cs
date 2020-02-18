using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public class ActionLogCollection : List<ActionLog>
	{
		//Properties
		#region TotalDuration
		public Double TotalDuration
		{
			get
			{
				Double result = 0.0;
				this.ForEach(current => result += current.DurationInMinutes);
				return result;
			}
		}
		#endregion

		#region TotalConsumption
		public Double TotalConsumption
		{
			get
			{
				Double result = 0.0;
				this.ForEach(current => result += current.CalcConsumption());
				return result;
			}
		}
		#endregion

		//Constructors
		#region ActionLogCollection
		public ActionLogCollection(IEnumerable<ActionLog> collection)
			: base(collection)
		{

		}
		#endregion
	}
}
