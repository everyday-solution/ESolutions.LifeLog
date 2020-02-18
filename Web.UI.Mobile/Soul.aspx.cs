using ESolutions.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Mobile
{
	[PageUrl("~/Soul.aspx")]
	public partial class Soul : ESolutions.Web.UI.Page
	{
		#region Page_PreRender
		protected void Page_PreRender(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.DateTextBox.Text = DateTime.Now.ToDeviceString(this.Request.Browser);
					this.EntryTypeRadioButton.SelectedValue = 0.ToString();
					this.NoteTextBox.Text = String.Empty;
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
				Models.SuccessLog newEntry = new Models.SuccessLog(this.Session.GetCurrentUser());
				newEntry.Date = DateTime.Parse(this.DateTextBox.Text);
				newEntry.Type = (Models.SuccessLogTypes)this.EntryTypeRadioButton.SelectedValue.ToInt32();
				newEntry.Text = this.NoteTextBox.Text;

				Models.MyDataContext.Default.SuccessLogs.AddObject(newEntry);
				Models.MyDataContext.Default.SaveChanges();

				this.ResponseAddOn.Redirect<Default>();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}