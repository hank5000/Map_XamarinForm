using System;
namespace XFDevGPS1
{
	public interface ISaveAndLoad
	{
		void SaveText(string filename, string text);
		string LoadText(string filename);
		string GetPath(string filename);
	}
}
