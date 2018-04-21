<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelReservation.aspx.cs" Inherits="waiterApp.CancelReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
<link href="css/BusinessHomeSS.css" type="text/css" rel="stylesheet"/>
 <title>Home</title>
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
        <a class="nav-link" href="#">Home<span class="sr-only">(current)</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="#">Bookings</a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="#">Orders</a>
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
        <li><a href="#"><span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="navbarname" runat="server" Text="Label"></asp:Label></a></li>
      </ul>
    </div>
  </div>
</nav>
    <div class="container text-center" style="margin-top:10%;">    
  


  <div class="panel-group">
    <div class="panel panel-default">


    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
          <h3>Reservation Detailed Informations</h3>

      </div>
     <div class="panel-body">

    <table class="table  table-striped custab">

      <tbody>

<tr>  <td><span>Restourant Name: </span><asp:Label ID="rname" runat="server" Text=""></asp:Label></td></tr>
      <tr>
        <td ><span>reservaton date: </span><asp:Label ID="date" runat="server" Text=""></asp:Label></td></tr>
      <tr>  <td><span>reservation Time: </span><asp:Label ID="time" runat="server" Text=""></asp:Label></td></tr>
      
       <tr> <td><span>Latest Cancel Hours before: </span><asp:Label ID="canceltime" runat="server" Text=""></asp:Label></td></tr>
     <tr> <td><span>Latest Cancel Fine: </span><asp:Label ID="cancelfine" runat="server" Text=""></asp:Label></td></tr>

    
 </tbody>
         </table> 
     
 </div> 
        <asp:Button ID="cancelbutton" runat="server" Text="Cancel Reservation" OnClick="cancelbutton_Click" />

     
    </div>
    
 </div>


</div>

 <div class="page-footer font-small blue pt-4 mt-4" style="margin-bottom:2%;">
    <div class="footer-copyright py-3 text-center">
              <div class="container-fluid">
                  <a> © 2018 Copyright: WaiterAPP </a>
      
              </div>
          </div>
          <!--/.Copyright-->
      
      </div>
    </form>
</body>
</html>
