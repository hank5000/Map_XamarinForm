using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using XFDevGPS1.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace XFDevGPS1.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
		}

		public SQLite.SQLiteConnection GetConnection(string dbName)
		{
			var sqliteFilename = dbName;
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			var conn = new SQLite.SQLiteConnection(path);

			// Return the database connection 
			return conn;
		}
	}
}

