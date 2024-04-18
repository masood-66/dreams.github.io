<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notification.ascx.cs" Inherits="Islamic_Dreams.Notification" %>
<li class="dropdown notification-list list-inline-item" >
	<a class="nav-link dropdown-toggle arrow-none" data-toggle="dropdown" href="#" role="button" aria-haspopup="false" aria-expanded="false">
		<i class="ion ion-md-notifications noti-icon"></i>
		<span class="badge badge-pill badge-danger noti-icon-badge">1</span>
	</a>
	<div class="dropdown-menu dropdown-menu-right dropdown-menu-lg">
		<!-- item-->
		<h6 class="dropdown-item-text">Notifications (258)
		</h6>
		<div class="slimscroll notification-item-list">
			<!-- item-->
			<a href="javascript:void(0);" class="dropdown-item notify-item active">
				<div class="notify-icon bg-success"><i class="mdi mdi-cart-outline"></i></div>
				<p class="notify-details">Your order is placed<span class="text-muted">Application is not yet Deployed.</span></p>
			</a>
			<!-- item-->
			
		</div>
		<!-- All-->
		<a href="javascript:void(0);" class="dropdown-item text-center text-primary">View all <i class="fi-arrow-right"></i>
		</a>
	</div>
</li>
