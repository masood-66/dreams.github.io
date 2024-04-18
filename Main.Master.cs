using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Logic;

namespace Islamic_Dreams
{
	public partial class Main : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected string GetKeywords()
		{
			var collections = Business.GetIndexs().Where(s=>s.INDEX_STATUS==true).Select(s => s.INDEX_URDU).ToList();
			var str = "";
			foreach (var itm in collections)
			{
				str = str + "'" + itm+"',";
			}

			return str;
		}
		protected void btnSearch_OnServerClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tags.Value.Trim()))
				return;
			Session.Add("Search", tags.Value);
			Response.Redirect("Search");

		}

		protected void tags_OnServerChange(object sender, EventArgs e)
		{
			btnSearch_OnServerClick(null, null);
		}
	}
}