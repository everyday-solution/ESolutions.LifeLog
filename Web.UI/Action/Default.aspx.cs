using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Action
{
	[ESolutions.Web.UI.PageUrl("~/Action/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					//Create 
					this.DateTextBox.Text = DateTime.Now.Date.ToShortDateString();
					this.ActionList.DataSource = Models.Action.LoadAll();
					this.ActionList.DataBind();
					ActionLog log = ActionLog.FindLatest(this.Session.GetCurrentUser());
					if (log != null)
					{
						this.ActionList.SelectedValue = log.Action.Guid.ToString();
					}

					this.DurationTextBox.Text = 30.ToString();

					//Filter
					this.FilterFrom.Text = DateTime.Now.Date.AddDays(-7).ToShortDateString();
					this.FilterUntil.Text = DateTime.Now.Date.ToShortDateString();
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
				ActionLogCollection userValues = ActionLog.FindAllOfUserBetweenDates(
					this.Session.GetCurrentUser(),
					this.FilterFrom.Text.ToDateTime(),
					this.FilterUntil.Text.ToDateTime());

				this.TotalDurationLabel.Text = userValues.TotalDuration.ToString("#");
				this.TotalConsumptionLabel.Text = userValues.TotalConsumption.ToString("#");

				this.ActionRepeater.DataSource = userValues;
				this.ActionRepeater.DataBind();
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
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region DeleteButton_Click
		protected void DeleteButton_Click(Object sender, EventArgs e)
		{
			try
			{
				Guid argument = new Guid((sender as ImageButton).CommandArgument);
				ActionLog logToDelete = MyDataContext.Default.ActionLogs.Single(current => current.Guid == argument);
				MyDataContext.Default.DeleteObject(logToDelete);
				MyDataContext.Default.SaveChanges();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region ActionRepeater_ItemDataBound
		protected void ActionRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
		{
			try
			{
				ActionLog current = e.Item.DataItem as ActionLog;

				if (current != null)
				{
					Label dateLabel = e.Item.FindControl("DateLabel") as Label;
					dateLabel.Text = current.Date.ToShortDateString();

					Label actionLabel = e.Item.FindControl("ActionLabel") as Label;
					actionLabel.Text = current.Action.Name;

					Label durationLabel = e.Item.FindControl("DurationLabel") as Label;
					durationLabel.Text = current.DurationInMinutes.ToString();

					Label consumptionLabel = e.Item.FindControl("ConsumptionLabel") as Label;
					consumptionLabel.Text = current.CalcConsumption().ToString();

					ImageButton deleteButton = e.Item.FindControl("DeleteButton") as ImageButton;
					deleteButton.CommandArgument = current.Guid.ToString();
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
