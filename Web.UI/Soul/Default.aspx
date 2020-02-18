<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Soul.Default" %>

<%@ Register TagPrefix="es" TagName="ImageLinkButton" Src="~/ImageLinkButton.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="ScriptPlaceHolder">
	<script type="text/javascript">
		$(document).ready(function () {
			$.datepicker.setDefaults($.datepicker.regional['']);
			$('#DateTextBox').datepicker($.datepicker.regional['de']);
			$('#DateTextBox').datepicker("option", "changeMonth", true);
			$('#DateTextBox').datepicker("option", "changeYear", true);

			$('#FilterFromTextBox').datepicker($.datepicker.regional['de']);
			$('#FilterFromTextBox').datepicker("option", "changeMonth", true);
			$('#FilterFromTextBox').datepicker("option", "changeYear", true);

			$('#FilterUntilTextBox').datepicker($.datepicker.regional['de']);
			$('#FilterUntilTextBox').datepicker("option", "changeMonth", true);
			$('#FilterUntilTextBox').datepicker("option", "changeYear", true);

			$('.data_list .item .caption').mouseover(function () {
				var test = $(this).parent().find('.mybutton');
				if ($(test).css('display') == 'none') {
					$(test).fadeIn().delay(2000).fadeOut();
				}
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - what's on your mind
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="data_panel">
		<h1>
			<asp:Label runat="server" ID="SuccessTitleLabel" Text="keep happy + successfull!" />
		</h1>
		<div class="multi_column edit">
			<div class="multi_column">
				<div>
					<div>
						<asp:HiddenField runat="server" ID="EditGuidHidden" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="DateLabel" Text="date" />
						</div>
						<div>
							<asp:TextBox runat="server" ID="DateTextBox" ClientIDMode="Static" />
						</div>
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="TypeLabel" Text="what" />
						</div>
						<div>
							<asp:RadioButtonList runat="server" ID="TypeRadioButton" RepeatDirection="Vertical">
								<asp:ListItem Text="moment of bliss" Value="Happiness" Selected="True" />
								<asp:ListItem Text="success" Value="Success" Selected="False" />
							</asp:RadioButtonList>
						</div>
					</div>
				</div>
			</div>
			<div class="multi_column">
				<div class="form_field">
					<div class="caption ">
						<asp:Label runat="server" ID="NoteLabel" Text="note" />
					</div>
					<div>
						<asp:TextBox runat="server" ID="NoteTextBox" TextMode="MultiLine" CssClass="success_note" />
					</div>
				</div>
			</div>
			<div class="last_column">
			</div>
			<div>
				<es:ImageLinkButton ID="SaveButton" runat="Server" Text="save" OnClick="SaveButton_Click"
					ImageUrl="~/Style/Images/add.png" />
			</div>
		</div>
		<div class="last_column">
		</div>
	</div>
	<div class="data_panel">
		<!-- Filter -->
		<h1>
			<asp:Label runat="server" ID="HistoryLabel" Text="history" />
		</h1>
		<div>
			<span>from</span>
			<asp:TextBox runat="server" ID="FilterFromTextBox" AutoPostBack="true" ClientIDMode="Static" />
			<span>until</span>
			<asp:TextBox runat="server" ID="FilterUntilTextBox" AutoPostBack="true" ClientIDMode="Static" />
		</div>
		<!-- Data List -->
		<div class="data_list">
			<asp:Repeater runat="server" ID="SuccessRepeater" OnItemDataBound="SuccessRepeater_ItemDataBound">
				<ItemTemplate>
					<div class="item">
						<h2 class="caption">
							<asp:Label runat="server" ID="DateLabel" />&nbsp;(<asp:Label runat="server" ID="TypeLabel" />)
								<asp:ImageButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" ImageUrl="~/Style/Images/delete.png"
									OnClientClick="return confirm('Really?');" CssClass="mybutton" Style="display: none;" ToolTip="delete" />
							<asp:ImageButton runat="server" ID="EditButton" OnClick="EditButton_Click" ImageUrl="~/Style/Images/edit.png"
								CssClass="mybutton" Style="display: none;" ToolTip="edit" />
						</h2>
						<div>
							<asp:Label runat="server" ID="NoteLabel" />
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
