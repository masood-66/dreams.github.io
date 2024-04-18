using System;
using System.Configuration;

namespace Islamic_Dreams
{
	public partial class Navigation : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected string GetUrl(string page)
		{
			var url= ConfigurationManager.AppSettings["BaseUrl"] + page;
			return url;
		}
	}
}