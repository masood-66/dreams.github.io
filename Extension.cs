using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Islamic_Dreams
{
	public enum Alert
	{
		Primary,
		Secondary,
		Success,
		Danger,
		Warning,
		Info,
	
	}
	public static class Extension
	{
		public static string ToAlert(this string message, Alert alert)
		{
			switch (alert)
			{
				case Alert.Primary:
					return "<div class='alert alert-primary' role='alert'>" +
					       message + "</div>";
				case Alert.Secondary:
					return "<div class='alert alert-secondary' role='alert'>" +
					       message + "</div>";
				case Alert.Danger:
					return "<div class='alert alert-danger' role='alert'>" +
					       message + "</div>";

				case Alert.Success:
					return "<div class='alert alert-success' role='alert'>" +
					       message + "</div>";
					
				case Alert.Warning:
					return "<div class='alert alert-Warning' role='alert'>" +
					       message + "</div>";
				case Alert.Info:
					return "<div class='alert alert-info' role='alert'>" +
					       message + "</div>";

				default:
					return message;
			}
		}
	}
}