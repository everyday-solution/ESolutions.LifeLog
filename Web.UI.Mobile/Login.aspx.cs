using ESolutions.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESolutions.LifeLog.Web.UI.Mobile
{
	[PageUrl("~/Login.aspx")]
	public partial class Login : ESolutions.Web.UI.Page
	{
		#region LoginButton_Click
		protected void LoginButton_Click(Object sender, EventArgs e)
		{
			try
			{
				Models.User user = Models.User.Login(this.UsernameTextBox.Text, this.PasswordTextBox.Text);
				this.Session.SetCurrentUser(user);
				this.ResponseAddOn.Redirect<Default>();
			}
			catch (Exception ex)
			{
				this.ErrorLabel.Text = ex.DeepParse();
				this.ErrorLabel.Visible = true;
			}
		}
		#endregion
	}
}