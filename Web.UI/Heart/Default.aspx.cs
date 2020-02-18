using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;

namespace ESolutions.LifeLog.Web.UI.Heart
{
	[ESolutions.Web.UI.PageUrl("~/Heart/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.FilterFrom.Text = DateTime.Now.Date.AddDays(-7).ToShortDateString();
					this.FilterUntil.Text = DateTime.Now.Date.ToShortDateString();

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

				this.FillListAndChart();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region FillListAndChart
		private void FillListAndChart()
		{
			BloodPressureCollection userValues = new BloodPressureCollection(
				from current in BloodPressure.FindAll(this.Session.GetCurrentUser())
				where current.Date >= Convert.ToDateTime(this.FilterFrom.Text)
				&& current.Date <= Convert.ToDateTime(this.FilterUntil.Text).AddHours(23).AddMinutes(59)
				orderby current.Date descending
				select current);

			this.FillList(userValues);
			this.FillChart(userValues);
		}
		#endregion

		#region FillChart
		private void FillChart(BloodPressureCollection value)
		{
			var valuesAscending = from current in value
										 orderby current.Date ascending
										 select current;

			foreach (BloodPressure current in valuesAscending)
			{
				this.Chart1.Series["HeartRateSeries"].Points.Add(current.HeartRate);
				this.Chart1.Series["HeartRateSeries"].Points[this.Chart1.Series["HeartRateSeries"].Points.Count - 1].AxisLabel = current.Date.ToShortDateString();
				this.Chart1.Series["PressureSeries"].Points.Add(current.Systolic, current.Diastolic);
			}
		}
		#endregion

		#region FillList
		private void FillList(BloodPressureCollection value)
		{
			this.AverageHeartRateLabel.Text = value.AverageHeartRate.ToString("#");
			this.AverageSystolicLabel.Text = value.AverageSystolic.ToString("#");
			this.AverageDiastolicLabel.Text = value.AverageDiastolic.ToString("#");

			this.BloodPressureRepeater.DataSource = value;
			this.BloodPressureRepeater.DataBind();
		}
		#endregion

		#region BloodPressureRepeater_ItemDataBound
		protected void BloodPressureRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
		{
			try
			{
				BloodPressure current = e.Item.DataItem as BloodPressure;

				if (current != null)
				{
					Label dateLabel = e.Item.FindControl("DateLabel") as Label;
					dateLabel.Text = current.Date.ToString("dd.MM.yyyy HH:mm");

					Label heartRateLabel = e.Item.FindControl("HeartRateLabel") as Label;
					heartRateLabel.Text = current.HeartRate.ToString();

					Label systolicLabel = e.Item.FindControl("SystolicLabel") as Label;
					systolicLabel.Text = current.Systolic.ToString();

					Label diastolicLabel = e.Item.FindControl("DiastolicLabel") as Label;
					diastolicLabel.Text = current.Diastolic.ToString();

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
				BloodPressure logToDelete = MyDataContext.Default.BloodPressures.Single(current => current.Guid == argument);
				MyDataContext.Default.BloodPressures.DeleteObject(logToDelete);
				MyDataContext.Default.SaveChanges();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region Filter_TextChanged
		protected void Filter_TextChanged(Object sender, EventArgs e)
		{
			try
			{
				this.FillListAndChart();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}
