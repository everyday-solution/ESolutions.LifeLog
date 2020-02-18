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
	[PageUrl("~/Feast.aspx")]
	public partial class Feast : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
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
				this.DateTextBox.Text = DateTime.Now.ToDeviceString(this.Request.Browser);
				this.HourList.SelectedValue = DateTime.Now.GetInQuarters().Hour.ToString();
				this.MinuteList.SelectedValue = DateTime.Now.GetInQuarters().Minute.ToString();
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

				newIngstion.SaveImage(this.ImageUpload.FileBytes);

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