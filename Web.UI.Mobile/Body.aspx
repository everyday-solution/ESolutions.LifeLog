<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Body.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Body" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	keep in shape
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="body">
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
				activity level
			</div>
			<div>
				<asp:DropDownList runat="server" ID="ActivityLevelList" DataValueField="Factor" DataTextField="Name" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				weight (kg)
			</div>
			<div>
				<asp:TextBox runat="server" ID="WeightTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				fat (%)
			</div>
			<div>
				<asp:TextBox runat="server" ID="FatTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				water (%)
			</div>
			<div>
				<asp:TextBox runat="server" ID="WaterTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				chest (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="ChestTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				belly (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="BellyTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				hip (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="HipTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				left upper arm (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="LeftArmTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				right upper arm (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="RightArmTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				left upper leg (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="LeftLegTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				right upper leg (cm)
			</div>
			<div>
				<asp:TextBox runat="server" ID="RightLegTextBox" Text="0" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				front view
			</div>
			<div>
				<asp:FileUpload runat="server" ID="FrontImageUpload" />
			</div>
		</div>
		<div class="edit_group">
			<div class="caption">
				side view
			</div>
			<div>
				<asp:FileUpload runat="server" ID="SideImageUpload" />
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CommandsPlaceHolder" runat="server">
	<asp:ImageButton runat="server" ID="SaveButton" ImageUrl="~/Layout/Save.png" AlternateText="save" ToolTip="save" OnClick="SaveButton_Click" />
</asp:Content>
