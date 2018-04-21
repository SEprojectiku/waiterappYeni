<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessAddTable.aspx.cs" Inherits="waiterApp.BusinessAddTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
 <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>   
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   <script src="js/addTable.js"></script>
    <link href="cssBusiness/EditInfo.css" rel="stylesheet" />
    <title>Edit Menu</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 299px;
        }
        .auto-style2 {
            width: 299px
        }
        .auto-style3 {
            text-align: center;
            width: 91px;
        }
        .auto-style4 {
            width: 91px;
        }
        .auto-style5 {
            text-align: center;
            width: 302px;
        }
        .auto-style6 {
            width: 302px;
        }
        .auto-style7 {
            text-align: center;
            width: 131px;
        }
        .auto-style8 {
            width: 131px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      
         
   <nav class="navbar navbar-inverse navbar-fixed-top" style="width:96%; margin-left:2%; ">
   <div class="container ">
    <div class="navbar-header">
     <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">WaiterAPP</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li class="nav-item ">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Bookings</a>
      </li>
      
      <li class="nav-item">
           
        <a class="nav-link" href="#">Orders<span class="badge">5</span></a>
      </li>
       <li class="nav-item">
        <a class="nav-link" href="#">Messages<span class="badge">6</span></a>
      </li>   
      <li class="nav-item">
        <a class="nav-link" href="#">Daily Reports</a>
      </li>
      <li class="dropdown">
        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Edit
        <span class="caret"></span></a>
        <ul class="dropdown-menu">
          <li><a href="#">Information</a></li>
          <li><a href="#">Menu</a></li>
          
        </ul>
      </li>
      </ul>
      <div class="navbar-form navbar-right" role="search">
        <div class="form-group input-group">
          <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Search.."/>
          <span class="input-group-btn">
            
             <asp:ImageButton ID="SearchButton" class="btn btn-default"   runat="server" ImageUrl="images/Search.png" Height="34" Width="43" />
            
          </span>        
        </div>
      </div>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><span class="glyphicon glyphicon-user"></span>MestanliCafe</a></li>
      </ul>
    </div>
  </div>
</nav>
<div class="container text-center" style="margin-top:10%;">    
  <div class="row">
    <div class="col-sm-12 well">
      <div class="well">
        <p><a href="#">MestanliCafe</a></p>
        <img src="images/deneme.jpg" class="img-circle" height="65" width="65" alt="Avatar"/>
      </div>

    </div>
  </div>

     <div class="mainbody container-fluid">
 
    <div class="row clearfix">
		<div class="col-md-12 column">
			<table class="table table-bordered table-hover" id="tab_logic">
				<thead>
					<tr >
						<th class="auto-style7">
							#
						</th>
						<th class="auto-style1">
							Table Type
						</th>
						<th class="auto-style5">
							Name
						</th>
						<th class="auto-style3">
							Chair Number
						</th>
               
					</tr>
				</thead>
				<tbody>
					<tr id='addr0'>
						<td class="auto-style8">
						1
						</td>
						<td class="auto-style2">
						<asp:DropDownList type="select" ID="DropDownList0"  placeholder="Type" CssClass='form-control' runat="server">
                            <asp:ListItem Value="1">asd1</asp:ListItem>
                            <asp:ListItem Value="2">asd2</asp:ListItem>
                            <asp:ListItem Value="3">asd3</asp:ListItem>
                            </asp:DropDownList>
						
                           
						</td>

						<td class="auto-style6">
						<input type="text" name='name0' placeholder='Name' class="form-control"/>
						</td>
						<td class="auto-style4">
						<input type="text" name='chair0' placeholder='Chair Number' class="form-control"/>
						</td> 
                        
					</tr>
				</tbody>
			</table>
		</div>
	</div>
	     <asp:Button runat="server" Text="Save" OnClick="Unnamed1_Click" />
         <a id="add_row" class="btn btn-default pull-left">Add Row</a><a id='delete_row' class="pull-right btn btn-default">Delete Row</a>
         
</div>
</div>
    </form>
</body>
</html>

