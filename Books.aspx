<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Islamic_Dreams.Books" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="row">
		<div class="col-12">
			<asp:Literal runat="server" ID="Alert" />
		</div>

	</div>
	
			<div class="row">
				<div class="col-12">
					<div class="card">
						<div class="card-body">

							<%--<h4 class="mt-0 header-title">Reference Books</h4>--%>
							<div class="float-left d-none d-md-block">
								<button type="button" class="btn btn-secondary waves-effect" data-toggle="modal" data-target="#Add">Add</button>

							</div>
						
							<asp:Repeater runat="server" ID="rptKey" OnItemCommand="rptKey_OnItemCommand" >
								<HeaderTemplate>
									<table id="datatable-buttons" class="table table-striped table-bordered dt-responsive nowrap" style="border-collapse: collapse; border-spacing: 0; width: 100%;">
										<thead style="font-size: 14px">
											<tr>
												<th>ID</th>
												<th>English</th>
												<th>Urdu</th>
												<th>Action</th>
											</tr>
										</thead>
										<tbody>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td>
											<asp:Label runat="server" Text='<%# Container.ItemIndex + 1 %>' /></td>
										<td  class="text-wrap" style="width: 40%">
											<asp:Label runat="server" Text='<%#Eval("BOOK_ENG") %>' /></td>
										<td class="text-wrap" style="width: 40%">
											<asp:Label runat="server" Text='<%#Eval("BOOK_URDU") %>' /></td>

										<td style="width: 20%">


											<!-- Call to action buttons -->
											<ul class="list-inline m-0">
												
												<li class="list-inline-item">
													<asp:LinkButton runat="server" ID="edit" CommandName="Edit" CommandArgument='<%#Eval("BOOK_ID") %>' class="btn btn-success btn-sm rounded-0"><i class="fa fa-edit"></i></asp:LinkButton>

												</li>
												<li class="list-inline-item">
													<asp:LinkButton runat="server" ID="Delete" CommandName="Delete" CommandArgument='<%#Eval("BOOK_ID") %>' class="btn btn-danger btn-sm rounded-0"><i class="fa fa-trash"></i></asp:LinkButton>
												</li>

											</ul>
										</td>
									</tr>
								</ItemTemplate>
								<FooterTemplate>
									</tbody>
							</table>
								</FooterTemplate>
							</asp:Repeater>
							

						</div>
					</div>
				</div>
				<!-- end col -->
			</div>

			<!-- end row -- >

	<!--  Modal content for the above example -->
			<div class="modal fade bs-example-modal-lg" id="Add" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" data-backdrop="static">
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title mt-0" id="myLargeModalLabel">Add Reference book </h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close" runat="server" onserverclick="btnNo_OnClick">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
							<div class="card">
								<div class="card-body">

									<div class="needs-validation" novalidate="">
										<div class="row">
											<div class="col-md-12">
												<div class="form-group">
													<label for="txtEnglish">Book Name in English</label>
													<asp:TextBox runat="server" ID="txtEnglish" CssClass="form-control" placeholder="Enter Book Name in English" TextMode="MultiLine" Rows="2" />
													<div class="valid-feedback">
														Looks good!
													</div>
												</div>
											</div>

										</div>
										<div class="row">
											<div class="col-md-12">
												<div class="form-group">
													<label for="txtUrdu">
														اردو میں کتاب کا نام
													</label>
													<asp:TextBox runat="server" ID="txtUrdu" CssClass="form-control text-right" placeholder="کتاب کا نام لکھیں" TextMode="MultiLine" Rows="2" />
													<div class="valid-feedback">
														Looks good!
													</div>
												</div>
											</div>

										</div>
										<asp:Button runat="server" ID="btnSave" class="btn btn-primary" OnClick="btnSave_OnClick" Text="Save" />

									</div>
								</div>
							</div>

						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->
			<div class="modal fade bs-example-modal-lg" id="Update" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" data-backdrop="static">
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title mt-0" id="myLargeModalLabel">Update Reference book </h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close"  runat="server" onserverclick="btnNo_OnClick">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
							<div class="card">
								<div class="card-body">

									<div class="needs-validation" novalidate="">
										<div class="row">
											<div class="col-md-12">
												<div class="form-group">
													<label for="txtEnglish">Book Name in English</label>
													<asp:TextBox runat="server" ID="txtEnglishUpdate" CssClass="form-control" placeholder="Enter Book Name in English" TextMode="MultiLine" Rows="2" />
													<div class="valid-feedback">
														Looks good!
													</div>
												</div>
											</div>

										</div>
										<div class="row">
											<div class="col-md-12">
												<div class="form-group">
													<label for="txtUrdu">
														اردو میں کتاب کا نام
													</label>
													<asp:TextBox runat="server" ID="txtUrduUpdate" CssClass="form-control text-right" placeholder="کتاب کا نام لکھیں" TextMode="MultiLine" Rows="2" />
													<div class="valid-feedback">
														Looks good!
													</div>
												</div>
											</div>

										</div>
										<asp:Button runat="server" ID="btnUpdate" class="btn btn-primary" OnClick="btnUpdate_OnClick" Text="Update" Visible="True" />

									</div>
								</div>
							</div>

						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- Modal -->
			<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static">
				<div class="modal-dialog" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title" id="exampleModalLabel">Confirmation Message</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close" runat="server" onserverclick="btnNo_OnClick">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
							Are you sure you want to delete ?
					<br />
							<asp:HiddenField runat="server" ID="BoodID" />
						</div>
						<div class="modal-footer">
							<asp:Button runat="server" class="btn btn-primary" Text="Yes" ID="btnDelete" OnClick="btnDelete_OnClick" />
							<asp:Button runat="server" class="btn btn-secondary" Text="No" ID="btnNo" OnClick="btnNo_OnClick" />
						</div>
					</div>
				</div>
			</div>
		

</asp:Content>
