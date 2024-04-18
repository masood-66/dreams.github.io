﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lock.aspx.cs" Inherits="Islamic_Dreams.Lock" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
	<title>Veltrix - Admin Dashboard Template | Themesbrand</title>
	<meta content="Responsive admin theme build on top of Bootstrap 4" name="description" />
	<meta content="Themesbrand" name="author" />
	<link rel="shortcut icon" href="assets/images/favicon.ico">

	<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
	<link href="assets/css/icons.css" rel="stylesheet" type="text/css">
	<link href="assets/css/style.css" rel="stylesheet" type="text/css">
</head>

<body class="bg-primary">
	<form id="form1" runat="server">
		<div class="home-btn d-none d-sm-block">
			<a href="Login.aspx" class="text-white"><i class="fas fa-home h2"></i></a>
		</div>

		<div class="account-pages my-5 pt-5">
			<div class="container">
				<div class="row justify-content-center">
					<div class="col-md-8 col-lg-6 col-xl-5">
						<div class="card bg-pattern shadow-none">
							<div class="card-body">
								<div class="text-center mt-4">
									<div class="mb-3">
										<a href="index.html" class="logo">
											<img src="assets/images/logo-light.png" height="20" alt="logo"></a>
									</div>
								</div>
								<div class="text-left p-3">
									<h4 class="font-18 text-center">Locked</h4>
									<p class="text-muted text-center">Hello, enter your password to unlock the screen!</p>

								

										<div class="user-thumb text-center mb-4">
											<img src="assets/images/users/user-6.jpg" class="rounded-circle img-thumbnail thumb-lg" alt="thumbnail">
											<h6 class="mt-3">
												<asp:Label runat="server" Text="Safwan Hashmi" ID="lblUsername"/>
												
											</h6>
										</div>


										<div class="form-group">
											<label for="userpassword">Password</label>
											
											<asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Enter password"/>
										</div>

										<div class="form-group row">
											<div class="col-12 text-right">
												<asp:Button runat="server" Text="Unlock" CssClass="btn btn-primary w-md waves-effect waves-light" ID="btnUnlock" OnClick="btnUnlock_OnClick" />
											</div>
										</div>

									

								</div>

							</div>
						</div>
						<div class="mt-5 text-center text-white-50">
							<p>Not you ? return <a href="pages-login-2.html" class="font-500 text-white">Sign In </a></p>
							<p>© 2019 Veltrix. <i class="mdi mdi-heart text-danger"></i>by xeosolutions</p>
						</div>
					</div>
				</div>
			</div>
		</div>


		<!-- jQuery  -->
		<script src="assets/js/jquery.min.js"></script>
		<script src="assets/js/bootstrap.bundle.min.js"></script>
		<script src="assets/js/jquery.slimscroll.js"></script>
		<script src="assets/js/waves.min.js"></script>

		<!-- App js -->
		<script src="assets/js/app.js"></script>
	</form>
</body>

</html>
