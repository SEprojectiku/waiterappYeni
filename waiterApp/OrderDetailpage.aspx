<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailpage.aspx.cs" Inherits="waiterApp.OrderDetailpage" %>

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
        <a class="nav-link" href="BusinessHome.aspx">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="viewReservations.aspx">Bookings</a>
      </li>
      
      <li class="nav-item">
           
        <a class="nav-link" href="BusinessHome.aspx">Orders<span class="badge"></span></a>
      </li>
           <li class="nav-item">
           
        <a class="nav-link" href="BusinessViewTables.aspx">Tables<span class="badge"></span></a>
      </li>
       <%--<li class="nav-item">
        <a class="nav-link" href="#">Messages<span class="badge">6</span></a>
      </li>   --%>
      <%--<li class="nav-item">
        <a class="nav-link" href="#">Daily Reports</a>
      </li>--%>
      <li class="dropdown">
        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Edit
        <span class="caret"></span></a>
        <ul class="dropdown-menu">
          <li><a href="BusinessEditInfo.aspx">Information</a></li>
          <li><a href="BusinessListMenus.aspx">Menu</a></li>
          <li><a href="editTables.aspx">Tables</a></li>
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
        <li> <asp:Label ID="navbarname" runat="server" Text="Label"></asp:Label></li>
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

<tr>  <td><span>User Name: </span><asp:Label ID="uname" runat="server" Text=""></asp:Label></td></tr>
      <tr>
        <td ><span>order date: </span><asp:Label ID="date" runat="server" Text=""></asp:Label></td></tr>
      
     <tr> <td><span>ordered Items: </span><asp:Label ID="cancelfine" runat="server" Text=""></asp:Label></td></tr>

    
 </tbody>
         </table>
         <asp:Repeater ID="Repeater1" runat="server"><ItemTemplate>
         <div>

             <asp:Label ID="Label1"  runat="server" Text='<%#Eval("foodbeveragesName")%>'></asp:Label>
             <asp:Label ID="Label2"  runat="server" Text='<%#Eval("piece")%>'></asp:Label>X
             <asp:Label ID="Label4"  runat="server" Text='<%#Eval("price")%>'></asp:Label>
            <asp:Label ID="Label3"  runat="server" Text='<%#Eval("semitotal")%>'></asp:Label>

         </div>
          </ItemTemplate></asp:Repeater>
 </div>
        <asp:Button ID="confirmbutton" runat="server" Text="Confirm Order" OnClick="confirmbutton_Click"/>
        <asp:Button ID="cancelbutton" runat="server" Text="Cancel Order" OnClick="cancelbutton_Click"/>

     
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
