<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessHome.aspx.cs" Inherits="waiterApp.BusinessHome" %>
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
  <div class="row">
    <div class="col-sm-12 well">
      <div class="well">
        <p> <asp:Label ID="myName" runat="server" Text="Label"></asp:Label></p>
        <img src="images/deneme.jpg" class="img-circle" height="65" width="65" alt="Avatar"/>
      </div>

    </div>
  </div>


  <div class="panel-group">
    <div class="panel panel-default">
        <div>
            <asp:Button ID="editinfobutton" runat="server" Text="Edit Business Information" class="btn btn-success" OnClick="editinfobutton_Click"/>

        </div>
      <div class="panel-heading">
          <h3>Recent Orders</h3>

      </div>
      <div class="panel-body">

          <div class="row">
        <div class="col-sm-4">
            <asp:Repeater ID="Repeater1" runat="server"><ItemTemplate>
             <div class="well">
            <h4><%#Eval("tName")%></h4>
            <p><%#Eval("orderID")%></p> 
            <p><%#Eval("orderDate")%></p>
          <asp:Button runat="server" Text="Check"  class="btn btn-success" CommandArgument='<%#Eval("orderID")%>' OnClick="Unnamed_Click"/>
          </div>
        </div>
        </ItemTemplate></asp:Repeater>
       
      </div>


      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
          <h3>Recent Reservations</h3>

      </div>
     <div class="panel-body">

    <table class="table  table-striped custab">
    <thead >
      <tr  >
        <th class=" text-center">Date</th>
        <th class="text-center" >Time</th>
        <th class=" text-center">Table No</th>
        <th class=" text-center" >Request</th>
        
      </tr>
    </thead>
      <tbody>
        <asp:Repeater ID="DataList1" runat="server">
            <ItemTemplate> 
      
      
        
      <tr>
        <td ><asp:Label ID="Label2" runat="server" Text='<%# Eval("Dates") %>'></asp:Label></td>
        <td  ><asp:Label ID="Label3" runat="server" Text='<%# Eval("Times") %>'></asp:Label></td>
        <td ><asp:Label ID="Label4" runat="server" Text='<%# Eval("tName") %>'></asp:Label></td>
        <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("Request") %>'></asp:Label></td>
     </tr>
     </ItemTemplate>
    </asp:Repeater>  
    
 </tbody>
  
   
         </table> 
      
            
 </div>
  
        <asp:Button ID="Button1" runat="server" Text="Details" OnClick="Button1_Click"/>

     
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