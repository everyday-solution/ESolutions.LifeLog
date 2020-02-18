using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class Action
	{
		#region LoadAll
		public static List<Action> LoadAll( )
		{
			var result = from current in MyDataContext.Default.Actions
							 orderby current.Name
							 select current;
			return result.ToList();
		}
		#endregion
	}
}