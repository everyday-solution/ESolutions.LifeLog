using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public static class DateTimeExtender
	{
		#region GetInQuarters
		public static DateTime GetInQuarters(this DateTime input)
		{
			Int32 minutes = 0;
			Int32 hours = 0;

			if ((input.Minute >= 53 && input.Minute <= 60) || (input.Minute >= 0 && input.Minute < 8))
			{
				hours = input.Hour + 1;
				minutes = 0;
			}
			else if (input.Minute >= 8 && input.Minute < 23)
			{
				hours = input.Hour;
				minutes = 15;
			}
			else if (input.Minute >= 23 && input.Minute < 38)
			{
				hours = input.Hour;
				minutes = 30;
			}
			else if (input.Minute >= 38 && input.Minute < 53)
			{
				hours = input.Hour;
				minutes = 45;
			}

			DateTime result = new DateTime(
				input.Year,
				input.Month,
				input.Day,
				hours,
				minutes,
				0);

			return result;
		}
		#endregion

		#region ToDeviceString
		public static String ToDeviceString(this DateTime value, HttpBrowserCapabilities caps)
		{
			String result = value.ToShortDateString();

			if (caps.MobileDeviceModel.ToLower() == "iphone" && caps.MajorVersion >= 6)
			{
				result = value.ToString("yyyy-MM-dd");
			}

			return result;
		}
		#endregion
	}
}
