using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Models;

namespace Islamic_Dreams
{
	public partial class Search : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Session["Search"] != null)
				{
					if (string.IsNullOrEmpty(Session["Search"].ToString()))
					{
						this.lblError.Text = "معذرت خواہ ہیں،  لفظ نہیں ملا۔";
						return;
					}
					this.lblSearch.Text = Session["Search"].ToString();
					var data = Logic.Business.GetDreamsByAuthor(Session["Search"].ToString(),false);
					this.rptSearch.DataSource = data.ToArray();
					this.rptSearch.DataBind();
					if (data.Count < 1)
					{
						this.lblError.Text = "معذرت خواہ ہیں،  لفظ نہیں ملا۔";

						var words = this.lblSearch.Text.Split(' ');
						foreach (var word in words)
						{
							if (word.Length >= 3)
								Logic.Business.Add(new INDEX_TABLE
								{
									INDEX_URDU = word,
									INDEX_ENGLISH = word,
									INDEX_STATUS = false,
									TOTAL_COUNT = 0,
								});
						}
					}


				}

				else
				{
					this.lblError.Text = "معذرت خواہ ہیں،  لفظ نہیں ملا۔";
				}


			}
		}

		protected void btnSearch_OnServerClick(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void tags_OnServerChange(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}