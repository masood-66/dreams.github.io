using System;
using  Islamic_Dreams.Session;
namespace Islamic_Dreams
{
	public partial class Site : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["Title"] = "Dreams in Islam";
				var login = new Management().Get();
				if (login == null)
					Response.Redirect("Login");
			}
		}

		protected void OnServerClick(object sender, EventArgs e)
		{
			var login = new Management();
			login.UnSet();
			if (login.Get() == null)
				Response.Redirect("Login");
			
		}
	}
}