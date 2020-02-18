using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;
using System.Drawing;
using ESolutions.Web.UI;

namespace ESolutions.LifeLog.Web.UI
{
	[ESolutions.Web.UI.PageUrl("~/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.Session.GetCurrentUser() == null)
			{
				this.NotLoggedInPanel.Visible = true;
				this.LoggedInPanel.Visible = false;
			}
			else
			{
				this.NotLoggedInPanel.Visible = false;
				this.LoggedInPanel.Visible = true;
			}
		}
		#endregion

		#region Page_PreRender
		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (this.Session.GetCurrentUser() != null)
			{
				var latestMeasure = Models.BodyMeasure.FindLatestEntryWithPicture(this.Session.GetCurrentUser());
				if (latestMeasure != null)
				{
					this.AfterImage.ImageUrl = latestMeasure.GetFrontPictureUrl();
					this.AfterDateLabel.Text = latestMeasure.Date.ToShortDateString();
				}

				var firstMeasure = Models.BodyMeasure.FindFirstEntryWithPicture(this.Session.GetCurrentUser());
				if (firstMeasure != null)
				{
					this.BeforeImage.ImageUrl = firstMeasure.GetFrontPictureUrl();
					this.BeforeDateLabel.Text = firstMeasure.Date.ToShortDateString();
				}

				var measures = Models.BodyMeasure.FindAll(this.Session.GetCurrentUser());
				this.FillChart(measures);
			}
		}
		#endregion

		#region FillChart
		private void FillChart(BodyMeasureCollection userValues)
		{
			var ascendingValues = from current in userValues
										 orderby current.Date ascending
										 select current;

			foreach (BodyMeasure current in ascendingValues)
			{
				this.Chart1.Series["Weight"].Points.Add(current.Weight);
				this.Chart1.Series["Fat"].Points.Add(current.FatAbsolute);
				this.Chart1.Series["Weight"].Points[this.Chart1.Series["Weight"].Points.Count - 1].AxisLabel = current.Date.ToShortDateString();
			}
		}
		#endregion

		#region LoginLink_Click
		protected void LoginLink_Click(Object sender, EventArgs e)
		{
			this.ResponseAddOn.Redirect<LoginForm>();
		}
		#endregion

		#region CreateLink_Click
		protected void CreateLink_Click(Object sender, EventArgs e)
		{
			this.ResponseAddOn.Redirect<Me.Create>();
		}
		#endregion
	}
}
