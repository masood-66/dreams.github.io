< %@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Islamic_Dreams.Login" %>


<!DOCTYPE html>
<html lang="en">

<head runat="server">
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
	<title>Dreams in Islam </title>
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
			<a href="Home" class="text-white"><i class="fas fa-home h2"></i></a>
		</div>

		<div class="account-pages my-5 pt-5">
			<div class="container">
				<div class="row justify-content-center">
					<div class="col-md-8 col-lg-6 col-xl-5">
						<div class="card bg-pattern shadow-none">
							<div class="card-body">
								<div class="text-center mt-4">
									<div class="mb-3">
										<a href="Login class="logo">
											<img src="assets/images/favicon.png" height="60" alt="logo"></a>
									</div>
								</div>
								<div class="p-3">
									<h4 class="font-18 text-center">Welcome Back !</h4>
									<p class="text-muted text-center mb-4">Sign in to continue to Dreams in Islam.</p>


									<div class="form-group">
										<label for="username">Username</label>
										<asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Enter username"/>

									</div>

									<div class="form-group">
										<label for="userpassword">Password</label>
										<asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter password"/>
									</div>


									<div class="mt-3">
										<asp:Button runat="server" ID="btnLogin" Text="Log In" CssClass="btn btn-primary btn-block waves-effect waves-light" OnClick="btnLogin_OnClick"/>
									</div>

									<div class="mt-4 text-center">
										<a href="#"><i class="mdi mdi-lock"></i>Forgot your password?</a>
									</div>


								</div>
								<asp:Literal runat="server" ID="Alert"/>
							</div>
						</div>
						<div class="mt-5 text-center text-white-50">
						
							<p>© 2019 Dreams in Islam. <i class="mdi mdi-heart text-danger"></i>by xeo solutions</p>
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
