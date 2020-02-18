<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Me.Default" %>

<%@ Register Src="~/ImageLinkButton.ascx" TagPrefix="es" TagName="ImageLinkButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - this is me!
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ScriptPlaceHolder">
	<script type="text/javascript">
		$(document).ready(function () {
			$.datepicker.setDefaults($.datepicker.regional['']);
			$('#DateOfBirthTextBox').datepicker($.datepicker.regional['de']);
			$('#DateOfBirthTextBox').datepicker("option", "changeMonth", true);
			$('#DateOfBirthTextBox').datepicker("option", "changeYear", true);

			$('#HeightTextBox').numericUpDown($('#HeightUpImage'), $('#HeightDownImage'), 1);
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="data_panel">
		<h1>
			<asp:Label runat="server" ID="TitleLabel" Text="this is me!" />
		</h1>
		<div class="multi_column edit">
			<!-- change user -->
			<div>
				<div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="DateOfBirthLabel" Text="date of birth" />
						</div>
						<asp:TextBox runat="server" ID="DateOfBirthTextBox" ClientIDMode="Static" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="HeightLabel" Text="height (cm)" />
						</div>
						<asp:TextBox runat="server" ID="HeightTextBox" Text="170" ClientIDMode="Static" />
						<asp:Image runat="server" ID="HeightUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png" ClientIDMode="Static" />
						<asp:Image runat="server" ID="HeightDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png" ClientIDMode="Static" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="GenderLabel" Text="gender" />
						</div>
						<asp:DropDownList runat="server" ID="GenderList">
							<asp:ListItem Text="male" Value="Male" />
							<asp:ListItem Text="female" Value="Female" />
						</asp:DropDownList>
					</div>
				</div>
				<div>
					<es:ImageLinkButton runat="server" ID="SaveButton2" Text="save" OnClick="SaveButton_Click"
						ImageUrl="~/Style/Images/key1_add.png" />
				</div>
			</div>
			<!-- new password -->
			<div>
				<div class="form_field">
					<div class="caption">
						<asp:Label runat="server" ID="PasswordLabel" Text="password" />
					</div>
					<asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password" />
				</div>
				<div class="form_field">
					<div class="caption">
						<asp:Label runat="server" ID="PasswordConfirmLabel" Text="password (confirm)" />
					</div>
					<asp:TextBox runat="server" ID="PasswordConfirmTextBox" TextMode="Password" />
				</div>
				<div>
					<es:ImageLinkButton runat="server" ID="ChangePasswordButton" Text="save" OnClick="ChangePasswordButton_Click"
						ImageUrl="~/Style/Images/key1_add.png" />
				</div>
			</div>
		</div>
		<div class="last_column">
		</div>
	</div>
</asp:Content>
