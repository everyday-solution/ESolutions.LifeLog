using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESolutions.LifeLog.Models
{
	public class BloodPressureCollection : List<BloodPressure>
	{
		//Properties
		#region AverageHeartRate
		/// <summary>
		/// Gets the average heart rate in beats per minute
		/// </summary>
		public Double AverageHeartRate
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.HeartRate);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageSystolic
		/// <summary>
		/// Gets the average systolic pressure.
		/// </summary>
		public Double AverageSystolic
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.Systolic);
				return total / this.Count;
			}
		}
		#endregion

		#region AverageDiastolic
		/// <summary>
		/// Gets the average diastolic
		/// </summary>
		public Double AverageDiastolic
		{
			get
			{
				Double total = 0.0;
				this.ForEach(current => total += current.Diastolic);
				return total / this.Count;
			}
		}
		#endregion

		//Constructors
		#region BloodPressureCollection
		public BloodPressureCollection (IEnumerable<BloodPressure> collection) : base(collection)
		{

		}
		#endregion
	}
}
