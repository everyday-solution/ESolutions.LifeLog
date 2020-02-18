<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	keep on moving
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="action">
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
				action
			</div>
			<div>
				<asp:DropDownList runat="server" ID="ActionList" DataValueField="Guid" DataTextField="Name" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				duration
			</div>
			<div>
				<asp:TextBox runat="server" ID="DurationTextBox" />
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CommandsPlaceHolder" runat="server">
	<asp:ImageButton runat="server" ID="SaveButton" ImageUrl="~/Layout/Save.png" AlternateText="save" ToolTip="save" OnClick="SaveButton_Click" />
</asp:Content>
