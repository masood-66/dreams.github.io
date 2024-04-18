using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Islamic_Dreams.Models;

namespace Islamic_Dreams
{
	public partial class SearchIndex : System.Web.UI.Page
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
			((Label)Master.FindControl("pageTitle")).Text = "Indexing";

			//	this.Alert.Text = "Username or Password is incorrect!".ToAlert(Islamic_Dreams.Alert.Danger);
			if (!IsPostBack)
			{
				BindGrid();
			}

		}

		private void BindGrid()
		{
			this.rptKey.DataSource = Logic.Business.GetIndexs();
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
			var word = new INDEX_TABLE
			{
				
				INDEX_ENGLISH = txtEnglish.Text,
				INDEX_URDU = txtUrdu.Text,
				INDEX_STATUS = true,
				TOTAL_COUNT = 0,
			};
			if (!Logic.Business.Add(word))
			{
				this.Alert.Text = "Exception Occured! While Saving Index".ToAlert(Islamic_Dreams.Alert.Danger);
				BindGrid();
				return;
			}
			this.Alert.Text = "Index has been Added Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			BindGrid();
			this.txtEnglish.Text = string.Empty;
			this.txtUrdu.Text = string.Empty;
		}

		protected void rptKey_OnItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{

				case ("Toggle"):
					int Toggleid = Convert.ToInt32(e.CommandArgument);
					this.key.Value = Toggleid.ToString();
					if (Logic.Business.ToggleIndex(int.Parse(key.Value)))
					{
						this.Alert.Text = "Index Toggle Status has been Changed!.".ToAlert(Islamic_Dreams.Alert.Success);
					}
					else
						this.Alert.Text = "Exception Occured! While Updating Index ".ToAlert(Islamic_Dreams.Alert.Danger);
					BindGrid();

					break;

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
					var data = Logic.Business.GetIndex(val);
					this.txtUrduUpdate.Text = data.INDEX_URDU;
					this.txtEnglishUpdate.Text = data.INDEX_ENGLISH;
					
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
			Response.Redirect("SearchIndex");
		}

		protected void btnDelete_OnClick(object sender, EventArgs e)
		{

			if (Logic.Business.DeleteIndex(int.Parse(key.Value)))
			{
				this.Alert.Text = "Index Information has been deleted!.".ToAlert(Islamic_Dreams.Alert.Success);
			}
			else
				this.Alert.Text = "Exception Occured! While Deleting Index ".ToAlert(Islamic_Dreams.Alert.Danger);
			BindGrid();
		}


		protected void btnUpdate_OnClick(object sender, EventArgs e)
		{
			this.btnUpdate.Visible = false;
			this.btnSave.Visible = true;

			var word = new INDEX_TABLE
			{
				INDEX_ENGLISH = txtEnglishUpdate.Text,
				INDEX_URDU = txtUrduUpdate.Text,
				INDEX_ID = int.Parse(key.Value)
			};
			if (!Logic.Business.Update(word))
			{
				this.Alert.Text = "Exception Occured! While Updating Index".ToAlert(Islamic_Dreams.Alert.Danger);
				BindGrid();
				return;
			}
			this.Alert.Text = "Index has been Updated Successfully!".ToAlert(Islamic_Dreams.Alert.Success);
			btnNo_OnClick(null, null);
			BindGrid();
			this.txtEnglishUpdate.Text = string.Empty;
			this.txtUrduUpdate.Text = string.Empty;
		}

		protected void ddlBooks_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected String GetCssClast(object eval)
		{
			if (eval == null)
				return "btn btn-light btn-sm rounded-0";
			if (bool.Parse(eval.ToString()))
				return "btn btn-info btn-sm rounded-0";
			return "btn btn-light btn-sm rounded-0";
		}

		protected string GetToggleCssClass(object eval)
		{
			
			if (eval == null)
				return "fa fa-toggle-off";
			if (bool.Parse(eval.ToString()))
				return "fa fa-toggle-on";
			return "fa fa-toggle-off";

		}
	}
}