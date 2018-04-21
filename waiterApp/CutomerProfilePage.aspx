<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutomerProfilePage.aspx.cs" Inherits="waiterApp.CutomerProfilePage" EnableEventValidation="false" %>

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
  <div class="row">
    <div class="col-sm-12 well">
      <div class="well">
        <p>
            <asp:Label ID="myName" runat="server" Text="Label"></asp:Label></p>
        <img src="images/deneme.jpg" class="img-circle" height="65" width="65" alt="Avatar"/>
      </div>

    </div>
  </div>
    <span>update language and currency preferences: </span>
    <asp:DropDownList ID="currencylist" runat="server" OnSelectedIndexChanged="currencylist_SelectedIndexChanged" >
        <asp:ListItem Value="0">select curr</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="langlist" runat="server" OnSelectedIndexChanged="langlist_SelectedIndexChanged" >
        <asp:ListItem Value="0">select lang</asp:ListItem>
    </asp:DropDownList>
  <div class="panel-group">
    <div class="panel panel-default">
      <div class="panel-heading">
          <h3>Recent Orders</h3>

      </div>
      <div class="panel-body">
          <%--orderlar buraya yazılacak--%>
        
 </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
          <h3>Coming Reservations</h3>

      </div>
     <div class="panel-body">

    <table class="table  table-striped custab">
    <thead >
      <tr  >
        <th class=" text-center">Date</th>
        <th class="text-center" >Time</th>
        <th class=" text-center">Table Name</th>
        <th class=" text-center">Restorant Name</th>
        
      </tr>
    </thead>
      <tbody>
        <asp:Repeater ID="DataList1" runat="server">
            <ItemTemplate> 

      <tr>
        <td ><asp:Label ID="Label2" runat="server" Text='<%# Eval("reservationDate") %>'></asp:Label></td>
        <td  ><asp:Label ID="Label3" runat="server" Text='<%# Eval("reservationTime") %>'></asp:Label></td>
        <td ><asp:Label ID="Label4" runat="server" Text='<%# Eval("tName") %>'></asp:Label></td>
        <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("bName") %>'></asp:Label></td>
        <td>  <asp:Button ID="detailbutton" runat="server" Text="Details" CommandArgument='<%# Eval("resID") %>' OnClick="detailbutton_Click"/></td>
     </tr>
     </ItemTemplate>
    </asp:Repeater>  
    
 </tbody>
         </table> 
     
 </div> 
        

     
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