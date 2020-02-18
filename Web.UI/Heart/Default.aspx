<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Heart.Default" %>

<%@ Register Src="~/ImageLinkButton.ascx" TagPrefix="es" TagName="ImageLinkButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	mylivelog - mind your pump!
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

			$('#HeartRateTextBox').numericUpDown($('#HeartRateUpImage'), $('#HeartRateDownImage'), 1);
			$('#SystolicTextBox').numericUpDown($('#SystolicUpImage'), $('#SystolicDownImage'), 1);
			$('#DiastolicTextBox').numericUpDown($('#DiastolicUpImage'), $('#DiastolicDownImage'), 1);

			$('.data_list .item .title').mouseover(function () {
				var test = $(this).parent().parent().find('.mybutton');
				if ($(test).css('display') == 'none') {
					$(test).fadeIn().delay(2000).fadeOut();
				}
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="heart">
		<div class="data_panel">
			<h1>
				<asp:Label runat="server" ID="SuccessTitleLabel" Text="mind your pump!" />
			</h1>
			<div class="multi_column edit">
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="DateLabel" Text="date" />
						</div>
						<asp:TextBox runat="server" ID="DateTextBox" ClientIDMode="Static" />
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="TimeLabel" Text="time" />
						</div>
						<asp:DropDownList runat="server" ID="HourList" />
						<asp:DropDownList runat="server" ID="MinuteList" />
					</div>
				</div>
				<div class="multi_column">
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="HeartBeatLabel" Text="heart rate (BPM)" />
						</div>
						<asp:TextBox runat="server" ID="HeartRateTextBox" ClientIDMode="Static" />
						<asp:Image runat="server" ID="HeartRateUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button" />
						<asp:Image runat="server" ID="HeartRateDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button"/>
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="SystolicLabel" Text="systolic (mmHG)" />
						</div>
						<asp:TextBox runat="server" ID="SystolicTextBox" ClientIDMode="Static" />
						<asp:Image runat="server" ID="SystolicUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" CssClass="image_button"/>
						<asp:Image runat="server" ID="SystolicDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" CssClass="image_button"/>
					</div>
					<div class="form_field">
						<div class="caption">
							<asp:Label runat="server" ID="DiastolicLabel" Text="diastolic (mmHG)" />
						</div>
						<asp:TextBox runat="server" ID="DiastolicTextBox" ClientIDMode="Static" />
						<asp:Image runat="server" ID="DiastolicUpImage" ImageUrl="~/Style/Images/arrow_up_blue.png"
							ClientIDMode="Static" />
						<asp:Image runat="server" ID="DiastolicDownImage" ImageUrl="~/Style/Images/arrow_down_blue.png"
							ClientIDMode="Static" />
					</div>
				</div>
				<div class="last_column">
				</div>
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
				<asp:TextBox runat="server" ID="FilterFrom" AutoPostBack="true" OnTextChanged="Filter_TextChanged"
					ClientIDMode="Static" />
				<span>until</span>
				<asp:TextBox runat="server" ID="FilterUntil" AutoPostBack="true" OnTextChanged="Filter_TextChanged"
					ClientIDMode="Static" />
			</div>
			<div>
				<div class="data_list multi_column">
					<div class="item">
						<h2>Average
						</h2>
						<div class="sub_item">
							<div class="form_field multi_column">
								<div class="caption">
									Ø heart rate (bpm)
								</div>
								<div>
									<asp:Label runat="server" ID="AverageHeartRateLabel" />
								</div>
							</div>
							<div class="form_field multi_column">
								<div class="caption">
									Ø systolic (mmHG)
								</div>
								<div>
									<asp:Label runat="server" ID="AverageSystolicLabel" />
								</div>
							</div>
							<div class="form_field multi_column">
								<div class="caption">
									Ø diastolic (mmHG)
								</div>
								<div>
									<asp:Label runat="server" ID="AverageDiastolicLabel" />
								</div>
							</div>
							<div class="last_column">
							</div>
						</div>
					</div>
					<asp:Repeater runat="server" ID="BloodPressureRepeater" OnItemDataBound="BloodPressureRepeater_ItemDataBound">
						<ItemTemplate>
							<div class="item">
								<h2>
									<asp:Label runat="server" ID="DateLabel" CssClass="title" />
									<asp:ImageButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" ImageUrl="~/Style/Images/delete.png"
										CssClass="mybutton" Style="display: none" />
								</h2>
								<div>
									<div class="form_field multi_column">
										<div class="caption">
											diastolic (mmHG)
										</div>
										<div>
											<asp:Label runat="server" ID="HeartRateLabel" />
										</div>
									</div>
									<div class="form_field multi_column">
										<div class="caption">
											diastolic (mmHG)
										</div>
										<div>
											<asp:Label runat="server" ID="SystolicLabel" />
										</div>
									</div>
									<div class="form_field multi_column">
										<div class="caption">
											diastolic (mmHG)
										</div>
										<div>
											<asp:Label runat="server" ID="DiastolicLabel" />
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
					<asp:Chart ID="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
						Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
						BackGradientStyle="TopBottom" BorderWidth="5" BackColor="#99C544" BorderColor="#FFFFFF">
						<Legends>
						</Legends>
						<Series>
							<asp:Series Name="PressureSeries" ChartType="Candlestick" BorderWidth="10">
								<Points>
								</Points>
							</asp:Series>
							<asp:Series Name="HeartRateSeries" ChartType="Line" BorderWidth="5" Color="#D8FF49">
								<Points>
								</Points>
							</asp:Series>
						</Series>
						<ChartAreas>
							<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
								BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
								BackGradientStyle="TopBottom">
								<Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
									WallWidth="0" IsClustered="False" />
								<AxisY LineColor="64, 64, 64, 64">
									<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
									<MajorGrid LineColor="64, 64, 64, 64" />
								</AxisY>
								<AxisX LineColor="64, 64, 64, 64">
									<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
									<MajorGrid LineColor="64, 64, 64, 64" />
								</AxisX>
							</asp:ChartArea>
						</ChartAreas>
					</asp:Chart>
				</div>
				<div class="last_column">
				</div>
			</div>
		</div>
	</div>
</asp:Content>
