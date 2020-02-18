using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public class BodyMeasureCollection : List<BodyMeasure>
	{
		//Properties
		#region AverageWeight
		/// <summary>
		/// Gets the average weight in kg.
		/// </summary>
		public Double AverageWeight
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.Weight);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageWaterPercentage
		/// <summary>
		/// Gets the average body water in percent.
		/// </summary>
		public Double AverageWaterPercentage
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.WaterPercentage);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageWaterAbsolute
		/// <summary>
		/// Gets the average body water in kg.
		/// </summary>
		public Double AverageWaterAbsolute
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.WaterAbsolute);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageChestCircumfence
		/// <summary>
		/// Gets the average chest circumfence.
		/// </summary>
		public Double AverageChestCircumfence
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.ChestMeasurement);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageAbdominalCircumfence
		/// <summary>
		/// Gets the average Abdominal circumfence.
		/// </summary>
		public Double AverageAbdominalCircumfence
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.AbdominalMeasurement);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageHipCircumfence
		/// <summary>
		/// Gets the average Hip circumfence.
		/// </summary>
		public Double AverageHipCircumfence
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.HipMeasurement);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageBmi
		/// <summary>
		/// Gets the average Bmi.
		/// </summary>
		public Double AverageBmi
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.CalculateBmi());
				return total / this.Count;
			}
		}
		#endregion

		#region AverageTotalMetabolicRate
		/// <summary>
		/// Gets the average Tmr.
		/// </summary>
		public Double AverageTotalMetabolicRate
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.CalculateTotalMetabolicRate());
				return total / this.Count;
			}
		}
		#endregion

		#region AverageBasalMetabolicRate
		/// <summary>
		/// Gets the average Bmr.
		/// </summary>
		public Double AverageBasalMetabolicRate
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.CalculateBaseMetabolicRate());
				return total / this.Count;
			}
		}
		#endregion

		#region AverageFatPercentage
		/// <summary>
		/// Gets the average fat in percent.
		/// </summary>
		/// <value>The average fat percentage.</value>
		public Double AverageFatPercentage
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.FatPercentage);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageFatAbsolute
		/// <summary>
		/// Gets the average absolute fat in kg.
		/// </summary>
		/// <value>The average fat absolute.</value>
		public Double AverageFatAbsolute
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.FatAbsolute);
				return total / this.Count;
			}
		}
		#endregion

		//Constructors
		#region BodyMeasureCollection
		public BodyMeasureCollection(IEnumerable<BodyMeasure> collection)
			: base(collection)
		{
		}
		#endregion
	}
}
