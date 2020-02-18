using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Web.UI
{
	public static class StringExtender
	{
		#region ToDateTime
		public static DateTime ToDateTime(this String input)
		{
			DateTime result = DateTime.MinValue;
			DateTime.TryParse(input, out result);
			return result;
		}
		#endregion
	}
}
