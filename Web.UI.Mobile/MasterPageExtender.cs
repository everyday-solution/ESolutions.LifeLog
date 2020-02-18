using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Web.UI.Mobile
{
	public static class MasterPageExtender
	{
		#region ShowError
		public static void ShowError(this System.Web.UI.MasterPage masterPage, Exception ex)
		{
			System.Web.UI.MasterPage runner = masterPage;

			while (runner != null)
			{
				if (runner is Main)
				{
					(runner as Main).ShowError(ex);
				}
				runner = runner.Master;
			}
		}
		#endregion
	}
}