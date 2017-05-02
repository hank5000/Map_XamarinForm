using System;
namespace XFDevGPS1
{
	public class GPSStatus
	{
		public GPSStatus()
		{
		}

		public double lat { set; get; }
		public double lng { set; get; }
		public int speed { set; get; }
		public double mileage { set; get; } = 0;
		public string timestamp { set; get; }

		private double pre_lat = 0;
		private double pre_lng = 0;

		private bool bFirstUpdate = true;

		public void update(double lat, double lng, int speed, string timestamp)
		{
			if (bFirstUpdate)
			{
				bFirstUpdate = false;
                this.pre_lat = this.lat;
				this.pre_lng = this.lng;
			}
			else
			{
				double mileageGain = calculateMileage(pre_lat, pre_lng, lat, lng);
				if (mileageGain > 0)
				{
					mileage += mileageGain;
				}
				this.pre_lat = this.lat;
				this.pre_lng = this.lng;
			}
			this.lat = lat;
			this.lng = lng;
			this.speed = speed;
			this.timestamp = timestamp;
		}
		

		private double calculateMileage(double pre_lat, double pre_lng, double lat, double lng)
		{
			double result = -1;

			double latA = pre_lat * 0.0174532925f;
			double lngA = pre_lng * 0.0174532925f;
			double latB = lat * 0.0174532925f;
			double lngB = lng * 0.0174532925f;
			double cosAng = (Math.Cos(latA) * Math.Cos(latB) * Math.Cos(lngB - lngA)) +
				(Math.Sin(latA) * Math.Sin(latB));
			double ang = Math.Acos(cosAng);
			result = ang * 6371;

			return result;
		}





	
	}
}
