using System;
using Xamarin.Forms;
using XFDevGPS1.Droid;

[assembly: Dependency(typeof(BaseUrl_Droid))]
namespace XFDevGPS1.Droid
{
    public class BaseUrl_Droid : IBaseUrl
    {
        public string Get()
        {
			return "file:///android_asset/";
		}
    }
}
