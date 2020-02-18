<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Feast.Default" %>

<%@ Register Src="~/ImageLinkButton.ascx" TagPrefix="es" TagName="ImageLinkButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - do i want to consist of that?
</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$.datepicker.setDefaults($.datepicker.regional['']);
			$('#DateTextBox').datepicker($.datepicker.regional['de']);
			$('#DateTextBox').datepicker("option", "changeMonth", true);
			$('#DateTextBox').datepicker("option", "changeYear", true);

			$('#FilterFrom').datepicker($.datepicker.regional['de']);
			$('#FilterFrom').datepicker("option", "changeMonth", true);
			$('#FilterFrom').datepicker("option", "changeYear", true);

			$('#FilterUntil').datepicker($.datepicker.regional['de']);
			$('#FilterUntil').datepicker("option", "changeMonth", true);
			$('#FilterUntil').datepicker("option", "changeYear", true);

			$('img.ingestion').mouseover(function () {
				var test = $(this).parent().parent().find('.mybutton');
				if ($(test).css('display') == 'none') {
					$(test).fadeIn().delay(2000).fadeOut();
				}
			});

			$('img.ingestion').click(function () {
				$(this).animate({ height: "250px" }, 400).delay(1000).animate({ height: "100px" }, 400);
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="data_panel ">
		<h1>
			<asp:Label runat="server" ID="ManufacturerTitleLabel" Text="do i want to consist of that?" />
		</h1>
		<div class="multi_column edit">
			<!-- date -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="Label1" Text="date" />
				</div>
				<asp:TextBox runat="server" ID="DateTextBox" ClientIDMode="Static" />
			</div>
			<!-- time -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="NameLabel" Text="time" />
				</div>
				<asp:DropDownList runat="server" ID="HourList" />
				<asp:DropDownList runat="server" ID="MinuteList" />
			</div>
			<!-- picture -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="Label2" Text="picture" />
				</div>
				<asp:FileUpload runat="server" ID="PictureUpload" />
			</div>
			<!-- Save -->
			<div>
				<es:ImageLinkButton runat="server" ID="SaveButton2" Text="save" OnClick="SaveButton_Click"
					ImageUrl="~/Style/Images/add.png" />
			</div>
		</div>
		<div class="last_column">
		</div>
	</div>
	<div class="data_panel">
		<!-- Title -->
		<h1>
			<asp:Label runat="server" ID="AllLabel" Text="all ingestions" />
		</h1>
		<div>
			<span>from</span>
			<asp:TextBox runat="server" ID="FilterFrom" AutoPostBack="true" ClientIDMode="Static" />
			<span>until</span	>
			<asp:TextBox runat="server" ID="FilterUntil" AutoPostBack="true" ClientIDMode="Static" />
		</div>
		<div class="data_list">
			<asp:Repeater runat="server" ID="FeastRepeater" OnItemDataBound="IngestionRepeater_ItemDataBound">
				<ItemTemplate>
					<div class="item">
						<h2>
							<asp:Label runat="server" ID="DateLabel" />
						</h2>
						<div>
							<asp:Repeater runat="server" ID="PictureRepeater" OnItemDataBound="PictureRepeater_ItemDataBound">
								<ItemTemplate>
									<div class="multi_column sub_item">
										<div>
											<asp:Image runat="server" ID="MyImage" Height="100px" CssClass="ingestion" />
										</div>
										<div>
											<asp:Label runat="server" ID="TimeLabel" />
											<asp:ImageButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" ImageUrl="~/Style/Images/delete.png"
												CssClass="mybutton" Style="display: none;" />
										</div>
									</div>
								</ItemTemplate>
							</asp:Repeater>
							<div class="last_column">
							</div>
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
