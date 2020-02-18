using ESolutions.LifeLog.Models;
using ESolutions.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESolutions.LifeLog.Web.UI.Mobile
{
	[PageUrl("~/Action.aspx")]
	public partial class Action : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.ActionList.DataSource = Models.Action.LoadAll();
					this.ActionList.DataBind();
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region Page_PreRender
		protected void Page_PreRender(object sender, EventArgs e)
		{
			try
			{
				this.DateTextBox.Text = DateTime.Now.ToDeviceString(this.Request.Browser);

				ActionLog lastestEntry = ActionLog.FindLatest(this.Session.GetCurrentUser());
				if (lastestEntry != null)
				{
					this.ActionList.SelectedValue = lastestEntry.Action.Guid.ToString();
				}

				this.DurationTextBox.Text = 30.ToString();
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
				ActionLog newLog = new ActionLog(this.Session.GetCurrentUser());
				newLog.ActionGuid = new Guid(this.ActionList.SelectedValue);
				newLog.Date = DateTime.Parse(this.DateTextBox.Text);
				newLog.DurationInMinutes = Int32.Parse(this.DurationTextBox.Text);

				MyDataContext.Default.ActionLogs.AddObject(newLog);
				MyDataContext.Default.SaveChanges();

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