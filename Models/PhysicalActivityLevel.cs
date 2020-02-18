using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class PhysicalActivityLevel
	{
		#region LoadAll
		public static List<PhysicalActivityLevel> LoadAll()
		{
			var result = from current in MyDataContext.Default.PhysicalActivityLevels
							 orderby current.Name
							 select current;
			return result.ToList();
		}
		#endregion
	}
}