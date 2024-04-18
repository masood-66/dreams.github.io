using System;
using Islamic_Dreams.Models;

namespace Islamic_Dreams.Session
{
	public class Management : System.Web.UI.Page
	{
		public void Set(APP_USERS appUser)
		{
			Session.Add("Login",appUser);
		}
		public APP_USERS Get()
		{

			try
			{
				var user = Session["Login"] as APP_USERS;
				return user ?? null;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		public void UnSet()
		{
			Session["Login"] = null;
			Session.Abandon();
		}
	}
}