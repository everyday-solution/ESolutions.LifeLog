<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Heart.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Heart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	mind your pump
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="heart">
		<div class="edit_group">
			<div class="caption">
				date
			</div>
			<div>
				<asp:TextBox runat="server" ID="DateTextBox" type="date" />
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
				heart rate (bpm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="HeartRateTextBox" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				systolic (mmHG)
			</div>
			<div>
				<asp:TextBox runat="server" ID="SystolicTextBox" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				diastolic (mmHG)
			</div>
			<div>
				<asp:TextBox runat="server" ID="DiastolicTextBox" />
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CommandsPlaceHolder" runat="server">
	<asp:ImageButton runat="server" ID="SaveButton" ImageUrl="~/Layout/Save.png" AlternateText="save" ToolTip="save" OnClick="SaveButton_Click" />
</asp:Content>
