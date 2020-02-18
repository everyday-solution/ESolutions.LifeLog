<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageLinkButton.ascx.cs"
	Inherits="ESolutions.LifeLog.Web.UI.ImageLinkButton" %>
<asp:LinkButton runat="server" ID="Button1" OnClick="Button1_Click" CssClass="my_image_button">
	<asp:Label runat="server" ID="Label1" CssClass="label" />
	<asp:Image runat="server" ID="Image1" CssClass="image" />
</asp:LinkButton>