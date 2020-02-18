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
	[PageUrl("~/Body.aspx")]
	public partial class Body : ESolutions.Web.UI.Page
	{
		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.DateTextBox.Text = DateTime.Now.ToDeviceString(this.Request.Browser);

					Models.BodyMeasure measure = Models.BodyMeasure.FindLatest(this.Session.GetCurrentUser());
					if (measure != null)
					{
						this.WeightTextBox.Text = measure.Weight.ToString("0.0");
						this.FatTextBox.Text = measure.FatPercentage.ToString("0.0");
						this.WaterTextBox.Text = measure.WaterPercentage.ToString("0.0");

						this.ChestTextBox.Text = measure.ChestMeasurement.ToString("0");
						this.BellyTextBox.Text = measure.AbdominalMeasurement.ToString("0");
						this.HipTextBox.Text = measure.HipMeasurement.ToString("0");

						this.LeftArmTextBox.Text = measure.LeftUpperArm.ToString("0");
						this.RightArmTextBox.Text = measure.RightUpperArm.ToString("0");
						this.LeftLegTextBox.Text = measure.LeftUpperLeg.ToString("0");
						this.RightLegTextBox.Text = measure.RightUpperLeg.ToString("0");
					}

					this.ActivityLevelList.DataSource = Models.PhysicalActivityLevel.LoadAll();
					this.ActivityLevelList.DataBind();
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
				Models.BodyMeasure newEntry = new Models.BodyMeasure(this.Session.GetCurrentUser());
				newEntry.Date = DateTime.Parse(this.DateTextBox.Text);
				newEntry.PhysicalActivityLevel = this.ActivityLevelList.SelectedValue.ToDouble();
				newEntry.HeightInCentimeters = this.Session.GetCurrentUser().HeightInCentimeters;

				newEntry.Weight = this.WeightTextBox.Text.ToDouble();
				newEntry.FatPercentage = this.FatTextBox.Text.ToDouble();
				newEntry.WaterPercentage = this.WaterTextBox.Text.ToDouble();

				newEntry.ChestMeasurement = this.ChestTextBox.Text.ToInt32();
				newEntry.AbdominalMeasurement = this.BellyTextBox.Text.ToInt32();
				newEntry.HipMeasurement = this.HipTextBox.Text.ToInt32();

				newEntry.LeftUpperArm = this.LeftArmTextBox.Text.ToInt32();
				newEntry.RightUpperArm = this.RightArmTextBox.Text.ToInt32();
				newEntry.LeftUpperLeg = this.LeftLegTextBox.Text.ToInt32();
				newEntry.RightUpperLeg = this.RightLegTextBox.Text.ToInt32();

				newEntry.FrontPictureGuid = this.FrontImageUpload.FileBytes.Length > 0 ? (Guid?)Guid.NewGuid() : null;
				newEntry.SidePictureGuid = this.SideImageUpload.FileBytes.Length > 0 ? (Guid?)Guid.NewGuid() : null;

				Models.MyDataContext.Default.BodyMeasures.AddObject(newEntry);
				Models.MyDataContext.Default.SaveChanges();

				newEntry.SaveFrontImage(this.FrontImageUpload.FileBytes);
				newEntry.SaveSideImage(this.SideImageUpload.FileBytes);

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