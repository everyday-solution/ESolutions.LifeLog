<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Body.Default" %>

<%@ Register Src="~/ImageLinkButton.ascx" TagPrefix="es" TagName="ImageLinkButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - keep in shape!
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
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

			$('#WeightTextBox').numericUpDown($('#WeightUpImage'), $('#WeightDownImage'), 0.1);
			$('#FatTextBox').numericUpDown($('#FatUpImage'), $('#FatDownImage'), 0.1);
			$('#WaterTextBox').numericUpDown($('#WaterUpImage'), $('#WaterDownImage'), 0.1);

			$('#ChestTextBox').numericUpDown($('#ChestUpImage'), $('#ChestDownImage'), 1);
			$('#AbdominalTextBox').numericUpDown($('#AbdominalUpImage'), $('#AbdominalDownImage'), 1);
			$('#HipTextBox').numericUpDown($('#HipUpImage'), $('#HipDownImage'), 1);

			$('#LeftUpperArmTextBox').numericUpDown($('#LeftUpperArmUpImage'), $('#LeftUpperArmDownImage'), 1);
			$('#RightUpperArmTextBox').numericUpDown($('#RightUpperArmUpImage'), $('#RightUpperArmDownImage'), 1);
			$('#LeftUpperLegTextBox').numericUpDown($('#LeftUpperLegUpImage'), $('#LeftUpperLegDownImage'), 1);
			$('#RightUpperLegTextBox').numericUpDown($('#RightUpperLegUpImage'), $('#RightUpperLegDownImage'), 1);

			$('.data_list .item .title').mouseover(function () {
				var test = $(this).parent().find('.mybutton');
				if ($(test).css('display') == 'none') {
					$(test).fadeIn().delay(2000).fadeOut();
				}
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="body">
		<div class="data_panel">
			<!-- Title -->
			<h1>
				<asp:Label runat="server" ID="SuccessTitleLabel" Text="keep in shape!" />
			</h1>
			<div class="multi_column edit">
				<!-- New Entry -->
				<!-- First column -->
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="DateLabel" Text="date" />
						</div>
						<asp:TextBox runat="server" ID="DateTextBox" ClientIDMode="Static" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="ActivityFactorLabel" Text="physical activity level (pal)" />
						</div>
						<asp:DropDownList runat="server" ID="ActivityFactorList" DataTextField="Name" DataValueField="Factor" />
					</div>
				</div>
				<!-- Second column -->
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="WeightLabel" Text="weight (kg)" />
						</div>
						<asp:TextBox runat="server" ID="WeightTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="WeightUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="WeightDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="FatLabel" Text="fat (%)" />
						</div>
						<asp:TextBox runat="server" ID="FatTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="FatUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="FatDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="WaterLabel" Text="water (%)" />
						</div>
						<asp:TextBox runat="server" ID="WaterTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="WaterUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="WaterDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
				</div>
				<!-- Third column -->
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="ChestLabel" Text="chest (cm)" />
						</div>
						<asp:TextBox runat="server" ID="ChestTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="ChestUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="ChestDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="AbdominalLabel" Text="belly (cm)" />
						</div>
						<asp:TextBox runat="server" ID="AbdominalTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="AbdominalUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="AbdominalDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="HipLabel" Text="hip (cm)" />
						</div>
						<asp:TextBox runat="server" ID="HipTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="HipUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="HipDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
				</div>
				<!-- fourth column -->
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label1" Text="left upper arm (cm)" />
						</div>
						<asp:TextBox runat="server" ID="LeftUpperArmTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="LeftUpperArmUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="LeftUpperArmDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label2" Text="right upper arm (cm)" />
						</div>
						<asp:TextBox runat="server" ID="RightUpperArmTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="RightUpperArmUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="RightUpperArmDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label3" Text="left upper leg (cm)" />
						</div>
						<asp:TextBox runat="server" ID="LeftUpperLegTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="LeftUpperLegUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="LeftUpperLegDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label4" Text="right upper leg (cm)" />
						</div>
						<asp:TextBox runat="server" ID="RightUpperLegTextBox" ClientIDMode="Static" Width="30px" />
						<asp:Image runat="server" ID="RightUpperLegUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="RightUpperLegDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
					</div>
				</div>
				<!-- fifth column -->
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label5" Text="front view" />
						</div>
						<div>
							<asp:FileUpload runat="server" ID="BodyImageUploadFront" />
						</div>
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="Label6" Text="side view" />
						</div>
						<div>
							<asp:FileUpload runat="server" ID="BofyImageUploadSide" />
						</div>
					</div>
				</div>
				<div class="last_column">
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
		<asp:Panel runat="server" ID="CurrentPanel" class="data_panel">
			<!-- Title -->
			<h1>
				<asp:Label runat="server" ID="HistoryLabel" Text="history" />
			</h1>
			<div>
				<span>from</span>
				<asp:TextBox runat="server" ID="FilterFromTextBox" AutoPostBack="true" ClientIDMode="Static" />
				<span>until</span>
				<asp:TextBox runat="server" ID="FilterUntilTextBox" AutoPostBack="true" ClientIDMode="Static" />
			</div>
			<div class="data_list">
				<asp:Repeater runat="server" ID="MeasureRepeater" OnItemDataBound="MeasureRepeater_ItemDataBound">
					<ItemTemplate>
						<div class="item">
							<h2 class="caption">
								<asp:Label runat="server" ID="CurrentDateLabel" CssClass="title" />
								<asp:ImageButton runat="server" ID="DeleteButton" ImageUrl="~/Style/Images/delete.png"
									OnClick="DeleteButton_Click" CssClass="mybutton" Style="display: none;" />
							</h2>
							<div class="multi_column sub_item">
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label13" Text="weight" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentWeightLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label16" Text="fat" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentFatLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label18" Text="water" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentWaterLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label15" Text="circumfence" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentTotalMeasureLabel" />
									</div>
								</div>
							</div>
							<div class="multi_column">
								<asp:Image runat="server" ID="FrontImage" Width="200px" ImageUrl="~/Pictures/human.jpg" />
							</div>
							<div class="multi_column">
								<asp:Image runat="server" ID="SideImage" Width="200px" ImageUrl="~/Pictures/human.jpg" />
							</div>
							<div class="multi_column sub_item">
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label9" Text="chest" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentChestLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label10" Text="belly" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentBellyLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label11" Text="hip" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentHipLabel" />
									</div>
								</div>
							</div>
							<div class="multi_column sub_item">
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label8" Text="left upper arm" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentLeftArmLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label14" Text="left upper leg" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentLeftLegLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label7" Text="right upper arm" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentRightArmLabel" />
									</div>
								</div>
								<div class="form_field">
									<div class="caption">
										<asp:Label runat="server" ID="Label12" Text="right upper leg" />
									</div>
									<div>
										<asp:Label runat="server" ID="CurrentRightLegLabel" />
									</div>
								</div>
							</div>
							<div class="last_column">
							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>
		</asp:Panel>
	</div>
</asp:Content>

