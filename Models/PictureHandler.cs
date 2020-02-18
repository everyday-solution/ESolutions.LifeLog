using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ESolutions.Drawing;

namespace ESolutions.LifeLog.Models
{
	public class PictureHandler
	{
		#region SaveImage
		public static void SaveImage(Byte[] fileData, Guid guid)
		{
			if (fileData.Length > 0)
			{
				MemoryStream stream = null;
				Bitmap originalBitmap = null;
				Bitmap resizedBitmap = null;

				try
				{
					stream = new MemoryStream(fileData);
					originalBitmap = new Bitmap(stream);
					resizedBitmap = originalBitmap.Resize(800);

					String filename = String.Format(LifeLogSettings.Default.AbsolutePicturePathPattern, guid.ToString());
					resizedBitmap.Save(filename, ImageFormat.Jpeg);
				}
				finally
				{
					if (originalBitmap != null)
					{
						originalBitmap.Dispose();
						originalBitmap = null;
					}

					if (resizedBitmap != null)
					{
						resizedBitmap.Dispose();
						resizedBitmap = null;
					}

					if (stream != null)
					{
						stream.Close();
						stream = null;
					}
				}
			}
		}
		#endregion

		#region DeleteImage
		public static void DeleteImage(Guid guid)
		{
			String filename = String.Format(LifeLogSettings.Default.AbsolutePicturePathPattern, guid.ToString());
			File.Delete(filename);
		}
		#endregion
	}
}