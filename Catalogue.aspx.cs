using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Logic;
using Islamic_Dreams.Models;

namespace Islamic_Dreams
{
	public partial class Catalogue : System.Web.UI.Page
	{

		protected void Page_Init(object sender, EventArgs e)
		{

			AddTriggers(btnDelete.UniqueID);
			AddTriggers(btnSave.UniqueID);
			AddTriggers(btnNo.UniqueID);
			AddTriggers(rptKey.UniqueID);
			AddTriggers(btnUpdate.UniqueID);
			AddTriggers(ddlBooks.UniqueID);
			AddTriggers(ddlKeyword.UniqueID);
			AddTriggers(ddlImams.UniqueID);

			AddAsyncPostBackTrigger(ddlImamsUpdate.UniqueID);
			AddAsyncPostBackTrigger(ddlBooksReffUpdate.UniqueID);
			AddAsyncPostBackTrigger(ddlKeywordUpdate.UniqueID);

		}
		public void AddTriggers(string ControlID)
		{

			UpdatePanel UP = (UpdatePanel)this.Page.Master.FindControl("UpdatePanelWebsiteHeader"); ;
			UpdatePanelControlTrigger trigger = new PostBackTrigger();
			trigger.ControlID = ControlID;
			UP.Triggers.Add(trigger);
		}
		public void AddAsyncPostBackTrigger(string ControlID)
		{

			UpdatePanel UP = (UpdatePanel)this.Page.Master.FindControl("UpdatePanelWebsiteHeader"); ;
			UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
			trigger.ControlID = ControlID;
			UP.Triggers.Add(trigger);
		}



		protected void Page_Load(object sender, EventArgs e)
		{

			((Label)Master.FindControl("pageTitle")).Text = "Catalogue";
			RegisterPostBackControl();
			//	this.Alert.Text = "Username or Password is incorrect!".ToAlert(Islamic_Dreams.Alert.Danger);
			if (!IsPostBack)
			{



				var imams = Logic.Business.GetImams().Select(s => new DropDown
				{
					Text = s.IMAM_ENG ,
					Value = s.IMAM_ID,
				}).ToList();

				this.ddlImams.DataSource = imams;
				this.ddlImams.DataTextField = "Text";
				this.ddlImams.DataValueField = "Value";
				this.ddlImams.DataBind();
				//this.ddlImams_OnSelectedIndexChanged(null, null);

				this.ddlImamsUpdate.DataSource = imams.Where(s => s.Value != 0).ToList();
				this.ddlImamsUpdate.DataTextField = "Text";
				this.ddlImamsUpdate.DataValueField = "Value";
				this.ddlImamsUpdate.DataBind();
				this.ddlImamsUpdate_OnSelectedIndexChanged(null, null);
				var data = Logic.Business.GetBooks().Select(s => new DropDown
				{
					Text = s.BOOK_ENG ,
					Value = s.BOOK_ID,
				}).ToList();


				this.ddlBooks.DataSource = data;
				this.ddlBooks.DataTextField = "Text";
				this.ddlBooks.DataValueField = "Value";
				this.ddlBooks.DataBind();
				this.ddlBooks_OnSelectedIndexChanged(null, null);

				this.ddlBooksReffUpdate.DataSource = data;
				this.ddlBooksReffUpdate.DataTextField = "Text";
				this.ddlBooksReffUpdate.DataValueField = "Value";
				this.ddlBooksReffUpdate.DataBind();
				UpdateKeyword();
			}

		}

