using System;
using Xamarin.Forms;
using XFDevGPS1.Droid;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLite_Android))]
namespace XFDevGPS1.Droid
{
	public class SQLite_Android: ISQLite
	{
		public SQLite_Android()
		{
		}

		public SQLiteConnection GetConnection(string dbName)
		{
			var sqliteFilename = dbName;
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection 
            return conn;
		}
	}
}


