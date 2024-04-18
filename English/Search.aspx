<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Islamic_Dreams.English.Search" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		.ui-menu-item-wrapper {
			
			font-size: 20px;
			text-align: left;
		}

		.ui-widget-content {
			border: 1px solid #dddddd;
			background-color: black;
			
			font-size: 34px;
			text-align: left;
		}

		.ui-widget.ui-widget-content {
			border: 1px solid #c5c5c5;
			background-color: #131f30;
			color: white;
			color: #fff;
			display: block;
			font-size: 20px;
			color: #fff;
			margin: 10px 0;
		}
		.ref-content-list-one ul li {
   
    position: relative;
    padding-right: 18px;
    font-family: sans-serif;
    font-size: 24px;
    font-weight: 200;
}
		.ref-content-list-one ul li:after {
    content: "";
    display: block;
    width: 10px;
    height: 10px;
    background: white;
    border-radius: 50%;
    position: absolute;
    top: 17px;
    right: 0;
}
		.ref-content-list-one ul li:before {
    content: "";
    display: block;
    width: 10px;
    height: 10px;
    background: #0a0100;
    border-radius: 50%;
    position: absolute;
    top: 17px;
    left: 0;
}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<!-- ref area start -->
	<div class="ref">
		<div class="container">
			<div class="ref-wrapper">
				<div class="ref-content text-center">
					<h2 style="color:#9d7444;">
						<asp:Label runat="server" ID="lblSearch" />
					</h2>
					<br />
					<br />
					<h3 style="font-family: sans-serif; color: #dcac6e; text-align: center">
						<asp:Label runat="server" ID="lblError" />
					</h3>
				</div>
				<asp:Repeater runat="server" ID="rptSearch">
					<ItemTemplate>
						<div class="ref-content-list">
							<div class="ref-content-list-one" style="text-align:justify;">
								<div class="text-left">
									<p dir="ltr" style="border: 0px; font-family: sans-serif; font-size: 40px; font-weight: 600; letter-spacing: normal">
										<small class="Author"></small>
										<asp:Label runat="server" Text='<%#Eval("Author") %>' style="color:#dcac6e;" />
									</p>
								</div>
								<ul>
									<asp:Repeater runat="server" DataSource='<%#Eval("Dreams") %>'>
										<ItemTemplate>
											<li>
												<asp:Label runat="server" Text='<%#Eval("Text") %>' />
											</li>
										</ItemTemplate>
									</asp:Repeater>

								</ul>
							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>


			</div>
		</div>
	</div>
	<!-- ref area end -->

</asp:Content>
