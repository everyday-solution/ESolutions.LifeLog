using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;
using ESolutions.Web.UI;
using System.IO;

namespace ESolutions.LifeLog.Web.UI.Feast
{
	[ESolutions.Web.UI.PageUrl("~/Feast/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.FilterUntil.Text = DateTime.Now.Date.ToShortDateString();
					this.FilterFrom.Text = DateTime.Now.Date.AddDays(-7).ToShortDateString();

					for (int index = 0; index <= 23; index++)
					{
						this.HourList.Items.Add(new ListItem(index.ToString("00"), index.ToString()));
					}
					for (int index = 0; index <= 59; index += 15)
					{
						this.MinuteList.Items.Add(new ListItem(index.ToString("00"), index.ToString()));
					}
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
				this.DateTextBox.Text = DateTime.Now.Date.ToShortDateString();
				this.HourList.SelectedValue = DateTime.Now.GetInQuarters().Hour.ToString();
				this.MinuteList.SelectedValue = DateTime.Now.GetInQuarters().Minute.ToString();

				DateTime from = DateTime.Parse(this.FilterFrom.Text);
				DateTime until = DateTime.Parse(this.FilterUntil.Text);

				this.FeastRepeater.DataSource = Ingestion.LoadIngestionsPerDay(from, until);
				this.FeastRepeater.DataBind();
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
				DateTime timeStamp = DateTime.Parse(this.DateTextBox.Text);
				timeStamp = timeStamp.AddHours(this.HourList.SelectedValue.ToInt32());
				timeStamp = timeStamp.AddMinutes(this.MinuteList.SelectedValue.ToInt32());

				Ingestion newIngstion = new Ingestion(this.Session.GetCurrentUser());
				newIngstion.Date = timeStamp;
				newIngstion.PictureGuid = Guid.NewGuid();
				MyDataContext.Default.Ingestions.AddObject(newIngstion);
				MyDataContext.Default.SaveChanges();

				newIngstion.SaveImage(this.PictureUpload.FileBytes);
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
				Ingestion logToDelete = MyDataContext.Default.Ingestions.Single(current => current.Guid == argument);

				Models.PictureHandler.DeleteImage(logToDelete.PictureGuid);

				MyDataContext.Default.DeleteObject(logToDelete);
				MyDataContext.Default.SaveChanges();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region IngestionRepeater_ItemDataBound
		protected void IngestionRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
		{
			try
			{
				Ingestion.PerDay current = e.Item.DataItem as Ingestion.PerDay;

				if (current != null)
				{
					Label date = e.Item.FindControl("DateLabel") as Label;
					date.Text = current.Date.ToShortDateString();

					Repeater pictureRepeater = e.Item.FindControl("PictureRepeater") as Repeater;
					pictureRepeater.DataSource = current.Ingestions;
					pictureRepeater.DataBind();
				}
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region PictureRepeater_ItemDataBound
		protected void PictureRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				Ingestion current = e.Item.DataItem as Ingestion;

				if (current != null)
				{
					Image myImage = e.Item.FindControl("MyImage") as Image;
					myImage.ImageUrl = current.GetPictureUrl();

					Label timeLabel = e.Item.FindControl("TimeLabel") as Label;
					timeLabel.Text = current.Date.ToShortTimeString();

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
