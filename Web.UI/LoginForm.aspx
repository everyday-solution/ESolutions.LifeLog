<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="LoginForm.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.LoginForm" %>

<%@ Register TagPrefix="es" TagName="ImageLinkButton" Src="~/ImageLinkButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - login!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Panel runat="server" CssClass="CreateEntryPanel" DefaultButton="HiddenLoginButton">
		<!-- title -->
		<h1>
			<asp:Label runat="server" ID="LoginLabel" Text="login!" />
		</h1>
		<div class="MultiColumn">
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="LoginUserLabel" Text="email" />
				</div>
				<asp:TextBox runat="server" ID="LoginUserTextBox" />
			</div>
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="LoginPasswordLabel" Text="password" />
				</div>
				<asp:TextBox runat="server" ID="LoginPasswordTextBox" TextMode="Password" />
			</div>
		</div>
		<div class="MultiColumnEnd">
		</div>
		<!-- Action -->
		<div>
			<asp:Button runat="server" ID="HiddenLoginButton" OnClick="LoginButton_Click" style="display:none;" />
			<es:ImageLinkButton runat="server" ID="LoginButton" Text="login" OnClick="LoginButton_Click" ImageUrl="~/Style/Images/key1.png" />
		</div>
	</asp:Panel>
</asp:Content>
