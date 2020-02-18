using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Soul
{
	[ESolutions.Web.UI.PageUrl("~/Soul/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		public void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.EditGuidHidden.Value = String.Empty;
					this.DateTextBox.Text = DateTime.Now.Date.ToShortDateString();
					this.TypeRadioButton.SelectedValue = Models.SuccessLogTypes.Happiness.ToString();
					this.NoteTextBox.Text = String.Empty;

					this.FilterFromTextBox.Text = DateTime.Now.AddDays(-30).ToShortDateString();
					this.FilterUntilTextBox.Text = DateTime.Now.ToShortDateString();
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
				DateTime fromDate = DateTime.Parse(this.FilterFromTextBox.Text);
				DateTime untilDate = DateTime.Parse(this.FilterUntilTextBox.Text);
				this.SuccessRepeater.DataSource = from current in SuccessLog.LoadAll(this.Session.GetCurrentUser())
															 where fromDate <= current.Date && current.Date <= untilDate
															 orderby current.Date descending
															 select current;
				this.SuccessRepeater.DataBind();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region SuccessRepeater_ItemDataBound
		protected void SuccessRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
		{
			try
			{
				SuccessLog current = e.Item.DataItem as SuccessLog;

				if (current != null)
				{
					Label dateLabel = e.Item.FindControl("DateLabel") as Label;
					dateLabel.Text = current.Date.ToShortDateString();

					Label typeLabel = e.Item.FindControl("TypeLabel") as Label;
					typeLabel.Text = current.Type.ToString();

					Label noteLabel = e.Item.FindControl("NoteLabel") as Label;
					noteLabel.Text = current.Text;

					ImageButton deleteButton = e.Item.FindControl("DeleteButton") as ImageButton;
					deleteButton.CommandArgument = current.Guid.ToString();

					ImageButton editButton = e.Item.FindControl("EditButton") as ImageButton;
					editButton.CommandArgument = current.Guid.ToString();
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
				SuccessLog currentLog = null;

				if (String.IsNullOrEmpty(this.EditGuidHidden.Value))
				{
					currentLog = new SuccessLog(this.Session.GetCurrentUser());
					MyDataContext.Default.SuccessLogs.AddObject(currentLog);
				}
				else
				{
					currentLog = SuccessLog.LoadSingle(this.EditGuidHidden.Value.ToGuid());
				}

				currentLog.Date = DateTime.Parse(this.DateTextBox.Text);
				currentLog.Text = this.NoteTextBox.Text;
				currentLog.Type = (SuccessLogTypes)Enum.Parse(typeof(SuccessLogTypes), TypeRadioButton.SelectedValue);
				MyDataContext.Default.SaveChanges();

				this.ResponseAddOn.Redirect<Soul.Default>();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region DeleteButton_Click
		protected void DeleteButton_Click(Object sender, ImageClickEventArgs e)
		{
			try
			{
				Guid argument = new Guid((sender as ImageButton).CommandArgument);
				SuccessLog logToDelete = MyDataContext.Default.SuccessLogs.Single(current => current.Guid == argument);
				MyDataContext.Default.SuccessLogs.DeleteObject(logToDelete);
				MyDataContext.Default.SaveChanges();

				this.ResponseAddOn.Redirect<Soul.Default>();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region EditButton_Click
		protected void EditButton_Click(Object sender, EventArgs e)
		{
			try
			{
				Guid argument = new Guid((sender as ImageButton).CommandArgument);
				SuccessLog current = SuccessLog.LoadSingle(argument);

				this.EditGuidHidden.Value = current.Guid.ToString();
				this.DateTextBox.Text = current.Date.ToShortDateString();
				this.NoteTextBox.Text = current.Text;
				this.TypeRadioButton.SelectedValue = current.Type.ToString();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}
