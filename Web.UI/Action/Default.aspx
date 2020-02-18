<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Action.Default" %>

<%@ Register Src="~/ImageLinkButton.ascx" TagPrefix="es" TagName="ImageLinkButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - keep on moving!
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
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

			$('#DurationTextBox').numericUpDown($('#DurationUpImage'), $('#DurationDownImage'), 1);

			$('.data_list .item .title').mouseover(function () {
				var test = $(this).find('.mybutton');
				if ($(test).css('display') == 'none') {
					$(test).fadeIn().delay(2000).fadeOut();
				}
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="data_panel">
		<h1>
			<asp:Label runat="server" ID="SuccessTitleLabel" Text="keep on moving!" />
		</h1>
		<div class="multi_column edit">
			<!-- date -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="DateLabel" Text="date" />
				</div>
				<asp:TextBox runat="server" ID="DateTextBox" ClientIDMode="Static" />
			</div>
			<!-- action -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="ActionLabel" Text="action" />
				</div>
				<asp:DropDownList runat="server" ID="ActionList" DataValueField="Guid" DataTextField="Name" />
			</div>
			<!-- duration -->
			<div class="form_field">
				<div class="caption">
					<asp:Label runat="server" ID="DurationLabel" Text="duration (min)" />
				</div>
				<asp:TextBox runat="server" ID="DurationTextBox" ClientIDMode="Static" />
				<asp:Image runat="server" ID="DurationUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
					ClientIDMode="Static" />
				<asp:Image runat="server" ID="DurationDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
					ClientIDMode="Static" />
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
			<asp:Label runat="server" ID="HistoryLabel" Text="history" />
		</h1>
		<div>
			<span>from</span>
			<asp:TextBox runat="server" ID="FilterFrom" AutoPostBack="true" ClientIDMode="Static" />
			<span>until</span>
			<asp:TextBox runat="server" ID="FilterUntil" AutoPostBack="true" ClientIDMode="Static" />
		</div>
		<div>
			<div class="data_list multi_column">
				<!-- statistic -->
				<div class="item">
					<h2>sum
					</h2>
					<div class="sub_item">
						<div class="form_field multi_column">
							<div class="caption">
								duration (min)
							</div>
							<div>
								<asp:Label runat="server" ID="TotalDurationLabel" />
							</div>
						</div>
						<div class="form_field multi_column">
							<div class="caption">
								total (kcal)
							</div>
							<div>
								<asp:Label runat="server" ID="TotalConsumptionLabel" />
							</div>
						</div>
						<div class="last_column">
						</div>
					</div>
				</div>
				<!-- items -->
				<asp:Repeater runat="server" ID="ActionRepeater" OnItemDataBound="ActionRepeater_ItemDataBound">
					<ItemTemplate>
						<div class="item">
							<h2 class="title">
								<asp:Label runat="server" ID="DateLabel" />
								<asp:ImageButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" ImageUrl="~/Style/Images/delete.png" CssClass="mybutton" Style="display: none" ToolTip="delete" />
							</h2>
							<div>
								<div class="multi_column">
									<div class="form_field">
										<div class="caption">
											action
										</div>
										<div>
											<asp:Label runat="server" ID="ActionLabel" />
										</div>
									</div>
								</div>
								<div class="multi_column">
									<div class="form_field">
										<div class="caption">
											duration (min)
										</div>
										<div>
											<asp:Label runat="server" ID="DurationLabel" />
										</div>
									</div>
								</div>
								<div class="multi_column">
									<div class="form_field">
										<div class="caption">
											consumption (kcal)
										</div>
										<div>
											<asp:Label runat="server" ID="ConsumptionLabel" />
										</div>
									</div>
								</div>
								<div class="last_column">
								</div>
							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>
			<div class="multi_column">
			</div>
			<div class="last_column">
			</div>
		</div>
	</div>
</asp:Content>
