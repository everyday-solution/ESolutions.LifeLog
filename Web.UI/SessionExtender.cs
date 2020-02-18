using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Web.UI
{
	public static class SessionExtender
	{
		#region GetCurrentUser
		public static Models.User GetCurrentUser(this System.Web.SessionState.HttpSessionState state)
		{
			Models.User result = null;

			if (state["CurrentUser"] != null)
			{
				Guid userGuid = (Guid)state["CurrentUser"];
				result = Models.MyDataContext.Default.Users.FirstOrDefault(runner => runner.Guid == userGuid);
			}

			return result;
		}
		#endregion

		#region SetCurrentUser
		public static void SetCurrentUser(
			this System.Web.SessionState.HttpSessionState state,
			Models.User user)
		{
			state["CurrentUser"] = user == null ? null : (Guid?)user.Guid;
		}
		#endregion
	}
}
