using System;
using Foundation;
using Xamarin.Forms;
using XFDevGPS1.iOS;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace XFDevGPS1.iOS
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
			return NSBundle.MainBundle.BundlePath;
		}
    }
}
