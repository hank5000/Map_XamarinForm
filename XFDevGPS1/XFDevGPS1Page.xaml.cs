using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xam.Plugin.Abstractions;

using System.Reflection;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace XFDevGPS1
{
	public partial class XFDevGPS1Page : ContentPage
	{
		public class BaseUrlWebView : WebView { }
		DoggyDataBase fooDoggyDatabase;
        ETrackDatabase eTrackDatabase;
		int count = 0;
		public XFDevGPS1Page()
		{
			InitializeComponent();
			//fooDoggyDatabase = new DoggyDataBase();
            eTrackDatabase = new ETrackDatabase();

			path.Text = $"路徑: {eTrackDatabase.DBPath}";

			writeBtn.Clicked += (s, e) =>
            {
				//eTrackDatabase.DeleteAll();
				eTrackDatabase.SaveItem(new ETrackItem
				{
					car_id = "hank",
					user_id = count++,
					gps_latitude = 22.101,
					gps_longitude = -120.111,
                });

				writeMessage.Text = $"資料已經寫入資料表內";
            };

            readBtn.Clicked += (s, e) =>
            {
				var trackItem = eTrackDatabase.GetItems().FirstOrDefault();

				readMessage.Text = $"從資料表內讀取: {trackItem.car_id} / {trackItem.user_id} / {trackItem.gps_latitude} / {trackItem.gps_longitude} / {trackItem.dt}";

				eTrackDatabase.DeleteItem(trackItem.ID);
			
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

		async Task UploadToS3(ETrackItem[] items)
		{
			foreach (var item in items)
			{
				string json = JsonConvert.SerializeObject(item);
				Device.BeginInvokeOnMainThread(() =>
				{
					readMessage.Text = json;
				});
			}

			
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

		private GPSStatus gpsStatus;
		private int numberOfETrackItems = 0;

		private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				var test = e.Position;

				if (gpsStatus == null)
				{
					gpsStatus = new GPSStatus
					{
						lat = test.Latitude,
						lng = test.Longitude,
						speed = Convert.ToInt32(test.Speed),
						timestamp = test.Timestamp.ToLocalTime().ToString(),
					};
				}
				else
				{
					gpsStatus.update(test.Latitude, test.Longitude, Convert.ToInt32(test.Speed), test.Timestamp.ToLocalTime().ToString());
				}


				eTrackDatabase.SaveItem(new ETrackItem
				{
					car_id = "",
					user_id = 26,
					gps_latitude = gpsStatus.lat,
					gps_longitude = gpsStatus.lng,
					mileage = gpsStatus.mileage,
					vehicle_speed = gpsStatus.speed,
					dt = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                });
				numberOfETrackItems++;
				writeMessage.Text = $"{numberOfETrackItems}";

				if (numberOfETrackItems >= 3)
				{
					ETrackItem[] eTrackItems = eTrackDatabase.GetItems().ToArray();
					eTrackDatabase.DeleteAll();
					numberOfETrackItems = 0;
					UploadToS3(eTrackItems);
				}


				listenLabel.Text = "Full: Lat: " + gpsStatus.lat.ToString() + " Long: " + gpsStatus.lng.ToString();
				listenLabel.Text += "\n" + $"Time: {gpsStatus.timestamp}";
				listenLabel.Text += "\n" + $"Speed: {gpsStatus.speed.ToString()}";
				listenLabel.Text += "\n" + $"Mileage: {gpsStatus.mileage}";

				MoveMark(test.Latitude, test.Longitude);
                //SetCenter(test.Latitude, test.Longitude);
			});
		}

	}
}
