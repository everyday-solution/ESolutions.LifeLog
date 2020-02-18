<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Mobile.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
	your fitness level
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<div id="root">
		<!-- before & after -->
		<div id="before_after" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="HomeLink" ImageUrl="~/Layout/home.png" Text="home" ToolTip="home" />
			</div>
			<div class="multi_column content">
				<h2>before & after
				</h2>
				<div>
					<div class="multi_column before_after">
						<div>
							<asp:Image runat="server" ID="BeforeImage" ImageUrl="~/Layout/human.png" CssClass="before_after_image" />
						</div>
						<div>
							<asp:Label runat="server" ID="BeforeDate" CssClass="before_after_date" />
						</div>
					</div>
					<div class="multi_column before_after">
						<div>
							<asp:Image runat="server" ID="AfterImage" ImageUrl="~/Layout/human.png" CssClass="before_after_image" />
						</div>
						<div>
							<asp:Label runat="server" ID="AfterDate" CssClass="before_after_date" />
						</div>
					</div>
					<div class="last_column"></div>
				</div>
			</div>
			<div class="last_column"></div>
		</div>
		<!-- soul -->
		<div id="soul" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="SoulLink" ImageUrl="~/Layout/soul.png" Text="soul" ToolTip="soul" />
			</div>
			<div class="multi_column content">
				<h2>what's on your mind
				</h2>
				<div class="multi_column latest_thought">
					<asp:Label runat="server" ID="SoulLabel" />
				</div>
			</div>
			<div class="last_column"></div>
		</div>
		<!-- body -->
		<div id="body" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="BodyLink" ImageUrl="~/Layout/body.png" Text="body" ToolTip="body" />
			</div>
			<div class="multi_column content">
				<h2>keep in shape
				</h2>
				<div>
					<asp:Chart runat="server" ID="BodyChart" Width="280px" Height="230px" BackColor="black" CssClass="chart">
						<Series>
							<asp:Series Name="Weight" ChartType="Line" BorderWidth="5" LegendText="weight (kg)" />
							<asp:Series Name="Fat" ChartType="Line" BorderWidth="5" LegendText="fat (%)" />
						</Series>
						<Legends>
							<asp:Legend ForeColor="White" BackColor="Black" Docking="Bottom" Alignment="Center">
								<Position X="40" Y="40" Width="35" Height="10" />
							</asp:Legend>
						</Legends>
						<ChartAreas>
							<asp:ChartArea Name="ChartArea1" BorderColor="white" BorderDashStyle="Solid" BackColor="black">
								<AxisY LineColor="white">
									<MajorGrid LineColor="white" />
									<LabelStyle ForeColor="White" />
								</AxisY>
								<AxisX LineColor="white">
									<MajorGrid LineColor="white" />
									<LabelStyle ForeColor="White" />
								</AxisX>
							</asp:ChartArea>
						</ChartAreas>
					</asp:Chart>
				</div>
			</div>
			<div class="last_column">
			</div>
		</div>
		<!-- heart -->
		<div id="heart" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="HeartLink" ImageUrl="~/Layout/heart.png" Text="heart" ToolTip="heart" />
			</div>
			<div class="multi_column content">
				<h2>mind your pump
				</h2>
				<div>
					<asp:Chart ID="HeartChart" runat="server" Width="280px" Height="200px" ImageType="Png"
						BackColor="Black" CssClass="chart">
						<Series>
							<asp:Series Name="PressureSeries" ChartType="Candlestick" BorderWidth="5" LegendText="pressure (mmHG)" />
							<asp:Series Name="HeartRateSeries" ChartType="Line" BorderWidth="5" LegendText="rate (bpm)" />
							<asp:Series Name="MaxPressureSeries" ChartType="Line" BorderWidth="1" IsVisibleInLegend="false" Color="Red" BorderDashStyle="Dot" />
							<asp:Series Name="MinPressureSeries" ChartType="Line" BorderWidth="1" IsVisibleInLegend="false" Color="red" BorderDashStyle="Dot" />
						</Series>
						<Legends>
							<asp:Legend ForeColor="White" BackColor="Black" Docking="Bottom" Alignment="Center">
								<Position X="53" Y="9" Width="41" Height="12" />
							</asp:Legend>
						</Legends>
						<ChartAreas>
							<asp:ChartArea Name="ChartArea1" BorderColor="white" BorderDashStyle="Solid" BackColor="black">
								<AxisY LineColor="white">
									<LabelStyle ForeColor="White" />
									<MajorGrid LineColor="white" />
								</AxisY>
								<AxisX LineColor="white">
									<LabelStyle ForeColor="White" />
									<MajorGrid LineColor="white" />
								</AxisX>
							</asp:ChartArea>
						</ChartAreas>
					</asp:Chart>
				</div>
			</div>
			<div class="last_column">
			</div>
		</div>
		<!-- action -->
		<div id="action" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="ActionLink" ImageUrl="~/Layout/action.png" Text="action" ToolTip="action" />
			</div>
			<div class="multi_column content">
				<h2>keep on moving
				</h2>
				<div>
					<asp:Chart ID="ActionChart" runat="server" Width="280px" Height="200px" ImageType="Png"
						BackColor="Black" CssClass="chart">
						<Series>
							<asp:Series Name="ConsumptionSeries" ChartType="Line" BorderWidth="5" LegendText="consumption (kcal)" />
						</Series>
						<Legends>
							<asp:Legend ForeColor="White" BackColor="Black" Docking="Bottom" Alignment="Center">
								<Position X="45" Y="66" Width="45" Height="12" />
							</asp:Legend>
						</Legends>
						<ChartAreas>
							<asp:ChartArea Name="ChartArea1" BorderColor="white" BorderDashStyle="Solid" BackColor="black">
								<AxisY LineColor="white">
									<LabelStyle ForeColor="White" />
									<MajorGrid LineColor="white" />
								</AxisY>
								<AxisX LineColor="white">
									<LabelStyle ForeColor="White" />
									<MajorGrid LineColor="white" />
								</AxisX>
							</asp:ChartArea>
						</ChartAreas>
					</asp:Chart>
				</div>
			</div>
			<div class="last_column">
			</div>
		</div>
		<!-- feast -->
		<div id="feast" class="topic">
			<div class="multi_column icon">
				<asp:HyperLink runat="server" ID="FeastLink" ImageUrl="~/Layout/feast.png" Text="feast" ToolTip="feast" />
			</div>
			<div class="multi_column content">
				<h2>do i want to consist of that
				</h2>
				<div id="image_panel">
					<asp:Repeater runat="server" ID="FeastRepeater" OnItemDataBound="FeastRepeater_ItemDataBound">
						<ItemTemplate>
							<div class="multi_column">
								<asp:Image runat="server" ID="IngestionImage" />
							</div>
						</ItemTemplate>
					</asp:Repeater>
					<div class="last_column"></div>
				</div>
			</div>
			<div class="last_column">
			</div>
		</div>
	</div>
</asp:Content>
