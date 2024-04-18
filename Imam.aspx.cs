using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Models;

namespace Islamic_Dreams
{
	public partial class Imam : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{

			AddTriggers(btnDelete.UniqueID);
			AddTriggers(btnSave.UniqueID);
			AddTriggers(btnNo.UniqueID);
			AddTriggers(rptKey.UniqueID);
			AddTriggers(btnUpdate.UniqueID);
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
			RegisterPostBackControl();
			((Label)Master.FindControl("pageTitle")).Text = "Reference Imam";

			//	this.Alert.Text = "Username or Password is incorrect!".ToAlert(Islamic_Dreams.Alert.Danger);
			if (!IsPostBack)
				BindGrid();
		}

		private void BindGrid()
		{
			this.rptKey.DataSource = Logic.Business.GetImams().Where(s=>s.IMAM_ID!=0).ToList();
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
			var word = new IMAM_INFO
			{
				IMAM_ENG = txtEnglish.Text,
				IMAM_URDU = txtUrdu.Text,
			};
			if (!Logic.Business.Add(word))
			{
				this.Alert.Text = "Exception Occured! While Saving Imam Information".ToAlert(Islamic_Dreams.Alert.Danger);

				return;
			}
			this.Alert.Text = "Imam Information has been Added Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
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
					this.BoodID.Value = id.ToString();

					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
						"<script>$('#delete').modal('show');</script>", false);
					//Page.ClientScript.RegisterStartupScript(this.GetType(),"CallMyFunction","MyFunction()",true);

					break;

				case ("Edit"):
					this.btnUpdate.Visible = true;
					this.btnSave.Visible = false;
					int val = Convert.ToInt32(e.CommandArgument);
					this.BoodID.Value = val.ToString();
					var data = Logic.Business.GetImam(val);
					this.txtUrduUpdate.Text = data.IMAM_URDU;
					this.txtEnglishUpdate.Text = data.IMAM_ENG;
					//Edit(val);
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
						"<script>$('#Update').modal('show');</script>", false);
					break;
			}
		}

		protected void Button1_OnClick(object sender, EventArgs e)
		{

		}

		protected void btnNo_OnClick(object sender, EventArgs e)
		{
			this.txtEnglish.Text = string.Empty;
			this.txtUrdu.Text = string.Empty;
			Response.Redirect("Imam");

		}

		protected void btnDelete_OnClick(object sender, EventArgs e)
		{

			if (Logic.Business.DeleteImam(int.Parse(BoodID.Value)))
			{
				this.Alert.Text = "Book Information has been deleted!.".ToAlert(Islamic_Dreams.Alert.Success);
				BindGrid();
			}
			else
				this.Alert.Text = "Exception Occured! While Deleting Book ".ToAlert(Islamic_Dreams.Alert.Danger);

		}
		private void ClearModelbackdrop()
		{
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
				"<script>$('.modal-backdrop').remove();</script>", false);
		}

		protected void btnUpdate_OnClick(object sender, EventArgs e)
		{
			this.btnUpdate.Visible = false;
			this.btnSave.Visible = true;

			var word = new IMAM_INFO
			{
				IMAM_ID = int.Parse(BoodID.Value),
				IMAM_ENG = txtEnglishUpdate.Text,
				IMAM_URDU = txtUrduUpdate.Text,
			};
			if (!Logic.Business.Update(word))
			{
				this.Alert.Text = "Exception Occured! While Updating Book".ToAlert(Islamic_Dreams.Alert.Danger);

				return;
			}
			this.Alert.Text = "Imam Information has been Updated Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			btnNo_OnClick(null, null);
			BindGrid();
			this.txtEnglish.Text = txtEnglishUpdate.Text = string.Empty;
			this.txtUrdu.Text = txtUrduUpdate.Text = string.Empty;
		}
	}
}