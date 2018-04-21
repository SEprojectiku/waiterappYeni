<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerReservation.aspx.cs" Inherits="waiterApp.CustomerReservation" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Order Page</title>
<link href="css/styleres.css" rel="stylesheet" type="text/css" media="all"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 

<!--web-fonts-->
<link href='//fonts.googleapis.com/css?family=Ubuntu:400,300,300italic,400italic,500,500italic,700,700italic' rel='stylesheet' type='text/css'>
<script src="js/jquery-1.12.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!---header--->
		<div class="header w3ls">
			<h1>Restaurant Booking</h1>
		</div>
		<!---header--->
		<!---main--->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                
			<div class="main">
				<div class="main-section agile">
					<div class="login-form">
						<ul>
                            <li class="text-info">Order Date/Time *</li>
                            <li class="dat">
                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" class="date" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" onblur="if (this.value == '') {this.value = 'dd-mm-yyyy';}" onfocus="this.value = '';" OnSelectionChanged="Calendar1_SelectionChanged" type="text" value="dd-mm-yyyy" Width="200px">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" Wrap="False" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </li>
                            <li class="selec">
                                <asp:DropDownList ID="timeList" runat="server" AutoPostBack="True" class="currentTime time-dropdown form-dropdown validate[required, limitDate]" OnSelectedIndexChanged="timeList_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Time</asp:ListItem>
                                    <asp:ListItem Value="1">01</asp:ListItem>
                                    <asp:ListItem Value="2">02</asp:ListItem>
                                    <asp:ListItem Value="4">03</asp:ListItem>
                                    <asp:ListItem Value="5">04</asp:ListItem>
                                    <asp:ListItem Value="5">05</asp:ListItem>
                                    <asp:ListItem Value="6">06</asp:ListItem>
                                    <asp:ListItem Value="7">07</asp:ListItem>
                                    <asp:ListItem Value="8">08</asp:ListItem>
                                    <asp:ListItem Value="9">09</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <div class="clear">
                            </div>
                        </ul>
                        <ul>
                            <!---start-date-piker---->
                            <link rel="stylesheet" href="css/jquery-ui.css" />
                            <script src="js/jquery-ui.js">
</script>
                            <script>

												$(function() {
												$( "#datepicker,#datepicker1" ).datepicker();
												});
											</script>
                            <!---/End-date-piker---->
                            <ul>
                                <li class="text-info">Number of Person *</li>
                                <li class="se">
                                    <select id="min_15" class="time-dropdown form-dropdown validate[required, limitDate]" name="q15_departureDatetime15[min]">
                                        <option>0</option>
                                        <option value="1">1</option>
                                        <option value="2">2</option>
                                        <option value="3">3</option>
                                        <option value="4">4</option>
                                        <option value="5">5</option>
                                        <option value="6">6</option>
                                        <option value="7">7</option>
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                    </select></li>
                                <div class="clear">
                                </div>
                            </ul>
                            <ul>
                                <li class="text-info">Select Table location: </li>
                                <li class="se">
                                    <asp:DropDownList ID="types" runat="server" AutoPostBack="True" class="time-dropdown form-dropdown validate[required, limitDate]" OnSelectedIndexChanged="types_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </li>
                                <div class="clear">
                                </div>
                            </ul>
                            <ul>
                                <li class="text-info">Select Table: </li>
                                <li class="se">
                                    <asp:DropDownList ID="tablename" runat="server" class="time-dropdown form-dropdown validate[required, limitDate]">
                                    </asp:DropDownList>
                                </li>
                                <div class="clear">
                                </div>
                            </ul>
                            <li class="text-info">Additional Message :</li>
                            <li>
                                <asp:TextBox ID="messageText" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </li>
                            <div class="clear">
                            </div>
                        </ul>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                        <div class="clear">
                        </div>
					</div>
				</div>
			</div></ContentTemplate>
        </asp:UpdatePanel>    </div>
    </form>
</body>
</html>
