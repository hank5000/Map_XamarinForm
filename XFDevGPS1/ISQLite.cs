using System;
using SQLite;

namespace XFDevGPS1
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}