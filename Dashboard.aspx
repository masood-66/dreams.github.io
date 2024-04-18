<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Islamic_Dreams.Dashboard" %>
<%@ Reference VirtualPath="~/TitleHeader.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="row">
		<div class="col-lg-4">
			<div class="card mini-stat bg-pattern">
				<div class="card-body mini-stat-img">
					<div class="mini-stat-icon">
						<i class="dripicons-broadcast bg-soft-primary text-primary float-right h4"></i>
					</div>
					<h6 class="text-uppercase mb-3 mt-0">Keywords</h6>
					<h5 class="mb-3">1,687</h5>
					<p class="text-muted mb-0"><span class="text-success mr-2">12% <i class="mdi mdi-arrow-up"></i></span>From previous period</p>
				</div>
			</div>
		</div>
		<div class="col-lg-4">
			<div class="card mini-stat bg-pattern">
				<div class="card-body mini-stat-img">
					<div class="mini-stat-icon">
						<i class="dripicons-box bg-soft-primary text-primary float-right h4"></i>
					</div>
					<h6 class="text-uppercase mb-3 mt-0">Visitors</h6>
					<h5 class="mb-3">48,265</h5>
					<p class="text-muted mb-0"><span class="text-danger mr-2">-26% <i class="mdi mdi-arrow-down"></i></span>From previous period</p>
				</div>
			</div>
		</div>
		<div class="col-lg-4">
			<div class="card mini-stat bg-pattern">
				<div class="card-body mini-stat-img">
					<div class="mini-stat-icon">
						<i class="dripicons-tags bg-soft-primary text-primary float-right h4"></i>
					</div>
					<h6 class="text-uppercase mb-3 mt-0">Average</h6>
					<h5 class="mb-3">$ 14.6</h5>
					<p class="text-muted mb-0"><span class="text-danger mr-2">-26% <i class="mdi mdi-arrow-down"></i></span>From previous period</p>
				</div>
			</div>
		</div>
	</div>
	<!-- end row -->

	<div class="row">
		<div class="col-xl-4">
			<div class="card">
				<div class="card-body">
					<h4 class="mt-0 header-title mb-4">Weekly Trend</h4>

					<div id="area-chart" dir="ltr"></div>
				</div>
			</div>
		</div>

		<div class="col-xl-8">
			<div class="card">
				<div class="card-body">
					<h4 class="mt-0 header-title mb-4">Monthly Trend</h4>

					<div id="column-chart" dir="ltr"></div>
				</div>
			</div>
		</div>
	</div>
	<!-- end row -->
	<!-- apexcharts -->
	<script src="plugins/apexcharts/apexcharts.min.js"></script>

	<!-- Peity JS -->
	<script src="plugins/peity-chart/jquery.peity.min.js"></script>

	<script src="assets/pages/dashboard.js"></script>

</asp:Content>
