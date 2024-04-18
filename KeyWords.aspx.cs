using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Models;

namespace Islamic_Dreams
{
	public partial class KeysWords : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{

			AddTriggers(btnDelete.UniqueID);
			AddTriggers(btnSave.UniqueID);
			AddTriggers(btnNo.UniqueID);
			AddTriggers(rptKey.UniqueID);
			AddTriggers(btnUpdate.UniqueID);
			AddTriggers(ddlBooks.UniqueID);

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
			((Label)Master.FindControl("pageTitle")).Text = "Keywords";

			//	this.Alert.Text = "Username or Password is incorrect!".ToAlert(Islamic_Dreams.Alert.Danger);
			if (!IsPostBack)
			{

				var book = Logic.Business.GetBooks().Select(s => new DropDown
				{
					Text = s.BOOK_ENG + "(" + s.BOOK_URDU + ")",
					Value = s.BOOK_ID,
				}).ToList();
				this.ddlBooks.DataSource = book;
				this.ddlBooks.DataTextField = "Text";
				this.ddlBooks.DataValueField = "Value";
				this.ddlBooks.DataBind();
				ddlBookReffUpdate.DataSource = book;
				this.ddlBookReffUpdate.DataTextField = "Text";
				this.ddlBookReffUpdate.DataValueField = "Value";
				this.ddlBookReffUpdate.DataBind();
				this.ddlBooks_OnSelectedIndexChanged(null,null);
				BindGrid();
			}

		}

		private void BindGrid()
		{
			this.rptKey.DataSource = Logic.Business.GetKeyWords(int.Parse(this.ddlBooks.SelectedValue));
			this.rptKey.DataBind();
			this.RegisterPostBackControl();
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
			var word = new KEY_WORDS
			{
				FK_BOOK_REF = int.Parse(this.ddlBooks.SelectedItem.Value),
				KEY_ENGLISH = txtEnglish.Text,
				KEY_URDU = txtUrdu.Text,
			};
			if (!Logic.Business.Add(word))
			{
				this.Alert.Text = "Exception Occured! While Saving Keyword".ToAlert(Islamic_Dreams.Alert.Danger);
				BindGrid();
				return;
			}
			this.Alert.Text = "Keyword has been Added Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			BindGrid();
			this.txtEnglish.Text = string.Empty;
			this.txtUrdu.Text = string.Empty;
		}

		protected void rptKey_OnItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{


				case ("Delete"):
					int id = Convert.ToInt32(e.CommandArgument);
					this.key.Value = id.ToString();
					
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
						"<script>$('#delete').modal('show');</script>", false);
					//Page.ClientScript.RegisterStartupScript(this.GetType(),"CallMyFunction","MyFunction()",true);

					break;

				case ("Edit"):
					this.btnUpdate.Visible = true;
					this.btnSave.Visible = false;
					int val = Convert.ToInt32(e.CommandArgument);
					this.key.Value = val.ToString();
					var data = Logic.Business.GetKeyWord(val);
					this.txtUrduUpdate.Text = data.KEY_URDU;
					this.txtEnglishUpdate.Text = data.KEY_ENGLISH;
					this.ddlBookReffUpdate.SelectedValue = data.FK_BOOK_REF+"";
					this.lblTitleUpdate.Text = "Reference Book : " + this.ddlBookReffUpdate.SelectedItem.Text;

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
			Response.Redirect("KeyWords");
		}

		protected void btnDelete_OnClick(object sender, EventArgs e)
		{

			if (Logic.Business.DeleteKeyword(int.Parse(key.Value)))
			{
				this.Alert.Text = "Book Information has been deleted!.".ToAlert(Islamic_Dreams.Alert.Success);
			}
			else
				this.Alert.Text = "Exception Occured! While Deleting Book ".ToAlert(Islamic_Dreams.Alert.Danger);
			BindGrid();
		}
	

		protected void btnUpdate_OnClick(object sender, EventArgs e)
		{
			this.btnUpdate.Visible = false;
			this.btnSave.Visible = true;

			var word = new KEY_WORDS
			{
				FK_BOOK_REF = int.Parse(this.ddlBookReffUpdate.SelectedItem.Value),
				KEY_ENGLISH = txtEnglishUpdate.Text,
				KEY_URDU = txtUrduUpdate.Text,
				KEY_CODE = int.Parse(key.Value)
			};
			if (!Logic.Business.Update(word))
			{
				this.Alert.Text = "Exception Occured! While Updating Keyword".ToAlert(Islamic_Dreams.Alert.Danger);
				BindGrid();
				return;
			}
			this.Alert.Text = "Keyword has been Updated Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			btnNo_OnClick(null, null);
			BindGrid();
			this.txtEnglishUpdate.Text = string.Empty;
			this.txtUrduUpdate.Text = string.Empty;
		}

		protected void ddlBooks_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblTitle.Text = "Reference Book : "+this.ddlBooks.SelectedItem.Text;
			BindGrid();
		}
	}

}