		private void BindGrid(int? Book, int? Keyword)
		{
			int? Imam = null;
			if (ddlImams.SelectedItem.Value != "0")
				Imam = int.Parse(ddlImams.SelectedValue);
			this.rptKey.DataSource = Logic.Business.GetDreamsCatalog(Book, Keyword, Imam);
			this.rptKey.DataBind();
			RegisterPostBackControl();
		}
		private void RegisterPostBackControl()
		{
			foreach (RepeaterItem r in rptKey.Items)
			{
				CheckBox c = r.FindControl("CheckBox1") as CheckBox;
				//DO whatever
				LinkButton box = r.FindControl("edit") as LinkButton;
				AddAsyncPostBackTrigger(box.UniqueID);
				LinkButton box1 = r.FindControl("Delete") as LinkButton;
				AddAsyncPostBackTrigger(box1.UniqueID);

			}
		}
		protected void btnSave_OnClick(object sender, EventArgs e)
		{
			var word = new DATA_SETS
			{
				FK_KEY_CODE = int.Parse(this.ddlKeyword.SelectedItem.Value.ToString()),
				DATA_ENGLISH = txtEnglish.Text,
				DATA_URDU = txtUrdu.Text,
				FK_IMAM_CODE = int.Parse(this.ddlImams.SelectedItem.Value.ToString()),
			};
			if (!Logic.Business.Add(word))
			{
				this.Alert.Text = "Exception Occured! While Dream Information".ToAlert(Islamic_Dreams.Alert.Danger);

				return;
			}

			this.Alert.Text = "Keyword has been Added Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			ddlKeyword_OnSelectedIndexChanged(null, null);

			this.txtUrdu.Text = string.Empty;
			this.txtEnglish.Text = string.Empty;
		}

		protected void rptKey_OnItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{


				case ("Delete"):
					int id = Convert.ToInt32(e.CommandArgument);
					this.Key.Value = id.ToString();

					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
						"<script>$('#delete').modal('show');</script>", false);
					//Page.ClientScript.RegisterStartupScript(this.GetType(),"CallMyFunction","MyFunction()",true);

					break;

				case ("Edit"):
				
					int val = Convert.ToInt32(e.CommandArgument);
					this.Key.Value = val.ToString();
					var data = Logic.Business.GetCompleteDream(val);
					this.txtUrduUpdate.Text = data.DATA_URDU;
					this.txtEnglishUpdate.Text = data.DATA_ENGLISH;
					try
					{
						this.ddlBooksReffUpdate.SelectedValue = data.BOOK_ID.ToString();
						this.ddlKeywordUpdate.SelectedValue = data.KEY_CODE.ToString();
						if (data.IMAM_ID != null)
							this.ddlImamsUpdate.SelectedValue = data.IMAM_ID.Value.ToString();
					}
					catch (Exception exception)
					{

					}

