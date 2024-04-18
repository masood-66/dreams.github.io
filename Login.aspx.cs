using System;
using Islamic_Dreams.Logic;

namespace Islamic_Dreams
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogin_OnClick(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text))
					return;
				var user = Logic.Business.Authenticate(txtUsername.Text, txtPassword.Text.ToUpper());
				if (user == null)
				{
					return;
				}

				Response.Redirect("Dashboard");
			}
			catch (Exception exception)
			{
				this.Alert.Text="Username or Password is incorrect!".ToAlert(Islamic_Dreams.Alert.Danger);
				return;
			}
		}
	}
}