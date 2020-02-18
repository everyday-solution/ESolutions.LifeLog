<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Create.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Me.Create" %>

<%@ Register TagPrefix="es" TagName="ImageLinkButton" Src="~/ImageLinkButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - become a part of it!
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ScriptPlaceHolder">
	<script type="text/javascript">
		$(document).ready(function () {
			$.datepicker.setDefaults($.datepicker.regional['']);
			$('#NewUserDateOfBirthTextBox').datepicker($.datepicker.regional['de']);
			$('#NewUserDateOfBirthTextBox').datepicker("option", "changeMonth", true);
			$('#NewUserDateOfBirthTextBox').datepicker("option", "changeYear", true);

			$('#HeightTextBox').numericUpDown($('#HeightUpImage'), $('#HeightDownImage'), 1);
		});
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Panel ID="Panel1" runat="server" CssClass="CreateEntryPanel">
		<h1>
			<asp:Label runat="server" ID="CreateUserLabel" Text="become a part of it!" />
		</h1>
		<!-- New user -->
		<div>
			<asp:Label runat="server" ID="CreateErrorLabel" CssClass="error" Visible="false" />
		</div>
		<div class="multi_column">
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="NewUserEmailLabel" Text="email" />
				</div>
				<div>
					<asp:TextBox runat="server" ID="NewUserEmailTextBox" />
				</div>
				<div>
					<asp:RequiredFieldValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter your email address"
						ControlToValidate="NewUserEmailTextBox" Display="Dynamic" CssClass="missing_form_field" />
					<asp:RegularExpressionValidator runat="server" ErrorMessage="Please enter a valid email address like 'mailbox@domain.com'"
						ControlToValidate="NewUserEmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
						Display="Dynamic" CssClass="missing_form_field" />
				</div>
			</div>
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="NewUserPasswordLabel" Text="password" />
				</div>
				<div>
					<asp:TextBox runat="server" ID="NewUserPasswordTextBox" TextMode="Password" />
				</div>
				<div>
					<asp:RequiredFieldValidator runat="server" ControlToValidate="NewUserPasswordTextBox"
						ErrorMessage="Please enter a password" Display="Dynamic" CssClass="missing_form_field" />
				</div>
			</div>
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="NewUserPasswordConfirmLabel" Text="password (confirm)" />
				</div>
				<div>
					<asp:TextBox runat="server" ID="NewUserPasswordConfirmTextBox" TextMode="Password" />
				</div>
				<div>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewUserPasswordConfirmTextBox"
						ErrorMessage="Please confirm your password" Display="Dynamic" CssClass="missing_form_field" />
				</div>
			</div>
		</div>
		<div class="multi_column">
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="NewUserDateOfBirthLabel" Text="date of birth" />
				</div>
				<asp:TextBox runat="server" ID="NewUserDateOfBirthTextBox" ClientIDMode="Static" />
			</div>
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="HeightLabel" Text="height (cm)" />
				</div>
				<asp:TextBox runat="server" ID="HeightTextBox" Text="170" ClientIDMode="Static" />
				<asp:Image runat="server" ID="HeightUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
					ClientIDMode="Static" />
				<asp:Image runat="server" ID="HeightDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
					ClientIDMode="Static" />
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
		<div class="last_column">
		</div>
		<!-- Action -->
		<div>
			<es:ImageLinkButton runat="server" ID="CreateUserButton2" Text="create" OnClick="CreateUserButton_Click"
				ImageUrl="~/Style/Images/key1_add.png" />
		</div>
	</asp:Panel>
</asp:Content>