					//Edit(val);
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
						"<script>$('#UpdateModel').modal('show');</script>", false);
					break;
			}
		}

		protected void btnNo_OnClick(object sender, EventArgs e)
		{
			

			this.txtEnglish.Text = string.Empty;
			this.txtUrdu.Text = string.Empty;

			ClearModelbackdrop();

		}

		protected void btnDelete_OnClick(object sender, EventArgs e)
		{

			if (Logic.Business.DeleteDream(int.Parse(Key.Value)))
			{
				this.Alert.Text = "Dream Information has been deleted!.".ToAlert(Islamic_Dreams.Alert.Success);
				BindGrid(int.Parse(this.ddlBooks.SelectedValue), int.Parse(this.ddlKeyword.SelectedValue));
			}
			else
				this.Alert.Text = "Exception Occured! While Deleting Dream ".ToAlert(Islamic_Dreams.Alert.Danger);

			ClearModelbackdrop();
		}

		private void ClearModelbackdrop()
		{
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
				"<script>$('.modal-backdrop').remove();</script>", false);
		}

		protected void btnUpdate_OnClick(object sender, EventArgs e)
		{
			

			var word = new DATA_SETS
			{

				DATA_ENGLISH = txtEnglishUpdate.Text,
				DATA_URDU = txtUrduUpdate.Text,
				DATA_ID = int.Parse(Key.Value),
				FK_IMAM_CODE = null,
				FK_KEY_CODE = 0,


			};
			if (this.ddlImamsUpdate.SelectedItem.Value.ToString() != string.Empty)
				word.FK_IMAM_CODE = int.Parse(this.ddlImamsUpdate.SelectedItem.Value.ToString());
			if (this.ddlKeywordUpdate.SelectedItem.Value.ToString() != string.Empty)
				word.FK_KEY_CODE = int.Parse(this.ddlKeywordUpdate.SelectedItem.Value.ToString());


			if (!Logic.Business.Update(word))
			{
				this.Alert.Text = "Exception Occured! While Updating Dream".ToAlert(Islamic_Dreams.Alert.Danger);

				return;
			}

			this.Alert.Text = "Dream has been Updated Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			btnNo_OnClick(null, null);
			BindGrid(int.Parse(this.ddlBooks.SelectedValue), int.Parse(this.ddlKeyword.SelectedValue));
			this.txtEnglish.Text = string.Empty;
			this.txtUrdu.Text = string.Empty;
		}

		protected void ddlBooks_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblTitle.Text = "Reference Book : " + this.ddlBooks.SelectedItem.Text;

			try
			{
				this.ddlKeyword.DataSource = Business.GetKeyword(int.Parse(this.ddlBooks.SelectedValue)).Select(
					s => new DropDown
					{
						Text = s.KEY_ENGLISH ,
						Value = s.KEY_CODE,
					}).ToList();
				this.ddlKeyword.DataTextField = "Text";
				this.ddlKeyword.DataValueField = "Value";
				this.ddlKeyword.DataBind();
			}
			catch (Exception exception)
			{

			}
			this.ddlKeyword_OnSelectedIndexChanged(null, null);

		}

		protected void ddlKeyword_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			this.ddlImams_OnSelectedIndexChanged(null, null);
			return;
			try
			{
				this.lblTitle2.Text = "Keyword :" + this.ddlKeyword.SelectedItem.Text;
				BindGrid(int.Parse(this.ddlBooks.SelectedValue), int.Parse(this.ddlKeyword.SelectedValue));
				divSave.Visible = true;

			}
			catch (Exception exception)
			{
				BindGrid(int.Parse(this.ddlBooks.SelectedValue), null);
				divSave.Visible = false;
			}


		}

		protected void UpdateKeyword()
		{
			this.lblTitleUpdate.Text = "Reference Book : " + this.ddlBooksReffUpdate.SelectedItem.Text;

			try
			{
				this.ddlKeywordUpdate.DataSource = Business.GetKeyword(int.Parse(this.ddlBooksReffUpdate.SelectedValue)).Select(
					s => new DropDown
					{
						Text = s.KEY_ENGLISH ,
						Value = s.KEY_CODE,
					}).ToList();
				this.ddlKeywordUpdate.DataTextField = "Text";
				this.ddlKeywordUpdate.DataValueField = "Value";
				this.ddlKeywordUpdate.DataBind();
				this.lblTitle2Update.Text = "Keyword : " + this.ddlKeywordUpdate.SelectedItem.Text;
			}
			catch (Exception exception)
			{

			}

		}

		protected void ddlBooksReffUpdate_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblTitleUpdate.Text = "Reference Book : " + this.ddlBooksReffUpdate.SelectedItem.Text;

			try
			{
				this.ddlKeywordUpdate.DataSource = Business.GetKeyword(int.Parse(this.ddlBooksReffUpdate.SelectedValue)).Select(
					s => new DropDown
					{
						Text = s.KEY_ENGLISH ,
						Value = s.KEY_CODE,
					}).ToList();
				this.ddlKeywordUpdate.DataTextField = "Text";
				this.ddlKeywordUpdate.DataValueField = "Value";
				this.ddlKeywordUpdate.DataBind();
			}
			catch (Exception exception)
			{

			}
			this.ddlKeywordUpdate_OnSelectedIndexChanged(null, null);
		}

		protected void ddlKeywordUpdate_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.lblTitle2Update.Text = "Keyword : " + this.ddlKeywordUpdate.SelectedItem.Text;
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
					"<script>$('#UpdateModel').modal('show');</script>", false);
			}
			catch (Exception exception)
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
					"<script>$('#UpdateModel').modal('show');</script>", false);
			}
		}

		protected void ddlImams_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.lblTitle2.Text = "Keyword : " + this.ddlKeyword.SelectedItem.Text;
				this.lblTitle3.Text = "Imam : " + this.ddlImams.SelectedItem.Text;
				BindGrid(int.Parse(this.ddlBooks.SelectedValue), int.Parse(this.ddlKeyword.SelectedValue));
				divSave.Visible = this.ddlImams.SelectedValue != "0";

			}
			catch (Exception exception)
			{
				BindGrid(int.Parse(this.ddlBooks.SelectedValue), null);
				divSave.Visible = false;
			}




		}

		protected void ddlImamsUpdate_OnSelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}