using System.Configuration;

namespace Islamic_Dreams
{
	
	public static class Extensions
	{
		public static string ToAbsUrl(this string url) 
		{
			return ConfigurationManager.AppSettings["BaseUrl"] + url;
		}
	}
}