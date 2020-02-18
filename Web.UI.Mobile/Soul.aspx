<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Soul.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Soul" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	what's on your mind
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="soul">
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
				type
			</div>
			<div>
				<asp:RadioButtonList runat="server" ID="EntryTypeRadioButton">
					<asp:ListItem Text="success" Value="0" />
					<asp:ListItem Text="happiness" Value="1" />
				</asp:RadioButtonList>
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				note
			</div>
			<div>
				<asp:TextBox runat="server" ID="NoteTextBox" TextMode="MultiLine" CssClass="note" />
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CommandsPlaceHolder" runat="server">
	<asp:ImageButton runat="server" ID="SaveButton" ImageUrl="~/Layout/Save.png" AlternateText="save" ToolTip="save" OnClick="SaveButton_Click" />
</asp:Content>
