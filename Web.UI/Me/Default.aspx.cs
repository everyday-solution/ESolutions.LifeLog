using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.Web.UI;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Me
{
	[PageUrl("~/Me/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					User currentUser = this.Session.GetCurrentUser();
					this.DateOfBirthTextBox.Text = currentUser.DateOfBirth.ToShortDateString();
					this.HeightTextBox.Text = currentUser.HeightInCentimeters.ToString();
					this.GenderList.SelectedValue = currentUser.Gender.ToString();
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region SaveButton_Click
		protected void SaveButton_Click(Object sender, EventArgs e)
		{
			try
			{
				User currentUser = this.Session.GetCurrentUser();
				currentUser.DateOfBirth = DateTime.Parse(this.DateOfBirthTextBox.Text);
				currentUser.HeightInCentimeters = Convert.ToInt32(this.HeightTextBox.Text);
				currentUser.Gender = (Genders)Enum.Parse(typeof(Genders), this.GenderList.SelectedValue);

				MyDataContext.Default.SaveChanges();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region ChangePasswordButton_Click
		protected void ChangePasswordButton_Click(Object sender, EventArgs e)
		{
			try
			{
				if (
					String.IsNullOrWhiteSpace(this.PasswordTextBox.Text) ||
					String.IsNullOrWhiteSpace(this.PasswordConfirmTextBox.Text) ||
					this.PasswordTextBox.Text != this.PasswordConfirmTextBox.Text)
				{
					throw new Exception("Passwords are not equal or invalid.");
				}

				this.Session.GetCurrentUser().ChangePassword(this.PasswordTextBox.Text);
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}
