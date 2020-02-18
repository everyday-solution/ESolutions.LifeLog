using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESolutions.LifeLog.Models;
using ESolutions.Web.UI;
using ESolutions.LifeLog.Web.UI;

namespace ESolutions.LifeLog.Web.UI.Body
{
	[ESolutions.Web.UI.PageUrl("~/Body/Default.aspx")]
	public partial class Default : ESolutions.Web.UI.Page
	{
		//Methods
		#region Page_Load
		protected void Page_Load(Object sender, EventArgs e)
		{
			try
			{
				if (!this.IsPostBack)
				{
					this.FilterFromTextBox.Text = DateTime.Now.AddDays(-7).ToShortDateString();
					this.FilterUntilTextBox.Text = DateTime.Now.ToShortDateString();

					this.ActivityFactorList.DataSource = PhysicalActivityLevel.LoadAll();
					this.ActivityFactorList.DataBind();
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
				this.InitializeForm();

				this.MeasureRepeater.DataSource = BodyMeasure.FindAll(
					this.Session.GetCurrentUser(),
					DateTime.Parse(this.FilterFromTextBox.Text).Date,
					DateTime.Parse(this.FilterUntilTextBox.Text).Date);
				this.MeasureRepeater.DataBind();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion

		#region InitializeForm
		private void InitializeForm()
		{
			this.DateTextBox.Text = DateTime.Now.Date.ToShortDateString();

			var lastEntry = Models.BodyMeasure.FindLatest(this.Session.GetCurrentUser());
			if (lastEntry != null)
			{
				this.WeightTextBox.Text = lastEntry.Weight.ToString();
				this.FatTextBox.Text = lastEntry.FatPercentage.ToString();
				this.WaterTextBox.Text = lastEntry.WaterPercentage.ToString();
				this.ChestTextBox.Text = lastEntry.ChestMeasurement.ToString();
				this.AbdominalTextBox.Text = lastEntry.AbdominalMeasurement.ToString();
				this.HipTextBox.Text = lastEntry.HipMeasurement.ToString();
				this.ActivityFactorList.SelectedValue = lastEntry.PhysicalActivityLevel.ToString();
				this.LeftUpperArmTextBox.Text = lastEntry.LeftUpperArm.ToString();
				this.RightUpperArmTextBox.Text = lastEntry.RightUpperArm.ToString();
				this.LeftUpperLegTextBox.Text = lastEntry.LeftUpperLeg.ToString();
				this.RightUpperLegTextBox.Text = lastEntry.RightUpperLeg.ToString();
			}
			else
			{
				this.WeightTextBox.Text = "60";
				this.FatTextBox.Text = "20";
				this.WaterTextBox.Text = "50";
				this.ChestTextBox.Text = "90";
				this.AbdominalTextBox.Text = "60";
				this.HipTextBox.Text = "90";
				this.LeftUpperArmTextBox.Text = "40";
				this.RightUpperArmTextBox.Text = "40";
				this.LeftUpperLegTextBox.Text = "60";
				this.RightUpperLegTextBox.Text = "60";
			}
		}
		#endregion

		#region MeasureRepeater_ItemDataBound
		protected void MeasureRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			try
			{
				Models.BodyMeasure current = e.Item.DataItem as Models.BodyMeasure;

				if (current != null)
				{
					ImageButton deleteButton = e.Item.FindControl("DeleteButton") as ImageButton;
					deleteButton.CommandArgument = current.Guid.ToString();

					Label CurrentDateLabel = e.Item.FindControl("CurrentDateLabel") as Label;
					CurrentDateLabel.Text = current.Date.ToShortDateString();

					Label CurrentRightArmLabel = e.Item.FindControl("CurrentRightArmLabel") as Label;
					CurrentRightArmLabel.Text = current.RightUpperArm.ToString("0") + " cm";

					Label CurrentLeftArmLabel = e.Item.FindControl("CurrentLeftArmLabel") as Label;
					CurrentLeftArmLabel.Text = current.LeftUpperArm.ToString("0") + " cm";

					Label CurrentChestLabel = e.Item.FindControl("CurrentChestLabel") as Label;
					CurrentChestLabel.Text = current.ChestMeasurement.ToString("0") + " cm";

					Label CurrentBellyLabel = e.Item.FindControl("CurrentBellyLabel") as Label;
					CurrentBellyLabel.Text = current.AbdominalMeasurement.ToString("0") + " cm";

					Label CurrentHipLabel = e.Item.FindControl("CurrentHipLabel") as Label;
					CurrentHipLabel.Text = current.HipMeasurement.ToString("0") + " cm";

					Label CurrentRightLegLabel = e.Item.FindControl("CurrentRightLegLabel") as Label;
					CurrentRightLegLabel.Text = current.RightUpperLeg.ToString("0") + " cm";

					Label CurrentLeftLegLabel = e.Item.FindControl("CurrentLeftLegLabel") as Label;
					CurrentLeftLegLabel.Text = current.LeftUpperLeg.ToString("0") + " cm";

					Label CurrentWeightLabel = e.Item.FindControl("CurrentWeightLabel") as Label;
					CurrentWeightLabel.Text = current.Weight.ToString("0.0") + " kg";

					Label CurrentFatLabel = e.Item.FindControl("CurrentFatLabel") as Label;
					CurrentFatLabel.Text = String.Format("{0} % / {1} kg", current.FatPercentage, current.FatAbsolute);

					Label CurrentWaterLabel = e.Item.FindControl("CurrentWaterLabel") as Label;
					CurrentWaterLabel.Text = String.Format("{0} % / {1} kg", current.WaterPercentage, current.WaterAbsolute);

					Label CurrentTotalMeasureLabel = e.Item.FindControl("CurrentTotalMeasureLabel") as Label;
					CurrentTotalMeasureLabel.Text = current.TotalCircumfence.ToString("0") + " cm";

					if (current.FrontPictureGuid.HasValue)
					{
						Image FrontImage = e.Item.FindControl("FrontImage") as Image;
						FrontImage.ImageUrl = current.GetFrontPictureUrl();
					}

					if (current.SidePictureGuid.HasValue)
					{
						Image SideImage = e.Item.FindControl("SideImage") as Image;
						SideImage.ImageUrl = current.GetSidePictureUrl();
					}
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
				BodyMeasure newLog = new BodyMeasure(this.Session.GetCurrentUser());
				newLog.Date = DateTime.Parse(this.DateTextBox.Text);
				newLog.AbdominalMeasurement = this.AbdominalTextBox.Text.ToDouble();
				newLog.ChestMeasurement = this.ChestTextBox.Text.ToDouble();
				newLog.FatPercentage = this.FatTextBox.Text.Replace(".", ",").ToDouble();
				newLog.HipMeasurement = this.HipTextBox.Text.ToDouble();
				newLog.WaterPercentage = this.WaterTextBox.Text.Replace(".", ",").ToDouble();
				newLog.Weight = this.WeightTextBox.Text.Replace(".", ",").ToDouble();
				newLog.PhysicalActivityLevel = Convert.ToDouble(this.ActivityFactorList.SelectedValue);
				newLog.HeightInCentimeters = this.Session.GetCurrentUser().HeightInCentimeters;
				newLog.LeftUpperArm = this.LeftUpperArmTextBox.Text.ToDouble();
				newLog.RightUpperArm = this.RightUpperArmTextBox.Text.ToDouble();
				newLog.LeftUpperLeg = this.LeftUpperLegTextBox.Text.ToDouble();
				newLog.RightUpperLeg = this.RightUpperLegTextBox.Text.ToDouble();
				newLog.FrontPictureGuid = this.BodyImageUploadFront.FileBytes.Length > 0 ? (Guid?)Guid.NewGuid() : null;
				newLog.SidePictureGuid = this.BofyImageUploadSide.FileBytes.Length > 0 ? (Guid?)Guid.NewGuid() : null;

				MyDataContext.Default.BodyMeasures.AddObject(newLog);
				MyDataContext.Default.SaveChanges();

				newLog.SaveFrontImage(this.BodyImageUploadFront.FileBytes);
				newLog.SaveSideImage(this.BofyImageUploadSide.FileBytes);
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
				BodyMeasure entryToDelete = BodyMeasure.LoadSingle(argument);
				entryToDelete.Delete();
			}
			catch (Exception ex)
			{
				this.Master.ShowError(ex);
			}
		}
		#endregion
	}
}
