using System;
namespace XFDevGPS1
{
	public class VehicleCloudResponse
	{
		public VehicleCloudResponse()
		{
		}

		public string code { set; get; }
		public string message  { set; get; }
		public string fileName { set; get; }
		public string fileSize { set; get; }
		public string extension { set; get; }
		public string MimeType { set; get; }
	}
}
