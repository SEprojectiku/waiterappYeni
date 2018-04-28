<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenuYeni.aspx.cs" Inherits="waiterApp.EditMenuYeni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="css/EditInfo.css" type="text/css" rel="stylesheet"/>

    <title>EditMenuYeni</title>
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
          <div class="mainbody container-fluid">
             <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 
                   

                         <div class="panel panel-default"> 
                         
                        <div class="panel-body">
                      
                  
                         <asp:Repeater ID="Repeater1" runat="server" onitemdatabound="Repeater1_ItemDataBound">
                       <ItemTemplate>
                             
                        
                       <table class="table table-striped custab">  
                          
                               <thead>
                                   
                               <tr>
                              <th class="text-center">Name</th>
                              <th class="text-center">Ingredients</th>
                              <th class="text-center">Price</th>
                              <th class="text-center"></th>
                               </tr>
                              </thead>
                           
                            <h2 class="panel-title pull-left"><%#Eval("catName") %></h2>
                      
                              <asp:Repeater ID="Repeater2" runat="server">
        
                               <ItemTemplate>
                         
                           <tr> 
                              
                            <td> <asp:TextBox runat="server" Text='<%#Eval("foodbeveragesName")%>'></asp:TextBox> </td>
                            <td> <asp:TextBox runat="server" Text='<%#Eval("ingredients")%>'></asp:TextBox> </td>
                            <td> <asp:TextBox runat="server" Text='<%#Eval("price")%>'></asp:TextBox> </td>
                           
                              <td class="text-center">	<%--<input type="checkbox" name="check" checked='<%#Eval("visibility")%>' aria-invalid="true" disabled="disabled" /> <span class="label-text">Visibilty</span>--%>
                                  <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("visibility")%>' Enabled="false"/>
                                  <asp:Button ID="showbutton" runat="server" Text="Show" CommandArgument='<%#Eval("foodbeveragesID")%>' OnClick="showbutton_Click"/>
                                  <asp:Button ID="hidebutton" runat="server" Text="Hide" CommandArgument='<%#Eval("foodbeveragesID")%>' OnClick="hidebutton_Click"/>
                             <asp:Button ID="Button1" runat="server" class="btn btn-danger btn-xs" style="float:right;" Text="Del" CommandArgument='<%#Eval("foodbeveragesID")%>' OnClick="Button1_Click"></asp:Button></td>
                           </tr>
                        
                        </ItemTemplate>
                        
                       </asp:Repeater>
                     </table>
                    </ItemTemplate>
                 </asp:Repeater>
                            <asp:Button ID="additem" class="btn btn-default pull-left" runat="server" Text="Add Item" OnClick="additem_Click" />
                  </div>
                </div>
        
            
       
        
        
        
          </div>
    </div>
</div>
 </div>
    </form>
</body>
</html>
