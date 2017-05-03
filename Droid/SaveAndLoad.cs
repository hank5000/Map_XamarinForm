using System;
using System.IO;
using Xamarin.Forms;
using XFDevGPS1.Droid;


[assembly: Dependency (typeof (SaveAndLoad))]
namespace XFDevGPS1.Droid
{
	public class SaveAndLoad : ISaveAndLoad
	{
		public SaveAndLoad()
		{
			
		}

		public string LoadText(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);

			return System.IO.File.ReadAllText(filePath);
		}

		public void SaveText(string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);

			System.IO.File.WriteAllText(filePath, text);
		}

		public string GetPath(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return filePath;
		}
	}
}
