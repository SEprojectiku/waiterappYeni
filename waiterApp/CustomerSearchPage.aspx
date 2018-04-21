<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSearchPage.aspx.cs" Inherits="waiterApp.CustomerSearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
  
<link href="css/EditInfo.css" type="text/css" rel="stylesheet"/>
    <link href="css/CustomerSearchSS.css" rel="stylesheet" />
    <title>CustomerSearchPage</title>
   
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
        <li><a href="#"><span class="glyphicon glyphicon-user"></span>Tuncay Yılmaz</a></li>
      </ul>
    </div>
  </div>
</nav>


<div class="container text-center" style="margin-top:10%;">    
  <div class="row">
    <div class="col-sm-12 well">
      <div class="well">
        <p><a href="#">Tuncay Yılmaz</a></p>
        <img src="images/deneme.jpg" class="img-circle" height="65" width="65" alt="Avatar"/>
      </div>

    </div>
  </div>

     <div class="panel-group">

        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group input-group" style="width:100%;">

                
                <asp:DropDownList ID="SelectState"  class="form-control" style="float:left;" Width="30%"  runat="server" >
                    <asp:ListItem Value="0">Type a City or Country Name</asp:ListItem>
                    </asp:DropDownList>
                
                <asp:Button ID="SearchResID" Text="Search" style="float:right; " runat="server" class="btn btn-primary" OnClick="SearchResID_Click"/>
                <asp:TextBox id="SearchBox" class="form-control" style="float:right; "  Width="40%" runat="server" />
                
           
                
                </div>
            
            </div>


        </div>

<script type="text/javascript">
           $("#SelectState").select2({
               tags: true
           });

    </script>
     

     <div class="panel panel-primary">
         
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   <asp:Panel ID="Panel1" runat="server" Width="20%" style="float:left;" class="panel panel-primary">
                     <%--  <h3>Filters</h3>
                       <asp:LinkButton ID="Hightlow" runat="server" OnClick="Hightlow_Click">Cost-High to Low</asp:LinkButton>
                        <br/>
                       <asp:LinkButton ID="Lowhigh" runat="server" OnClick="Lowhigh_Click">Cost-Low to High</asp:LinkButton>
                        <br/>
                        <asp:LinkButton ID="Newold" runat="server" OnClick="Newold_Click">Recently Added-New to Old</asp:LinkButton>
                       --%>
                       <h3>Categories</h3>
                        <asp:Repeater ID="CategoryButtonList"  runat="server"  >
                            <ItemTemplate>
                                <asp:LinkButton ID="Buttons"  runat="server" CommandArgument='<%#Eval("typeID")%>' OnClick="Buttons_Click"><%#Eval("typeName")%></asp:LinkButton>
                                <br/>
                            </ItemTemplate>

                        </asp:Repeater>
                       
                   </asp:Panel>

                   <asp:Panel ID="Panel2" runat="server" Width="80%" style="float:right;">
                <asp:Repeater ID="BusinessList" runat="server" OnItemDataBound="BusinessList_ItemDataBound" OnItemCommand="BusinessList_ItemCommand">
                  <ItemTemplate>
                    <div class="bs-calltoaction bs-calltoaction-default" style="width:100%;">
                    <div class="row">
                        <div class=" cta-contents" >
                            
                            <h1 style="float:left;"><%#Eval("bName")%></h1>
                            <div class="cta-desc">
                               
                                <h5>Category:  <asp:Repeater ID="Repeater2" runat="server">
                               <ItemTemplate><asp:Label ID="carlbl" runat="server" Text='<%#Eval("typeName")%>'></asp:Label><asp:Label ID="Label1" runat="server" Text=" "></asp:Label></ItemTemplate></asp:Repeater></h5>
                                   
                                <h5>State:<%#Eval("stateName")%></h5>
                                <h6>Adress:<%#Eval("adress")%></h6>
                                <h3>Work Hours:<%#Eval("workOpen")%>-<%#Eval("workClose")%></h3>
                            </div>
                        </div>
                        <div class="col-md-3 cta-button">
                            <asp:Button ID="Button1" runat="server" Text="Go for It!" CommandArgument='<%#Eval("bID")%>' OnClick="Button1_Click"/>
                        </div>
                     </div>
                </div>
                </ItemTemplate>
           </asp:Repeater>
                   </asp:Panel>



                </ContentTemplate>
                 <Triggers>
                <asp:AsyncPostBackTrigger ControlID="SearchResID" />
            </Triggers>  
              </asp:UpdatePanel>     
                   



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

