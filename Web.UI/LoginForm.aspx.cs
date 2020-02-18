using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESolutions.LifeLog.Web.UI
{
	[ESolutions.Web.UI.PageUrl("~/LoginForm.aspx")]
	public partial class LoginForm : ESolutions.Web.UI.Page
	{
		#region Page_Init
		protected void Page_Init(Object sender, EventArgs e)
		{
			if (this.Request.Browser.IsMobileDevice)
			{
				this.Response.Redirect("http://mobile.mylifelog.de");
			}
		}
		#endregion

		#region LoginButton_Click
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			try
			{
				Models.User loggedUser = Models.User.Login(
					this.LoginUserTextBox.Text,
					this.LoginPasswordTextBox.Text);

				if (loggedUser != null)
				{
					this.Session.SetCurrentUser(loggedUser);
					this.ResponseAddOn.Redirect<Default>();
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}
