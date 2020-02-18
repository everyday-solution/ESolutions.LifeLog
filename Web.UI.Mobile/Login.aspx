<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Login" %>

<%@ Register Assembly="ESolutions.Web" Namespace="ESolutions.Web.UI" TagPrefix="es" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>MyLifeLog</title>
	<es:FileLinkControl ID="StyleFile" runat="server" File="~/Layout/Screen.css" />
	<es:FileLinkControl ID="JqueryFile" runat="server" File="~/Scripts/jquery-1.8.2.min.js" />
	<es:FileLinkControl ID="FileLinkControl1" runat="server" File="~/Scripts/jquery.watermark.min.js" />
	<meta name="viewport" content="width = 320" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="login">
			<div class="credentials">
				mylifelog
			</div>
			<div class="credentials">
				<asp:TextBox runat="server" ID="UsernameTextBox" ClientIDMode="Static" />
			</div>
			<div class="credentials">
				<asp:TextBox runat="server" ID="PasswordTextBox" ClientIDMode="Static" TextMode="Password" />
			</div>
			<div class="credentials">
				<asp:ImageButton runat="server" ID="LoginButton2" OnClick="LoginButton_Click" Text="login" ImageUrl="~/Layout/login.png" />
			</div>
			<div id="error" class="credentials">
				<asp:Label runat="server" ID="ErrorLabel" Visible="false" />
			</div>
		</div>
	</form>
</body>
</html>
