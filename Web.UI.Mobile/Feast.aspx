<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Feast.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Feast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	do i want to consist of that
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="feast">
		<div class="edit_group">
			<div class="caption">
				date
			</div>
			<div>
				<asp:TextBox runat="server" ID="DateTextBox" type="date"/>
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				time
			</div>
			<div>
				<asp:DropDownList runat="server" ID="HourList" />
				<asp:DropDownList runat="server" ID="MinuteList" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				time
			</div>
			<div>
				<asp:FileUpload runat="server" ID="ImageUpload" />
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CommandsPlaceHolder" runat="server">
	<asp:ImageButton runat="server" ID="SaveButton" ImageUrl="~/Layout/Save.png" AlternateText="save" ToolTip="save" OnClick="SaveButton_Click" />
</asp:Content>
