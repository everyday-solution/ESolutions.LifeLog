using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ESolutions.LifeLog.Models
{
	public partial class User
	{
		//Properties
		#region Gender
		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		public Genders Gender
		{
			get
			{
				return (Genders)this.gender;
			}
			set
			{
				this.gender = (int)value;
			}
		}
		#endregion

		#region Age
		public Int32 Age
		{
			get
			{
				return DateTime.Now.Year - this.DateOfBirth.Year;
			}
		}
		#endregion

		//Methods
		#region FindByEmail
		public static User FindByEmail(String email)
		{
			var result = from current in MyDataContext.Default.Users
							 where current.Email == email
							 select current;
			return result.FirstOrDefault();
		}
		#endregion

		#region Login
		public static User Login(String username, String password)
		{
			Models.User user = Models.User.FindByEmail(username);

			if (user == null)
			{
				throw new Exception("Sorry. Either the username is unknown or the password is missspelled.");
			}

			SHA512Managed hasher = new SHA512Managed();
			Byte[] hash = hasher.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(password)));
			String databaseHashAsString = Encoding.UTF8.GetString(user.Hash);
			String enteredHashAsString = Encoding.UTF8.GetString(hash);

			if (databaseHashAsString != enteredHashAsString)
			{
				throw new Exception("Sorry. Either the username is unknown or the password is missspelled.");
			}

			return user;
		}
		#endregion

		#region Exists
		public static Boolean Exists(String email)
		{
			return User.FindByEmail(email) != null;
		}
		#endregion

		#region Create
		public static User Create(
			String email,
			String password,
			DateTime dateOfBirth,
			Int32 height,
			Genders gender)
		{
			if (User.Exists(email))
			{
				throw new Exception("A user with this email address already exists");
			}

			Models.User result = new User();
			result.Guid = Guid.NewGuid();
			result.Email = email;
			result.Hash = new SHA512Managed().ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(password)));
			result.DateOfBirth = dateOfBirth;
			result.HeightInCentimeters = height;
			result.Gender = gender;

			MyDataContext.Default.Users.AddObject(result);
			MyDataContext.Default.SaveChanges();

			return result;
		}
		#endregion

		#region CalculateNormalWeight
		/// <summary>
		/// Calculates the normal weight in kg according to the Broca-Index (Daybridge)
		/// </summary>
		/// <returns></returns>
		public static Double CalculateNormalWeight(Int32 heightInCentimeter)
		{
			return heightInCentimeter - 100;
		}
		#endregion

		#region CalculateNormalWeight
		/// <summary>
		/// Calculates the normal weight in kg according to the Broca-Index (Daybridge)
		/// </summary>
		/// <returns></returns>
		public Double CalculateNormalWeight()
		{
			return User.CalculateNormalWeight(this.HeightInCentimeters);
		}
		#endregion

		#region CalculateIdealWeight
		public static Double CalculateIdealWeight(Int32 heightInCentimeter, Genders gender)
		{
			Double result = 0.0;

			switch (gender)
			{
				case Genders.Male:
				{
					result = User.CalculateNormalWeight(heightInCentimeter) * 0.9;
					break;
				}
				case Genders.Female:
				{
					result = User.CalculateNormalWeight(heightInCentimeter) * 0.85;
					break;
				}
			}

			return result;
		}
		#endregion

		#region CalculateIdealWeight
		/// <summary>
		/// Calculates the ideal weight kg according to the Broca-Index.
		/// </summary>
		/// <returns></returns>
		public Double CalculateIdealWeight()
		{
			return User.CalculateIdealWeight(this.HeightInCentimeters, this.Gender);
		}
		#endregion

		#region ChangePassword
		public void ChangePassword(string newPassword)
		{
			this.Hash = new SHA512Managed().ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(newPassword)));
			MyDataContext.Default.SaveChanges();
		}
		#endregion

		public int CalculateConsumptionOfDay(DateTime date)
		{
			var nearestMeasure = Models.BodyMeasure.FindNearestToDate(this, date.Date);
			var actions = from runner in this.ActionLogs
							  where runner.Date.Date == date.Date
							  select runner;

			Int32 tmr = nearestMeasure == null ? 0 : nearestMeasure.CalculateTotalMetabolicRate();
			Int32 action = actions.Sum(runner => runner.CalcConsumption());

			return tmr + action;
		}
	}
}
