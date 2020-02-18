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
	[PageUrl("~/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		//Classes
		#region FeastRepeaterItemEventArgs
		private class FeastRepeaterItemEventArgs
		{
			//Constructors
			#region FeastRepeaterItemEventArgs
			public FeastRepeaterItemEventArgs(RepeaterItemEventArgs item)
			{
				this.item = item;
			}
			#endregion

			//Fields
			#region item
			private RepeaterItemEventArgs item = null;
			#endregion

			//Properties
			#region Data
			public Models.Ingestion Data
			{
				get
				{
					return this.item.Item.DataItem as Models.Ingestion;
				}
			}
			#endregion

			#region IngestionImage
			public Image IngestionImage
			{
				get
				{
					return this.item.Item.FindControl("IngestionImage") as Image;
				}
			}
			#endregion
		}
		#endregion

		//Methods
		#region Page_PreRender
		protected void Page_PreRender(Object sender, EventArgs e)
		{
			try
			{
				this.RenderHome();
				this.RenderSoul();
				this.RenderBody();
				this.RenderHeart();
				this.RenderAction();
				this.RenderFeast();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region RenderHome
		private void RenderHome()
		{
			this.HomeLink.NavigateUrl = PageUrlAttribute.Get<Default>();
			var first = Models.BodyMeasure.FindFirstEntryWithPicture(this.Session.GetCurrentUser());
			if (first != null)
			{
				this.BeforeImage.ImageUrl = first.GetFrontPictureUrl();
				this.BeforeDate.Text = first.Date.ToShortDateString();
			}

			var latest = Models.BodyMeasure.FindLatestEntryWithPicture(this.Session.GetCurrentUser());
			if (latest != null)
			{
				this.AfterImage.ImageUrl = latest.GetFrontPictureUrl();
				this.AfterDate.Text = latest.Date.ToShortDateString();
			}
		}
		#endregion

		#region RenderSoul
		private void RenderSoul()
		{
			this.SoulLink.NavigateUrl = PageUrlAttribute.Get<Soul>();
			Models.SuccessLog soul = Models.SuccessLog.FindLatest(this.Session.GetCurrentUser());
			if (soul != null)
			{
				this.SoulLabel.Text = soul.Text;
			}
		}
		#endregion

		#region RenderBody
		private void RenderBody()
		{
			this.BodyLink.NavigateUrl = PageUrlAttribute.Get<Body>();
			var bodyMeasures = Models.BodyMeasure.FindAll(this.Session.GetCurrentUser());
			var ascendingValues = from current in bodyMeasures
										 orderby current.Date ascending
										 select current;

			foreach (Models.BodyMeasure current in ascendingValues)
			{
				this.BodyChart.Series["Weight"].Points.Add(current.Weight);
				this.BodyChart.Series["Fat"].Points.Add(current.FatAbsolute);
				this.BodyChart.Series["Weight"].Points[this.BodyChart.Series["Weight"].Points.Count - 1].AxisLabel = current.Date.ToShortDateString();
			}
		}
		#endregion

		#region RenderHeart
		private void RenderHeart()
		{
			this.HeartLink.NavigateUrl = PageUrlAttribute.Get<Heart>();

			var query = from runner in this.Session.GetCurrentUser().BloodPressures
							orderby runner.Date descending
							select runner;

			Models.BloodPressureCollection heartValues = new Models.BloodPressureCollection(query.Take(21));
			var valuesAscending = from current in heartValues
										 orderby current.Date ascending
										 select current;

			foreach (Models.BloodPressure current in valuesAscending)
			{
				this.HeartChart.Series["MaxPressureSeries"].Points.Add(LifeLogSettings.Default.DefaultSystolic);
				this.HeartChart.Series["MinPressureSeries"].Points.Add(LifeLogSettings.Default.DefaultDiastolic);
				this.HeartChart.Series["HeartRateSeries"].Points.Add(current.HeartRate);
				this.HeartChart.Series["HeartRateSeries"].Points[this.HeartChart.Series["HeartRateSeries"].Points.Count - 1].AxisLabel = current.Date.ToShortDateString();
				this.HeartChart.Series["PressureSeries"].Points.Add(current.Systolic, current.Diastolic);
			}
		}
		#endregion

		#region RenderAction
		private void RenderAction()
		{
			this.ActionLink.NavigateUrl = PageUrlAttribute.Get<Action>();

			Models.User currentUser = this.Session.GetCurrentUser();
			var latest = Models.ActionLog.FindLatest(currentUser);
			DateTime untilDate = latest == null ? DateTime.Now.Date.AddDays(1).AddTicks(-1) : latest.Date;
			DateTime fromDate = untilDate.Date.AddDays(-21);

			SortedList<DateTime, Int32> consumptionPerDay = new SortedList<DateTime, Int32>();

			DateTime runner = fromDate.Date;
			while (runner <= untilDate.Date)
			{
				Int32 consumption = currentUser.CalculateConsumptionOfDay(runner);

				this.ActionChart.Series["ConsumptionSeries"].Points.Add(consumption);
				this.ActionChart.Series["ConsumptionSeries"].Points[this.ActionChart.Series["ConsumptionSeries"].Points.Count - 1].AxisLabel = runner.ToShortDateString();

				runner = runner.AddDays(1);
			}
		}
		#endregion

		#region RenderFeast
		private void RenderFeast()
		{
			this.FeastLink.NavigateUrl = PageUrlAttribute.Get<Feast>();
			this.FeastRepeater.DataSource = Models.Ingestion.FindLastest(this.Session.GetCurrentUser());
			this.FeastRepeater.DataBind();
		}
		#endregion

		#region FeastRepeater_ItemDataBound
		protected void FeastRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var ee = new FeastRepeaterItemEventArgs(e);

			if (ee.Data != null)
			{
				ee.IngestionImage.ImageUrl = ee.Data.GetPictureUrl();
			}
		}
		#endregion
	}
}