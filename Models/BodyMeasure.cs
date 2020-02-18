using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public partial class BodyMeasure
	{
		//Classes
		#region Properties
		public static class Properties
		{
			public const String UserGuid = "UserGuid";
			public const String Date = "Date";
		}
		#endregion

		//Constructors
		#region BodyMeasure
		internal BodyMeasure()
		{
			this.Guid = Guid.NewGuid();
		}
		#endregion

		#region BodyMeasure
		public BodyMeasure(Models.User user)
			: this()
		{
			this.UserGuid = user.Guid;
		}
		#endregion

		//Properties
		#region FatAbsolute
		public Double FatAbsolute
		{
			get
			{
				Double result = 0.0;
				result = this.Weight / 100 * this.FatPercentage;
				result = Math.Round(result, 1);

				return result;
			}
		}
		#endregion

		#region WaterAbsolute
		public Double WaterAbsolute
		{
			get
			{
				Double result = 0.0;
				result = this.Weight / 100 * this.WaterPercentage;
				result = Math.Round(result, 1);

				return result;
			}
		}
		#endregion

		#region TotalCircumfence
		public Double TotalCircumfence
		{
			get
			{
				return
					this.LeftUpperArm +
					this.RightUpperArm +
					this.ChestMeasurement +
					this.AbdominalMeasurement +
					this.HipMeasurement +
					this.LeftUpperLeg +
					this.RightUpperLeg;
			}
		}
		#endregion

		//Methods
		#region FindAll
		public static BodyMeasureCollection FindAll(Models.User user)
		{
			var result = from runner in MyDataContext.Default.BodyMeasures
							 where runner.UserGuid == user.Guid
							 orderby runner.Date descending
							 select runner;

			return new BodyMeasureCollection(result.ToList());
		}
		#endregion

		#region FindAll
		public static BodyMeasureCollection FindAll(
			Models.User user,
			DateTime fromDate,
			DateTime untilDate)
		{
			var result = from runner in MyDataContext.Default.BodyMeasures
							 where runner.UserGuid == user.Guid
							 && fromDate <= runner.Date && runner.Date <= untilDate
							 orderby runner.Date descending
							 select runner;

			return new BodyMeasureCollection(result.ToList());
		}
		#endregion

		#region FindLatestEntry
		public static BodyMeasure FindLatest(User user)
		{
			var result = from current in MyDataContext.Default.BodyMeasures
							 where current.UserGuid == user.Guid
							 orderby current.Date descending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region FindNearestToDate
		public static BodyMeasure FindNearestToDate(User user, DateTime date)
		{
			BodyMeasure result = null;

			BodyMeasure before = BodyMeasure.FindNearestBeforeDate(user, date);

			if (before != null)
			{
				result = before;
			}
			else
			{
				BodyMeasure after = BodyMeasure.FindNearestAfterDate(user, date);

				if (after != null)
				{
					result = after;
				}
			}

			return result;
		}
		#endregion

		#region FindNearestBeforeDate
		private static BodyMeasure FindNearestBeforeDate(User user, DateTime date)
		{
			DateTime adjustedDate = date.Date.AddDays(1).AddSeconds(-1);
			var result = from current in MyDataContext.Default.BodyMeasures
							 where current.UserGuid == user.Guid
							 && current.Date <= adjustedDate
							 orderby current.Date descending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region FindNearestAfterDate
		private static BodyMeasure FindNearestAfterDate(User user, DateTime date)
		{
			DateTime adjustedDate = date.Date.AddDays(1).AddSeconds(-1);
			var result = from current in MyDataContext.Default.BodyMeasures
							 where current.UserGuid == user.Guid
							 && current.Date >= adjustedDate
							 orderby current.Date ascending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region CalculateBmi
		public Double CalculateBmi()
		{
			Double heightInMeters = Convert.ToDouble(this.HeightInCentimeters) / Convert.ToDouble(100);
			Double result = this.Weight / (heightInMeters * heightInMeters);
			result = Math.Round(result, 1);
			return result;
		}
		#endregion

		#region CalculateBaseMetabolicRate
		/// <summary>
		/// Calculates the base metabolic rate according to the Harris-Benedict-Formular in kcal
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		public Int32 CalculateBaseMetabolicRate()
		{
			Double result = 0;

			Double adjustedWeight = this.CalculateAdjustedWeight();

			switch (this.User.Gender)
			{
				case Genders.Male:
				{
					result = 66.47 + (13.7 * adjustedWeight) + (5 * this.HeightInCentimeters) - (6.8 * this.User.Age);
					break;
				}
				case Genders.Female:
				{
					result = 665.1 + (9.6 * adjustedWeight) + (1.8 * this.HeightInCentimeters) - (4.7 * this.User.Age);
					break;
				}
			}

			return Convert.ToInt32(result);
		}
		#endregion

		#region CalculateTotalMetabolicRate
		/// <summary>
		/// Calculates the total metabolic rate. We make the assumption that one sleep
		/// 8 hours per night and the rest of the day corresponds to the activity chosen.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		public Int32 CalculateTotalMetabolicRate()
		{
			Double wakeRate = 16 * this.PhysicalActivityLevel;
			Double sleepRate = 8 * 0.95;
			Double totalRate = (wakeRate + sleepRate) / 24;

			Double result = this.CalculateBaseMetabolicRate() * totalRate;
			return Convert.ToInt32(result);
		}
		#endregion

		#region CalculateAdjustedWeight
		/// <summary>
		/// Calculates the adjusted weight which is the body weight if the bmi is under 30. Above
		/// 30 the formular ideal-weight + ((weight - idealweight)*0.25) is applied.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <param name="dailyEvaluation">The adjusted weight.</param>
		/// <returns></returns>
		private Double CalculateAdjustedWeight()
		{
			Double result = 0.0;

			if (this.CalculateBmi() >= 30)
			{
				Double idealWeight = Models.User.CalculateIdealWeight(this.HeightInCentimeters, this.User.Gender);
				result = idealWeight + ((this.Weight - idealWeight) * 0.25);
			}
			else
			{
				result = this.Weight;
			}

			return result;
		}
		#endregion

		#region LoadSingle
		public static BodyMeasure LoadSingle(System.Guid guid)
		{
			return Models.MyDataContext.Default.BodyMeasures.SingleOrDefault(current => current.Guid == guid);
		}
		#endregion

		#region GetFrontPictureUrl
		public String GetFrontPictureUrl()
		{
			return
				this.FrontPictureGuid.HasValue ?
				String.Format(LifeLogSettings.Default.RealtivePictureUrlPattern, this.FrontPictureGuid.Value.ToString()) :
				String.Empty;
		}
		#endregion

		#region GetSidePictureUrl
		public String GetSidePictureUrl()
		{
			return
				this.SidePictureGuid.HasValue ?
				String.Format(LifeLogSettings.Default.RealtivePictureUrlPattern, this.SidePictureGuid.Value.ToString()) :
				String.Empty;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			if (this.FrontPictureGuid.HasValue)
			{
				Models.PictureHandler.DeleteImage(this.FrontPictureGuid.Value);
			}
			if (this.SidePictureGuid.HasValue)
			{
				Models.PictureHandler.DeleteImage(this.SidePictureGuid.Value);
			}
			MyDataContext.Default.DeleteObject(this);
			MyDataContext.Default.SaveChanges();
		}
		#endregion

		#region FindFirstEntryWithPicture
		public static BodyMeasure FindFirstEntryWithPicture(Models.User user)
		{
			var result = from current in MyDataContext.Default.BodyMeasures
							 where current.UserGuid == user.Guid
							 && current.FrontPictureGuid.HasValue
							 orderby current.Date ascending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region FindLatestEntryWithPicture
		public static BodyMeasure FindLatestEntryWithPicture(User user)
		{
			var result = from current in MyDataContext.Default.BodyMeasures
							 where current.UserGuid == user.Guid
							 && current.FrontPictureGuid.HasValue
							 orderby current.Date descending
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region SaveFrontImage
		public void SaveFrontImage(byte[] imageData)
		{
			if (this.FrontPictureGuid.HasValue)
			{
				Models.PictureHandler.SaveImage(imageData, this.FrontPictureGuid.Value);
			}
		}
		#endregion

		#region SaveSideImage
		public void SaveSideImage(byte[] imageDate)
		{
			if (this.SidePictureGuid.HasValue)
			{
				Models.PictureHandler.SaveImage(imageDate, this.SidePictureGuid.Value);
			}
		}
		#endregion
	}
}
