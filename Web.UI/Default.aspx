<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="ESolutions.LifeLog.Web.UI.Default" %>

<%@ Register TagPrefix="es" TagName="ImageLinkButton" Src="~/ImageLinkButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
	welcome to mylivelog!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="data_panel">
		<h1>
			<asp:Label runat="server" ID="DefaultTiele" Text="welcome to mylivelog!" />
		</h1>
		<!-- Panel that is shown if user is not logged in -->
		<asp:Panel runat="server" ID="NotLoggedInPanel">
			<div class="intro">
				<div class="para">
					This portal is your personal happiness diary. You can track your success, your happy
					moments, your weight, your sportive activites and your heart. It is meant for everyone
					who wants to get aware of his body and soul. And the best: It's free!
				</div>
			</div>
			<div>
				<div class="multi_column">
					<es:ImageLinkButton runat="server" ID="LoginLink2" Text="login" ImageUrl="~/Style/Images/key1.png"
						OnClick="LoginLink_Click" />
				</div>
				<div class="multi_column">
					<es:ImageLinkButton runat="server" ID="ImageLinkButton1" Text="sign up" ImageUrl="~/Style/Images/key1_add.png"
						OnClick="CreateLink_Click" />
				</div>
				<div class="last_column">
				</div>
			</div>
		</asp:Panel>
		<!-- Panel that is shown if user is logged in -->
		<asp:Panel runat="server" ID="LoggedInPanel" CssClass="StatisticPanel">
			<div class="data_list">
				<div class="item">
					<h2>before - after
					</h2>
					<div>
						<div class="multi_column">
							<div>
								<asp:Image runat="server" ID="BeforeImage" Height="300px" ImageUrl="~/Pictures/human.jpg" />
							</div>
							<div>
								<asp:Label runat="server" ID="BeforeDateLabel" />
							</div>
						</div>
						<div class="multi_column">
							<div>
								<asp:Image runat="server" ID="AfterImage" Height="300px" ImageUrl="~/Pictures/human.jpg" />
							</div>
							<div>
								<asp:Label runat="server" ID="AfterDateLabel" />
							</div>
						</div>
						<div class="last_column">
						</div>
					</div>
				</div>
				<div class="item">
					<h2>weight & fat
					</h2>
					<div>
						<asp:Chart ID="Chart1" runat="server" Height="300px" Width="500px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,4)"
							Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
							BackGradientStyle="TopBottom" BorderWidth="5" BackColor="#99C544" BorderColor="#FFFFFF">
							<Legends>
							</Legends>
							<Series>
								<asp:Series Name="Weight" ChartType="Line" BorderWidth="5">
									<Points>
									</Points>
								</asp:Series>
								<asp:Series Name="Fat" ChartType="Line" BorderWidth="5">
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
				</div>
			</div>
		</asp:Panel>
	</div>
</asp:Content>
