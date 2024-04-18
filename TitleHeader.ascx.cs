using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Islamic_Dreams
{
	public partial class TitleHeader : System.Web.UI.UserControl
	{
		private String m_LabelText;
		public String LabelText
		{
			get { return pageTitle.Text; }
			set { pageTitle.Text = value; }
		}

		public String Text
		{
			get { return pageTitle.Text; }
			set { pageTitle.Text = value; }
		}
		protected void Page_Load(object sender, EventArgs e)
		{

		}


	}
}