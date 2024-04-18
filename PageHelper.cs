namespace Islamic_Dreams
{
	public class PageHelper : System.Web.UI.UserControl
	{

		public PageHelper()
		{
		}

		public PageHelper(string title)
		{
			Session.Add("Pagestitle", title);
		}

	}
}