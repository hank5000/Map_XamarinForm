using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xam.Plugin.Abstractions;

using System.Reflection;
using System.IO;
using System.Linq;

namespace XFDevGPS1
{
	public partial class XFDevGPS1Page : ContentPage
	{
		public class BaseUrlWebView : WebView { }
		DoggyDataBase fooDoggyDatabase;

        bool bInitialized = false;
		public XFDevGPS1Page()
		{
			InitializeComponent();
			fooDoggyDatabase = new DoggyDataBase();
			path.Text = $"路徑: {fooDoggyDatabase.DBPath}";
			writeBtn.Clicked += (s, e) =>
            {
                fooDoggyDatabase.DeleteAll();
                fooDoggyDatabase.SaveItem(new MyRecord
                {
                    UserName = "Vulcan Lee",
                    SelectItem = "一顆蘋果",
                    Done = false,
                });
				writeMessage.Text = $"資料已經寫入資料表內";
            };
            readBtn.Clicked += (s, e) =>
            {
                var fooItem = fooDoggyDatabase.GetItems().FirstOrDefault();

				readMessage.Text = $"從資料表內讀取: {fooItem.UserName} / {fooItem.SelectItem}";
            };





			Task.Run(() => StartListening());

            var htmlSource = new HtmlWebViewSource();
			htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
			htmlSource.Html = loadMapHtml();

            WebMap.Source = htmlSource;
            WebMap.VerticalOptions = LayoutOptions.FillAndExpand;
		}


        private String loadMapHtml() {
			var assembly = typeof(XFDevGPS1Page).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("XFDevGPS1.map.html");

			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
            return text;
        }

		async Task StartListening()
		{
			await CrossGeolocator.Current.StartListeningAsync(1, 0.001);

			CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
		}

        private void SetMark(double lat, double lng) {
			WebMap.Eval(string.Format("setMark({0}, {1})", lat, lng));
		}

        private void SetCenter(double lat, double lng) {
			WebMap.Eval(string.Format("newLocation({0}, {1})", lat, lng));
        }

        private void MoveMark(double lat, double lng) {
            WebMap.Eval(string.Format("moveMark({0}, {1})", lat, lng));
        }

		private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				var test = e.Position;

				listenLabel.Text = "Full: Lat: " + test.Latitude.ToString() + " Long: " + test.Longitude.ToString();
                listenLabel.Text += "\n" + $"Time: {test.Timestamp.ToLocalTime().ToString()}";
				listenLabel.Text += "\n" + $"Heading: {test.Heading.ToString()}";
                listenLabel.Text += "\n" + $"Speed: {(test.Speed*1.60931).ToString()}";
				listenLabel.Text += "\n" + $"Accuracy: {test.Accuracy.ToString()}";
				listenLabel.Text += "\n" + $"Altitude: {test.Altitude.ToString()}";
				listenLabel.Text += "\n" + $"AltitudeAccuracy: {test.AltitudeAccuracy.ToString()}";

				MoveMark(test.Latitude, test.Longitude);
                //SetCenter(test.Latitude, test.Longitude);
			});
		}

	}
}
