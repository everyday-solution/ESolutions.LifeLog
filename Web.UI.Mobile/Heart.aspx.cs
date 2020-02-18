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
	[PageUrl("~/Heart.aspx")]
	public partial class Heart : ESolutions.Web.UI.Page
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
		protected void Page_PreRender(Object sender, EventArgs e)
		{
			try
			{
				this.DateTextBox.Text = DateTime.Now.ToDeviceString(this.Request.Browser);

				this.HourList.SelectedValue = DateTime.Now.GetInQuarters().Hour.ToString();
				this.MinuteList.SelectedValue = DateTime.Now.GetInQuarters().Minute.ToString();

				BloodPressure lastEntry = BloodPressure.FindLatest(this.Session.GetCurrentUser());
				if (lastEntry == null)
				{
					this.HeartRateTextBox.Text = LifeLogSettings.Default.DefaultHeartRate.ToString();
					this.SystolicTextBox.Text = LifeLogSettings.Default.DefaultSystolic.ToString();
					this.DiastolicTextBox.Text = LifeLogSettings.Default.DefaultDiastolic.ToString();
				}
				else
				{
					this.HeartRateTextBox.Text = lastEntry.HeartRate.ToString();
					this.SystolicTextBox.Text = lastEntry.Systolic.ToString();
					this.DiastolicTextBox.Text = lastEntry.Diastolic.ToString();
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
				DateTime selectedDate = DateTime.Parse(this.DateTextBox.Text);
				selectedDate = selectedDate.AddHours(this.HourList.SelectedValue.ToInt32());
				selectedDate = selectedDate.AddMinutes(this.MinuteList.SelectedValue.ToInt32());

				BloodPressure newEntry = new BloodPressure();
				newEntry.Guid = Guid.NewGuid();
				newEntry.UserGuid = this.Session.GetCurrentUser().Guid;
				newEntry.Date = selectedDate;
				newEntry.HeartRate = this.HeartRateTextBox.Text.ToInt32();
				newEntry.Systolic = this.SystolicTextBox.Text.ToInt32();
				newEntry.Diastolic = this.DiastolicTextBox.Text.ToInt32();

				MyDataContext.Default.BloodPressures.AddObject(newEntry);
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