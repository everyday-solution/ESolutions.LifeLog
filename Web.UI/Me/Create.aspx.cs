using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Me
{
	[ESolutions.Web.UI.PageUrl("~/Me/Create.aspx")]
	public partial class Create : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.HeightTextBox.Text = 170.ToString();
					this.NewUserDateOfBirthTextBox.Text = new DateTime(1970, 1, 1).ToShortDateString();
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region CreateUserButton_Click
		protected void CreateUserButton_Click(Object sender, EventArgs e)
		{
			try
			{
				Models.User newUser = Models.User.Create(
					 this.NewUserEmailTextBox.Text,
					 this.NewUserPasswordTextBox.Text,
					 DateTime.Parse(this.NewUserDateOfBirthTextBox.Text),
					 Int32.Parse(this.HeightTextBox.Text),
					 (Genders)Enum.Parse(typeof(Genders), this.GenderList.SelectedValue));

				if (newUser != null)
				{
					this.Session.SetCurrentUser(newUser);
					this.ResponseAddOn.Redirect<Default>();
				}
			}
			catch (Exception ex)
			{
				this.CreateErrorLabel.Visible = true;
				this.CreateErrorLabel.Text = ex.Message;
			}
		}
		#endregion
	}
}