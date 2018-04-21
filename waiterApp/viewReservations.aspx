<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewReservations.aspx.cs" Inherits="waiterApp.viewReservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   	<title>Rezervation List</title>
	<meta charset="UTF-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/perfect-scrollbar/perfect-scrollbar.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css"/>
	<link rel="stylesheet" type="text/css" href="css/main.css"/>
<!--===============================================================================================-->
    <style type="text/css">
        .auto-style1 {
            width: 213px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="limiter">
		<div class="container-table100">
			<div class="wrap-table100">
                
				<div class="table100 ver1">
                    
					<div class="table100-firstcol">
						<table>
							<thead>
								<tr class="row100 head">
									<th class="cell100 column1">Name And Surname</th>
								</tr>
							</thead>
							<tbody>
                                
								<tr class="row100 body"><asp:DataList ID="DataList2" runat="server"><ItemTemplate>
									<td class="cell100 column1">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' ></asp:Label></td>
								
                                    </ItemTemplate></asp:DataList></tr>
							</tbody>
						</table>
					</div>
					
					<div class="wrap-table100-nextcols js-pscroll">
						<div class="table100-nextcols">
							<table>
								<thead>
									<tr class="row100 head">
										<th class="auto-style1">Reservation Date</th>
										<th class="cell100 column3">Time</th>
										<th class="cell100 column4">Table Name</th>
										<th class="cell100 column5">Request</th>
										<th class="cell100 column6">Phone No</th>
										<th class="cell100 column7">Contacts</th>
									</tr>
								</thead>
								<tbody><tr class="row100 body">
                                    <asp:DataList ID="DataList1" runat="server"><ItemTemplate>
									
										<td class="cell100 column2">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Dates") %>'></asp:Label></td>
										<td class="cell100 column3">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Times") %>'></asp:Label></td>
										<td class="cell100 column4">
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("tName") %>'></asp:Label></td>
										<td class="cell100 column5">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Request") %>'></asp:Label></td>
										<td class="cell100 column6">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("phoneNumber") %>'></asp:Label></td>
										<td class="cell100 column7">
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("email") %>'></asp:Label></td>
									
                   </ItemTemplate></asp:DataList></tr>
								</tbody>
							</table>
						</div>
					</div> 
				</div>
			</div>
		</div>
	</div>


<!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/perfect-scrollbar/perfect-scrollbar.min.js"></script>
	<script>
		$('.js-pscroll').each(function(){
			var ps = new PerfectScrollbar(this);

			$(window).on('resize', function(){
				ps.update();
			})

			$(this).on('ps-x-reach-start', function(){
				$(this).parent().find('.table100-firstcol').removeClass('shadow-table100-firstcol');
			});

			$(this).on('ps-scroll-x', function(){
				$(this).parent().find('.table100-firstcol').addClass('shadow-table100-firstcol');
			});

		});

		
		
		
	</script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
    </div>
    </form>
</body>
</html>
