using System;
using System.Web.UI.WebControls;

namespace Islamic_Dreams
{
	public partial class Dashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			((Label)Master.FindControl("pageTitle")).Text = "Dashboard";
		}

	}
}