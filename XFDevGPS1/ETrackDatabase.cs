
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFDevGPS1
{
	public class ETrackDatabase
	{
		static object locker = new object();

		public string DBPath { get; set; }

		SQLiteConnection database;

		public ETrackDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection("etrack.db");
			DBPath = database.DatabasePath;
			// create the tables
			database.CreateTable<ETrackItem>();
		}

		public IEnumerable<ETrackItem> GetItems()
		{
			lock (locker)
			{
				return (from i in database.Table<ETrackItem>() select i).ToList();
			}
		}

		public IEnumerable<ETrackItem> GetItemsNotDone()
		{
			lock (locker)
			{
				return database.Query<ETrackItem>("SELECT * FROM [ETrackItem] WHERE [Done] = 0");
			}
		}

		public ETrackItem GetItem(int id)
		{
			lock (locker)
			{
				return database.Table<ETrackItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem(ETrackItem item)
		{
			lock (locker)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else
				{
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker)
			{
				return database.Delete<ETrackItem>(id);
			}
		}

		public void DeleteAll()
		{
			var fooItems = GetItems().ToList();
			foreach (var item in fooItems)
			{
				DeleteItem(item.ID);
			}
		}
	}
}

