<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessEditInfo.aspx.cs" Inherits="waiterApp.BusinessEditInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
<link href="css/EditInfo.css" type="text/css" rel="stylesheet"/>
 <title>EditInfo</title>
   
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
                    <h3 class="panel-title pull-left" style="font-size:30px;">Business Profile</h3>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <h3 class="panel-title pull-left">Business Information</h3>
                    <br/><br/>
                    <div class="form-horizontal">
                        <label for="First_name">Business name</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="bname" />
                         <label for="email">Description</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="bdesc" />

                        <label for="Phone_num">Phone</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="p1" />
                        <label for="email">Phone2</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="p2"/>
                        
                         <label for="email">Email</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="email" />
                       
                        <label for="email">Country</label>
                        <asp:DropDownList ID="countrylist" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="countrylist_SelectedIndexChanged"></asp:DropDownList>
                        <label for="email">City</label>
                        <asp:DropDownList ID="cityist" class="form-control" runat="server"></asp:DropDownList>
                        
                        <label for="email">lat</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="lat" />
                        <label for="email">lng</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="lng" />
                        <label for="email">Avarage Price</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="avg" />
                        <label for="email">Work Open</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="wopen" />
                        <label for="email">Work Close</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="wclose" />
                        <label for="email">Currency</label>
                        <asp:DropDownList ID="currencylist" CssClass="form-control" runat="server"></asp:DropDownList>
                        <label for="email">Language</label>
                        <asp:DropDownList ID="langlist" CssClass="form-control" runat="server"></asp:DropDownList>

                    </div>
                </div>
            </div>
            <asp:Button ID="editmenubutton" runat="server" CssClass="form-control" Text="Edit Menu" OnClick="editmenubutton_Click"/>
            <asp:Button ID="edittablebutton" runat="server" CssClass="form-control" Text="Edit Tables" OnClick="edittablebutton_Click"/>
            <asp:Button ID="savebutton" runat="server" Text="Save Changes" OnClick="savebutton_Click"/>
            <div class="panel panel-default">
                <div class="panel-body">
                    
                    <br/>
                    <div >
                        <div class="col-lg-12 col-md-12">
                            <img class="img-thumbnail img-responsive" src="images/Upload.jpeg" width="300" height="300"/>
                        </div>
                        <div class="col-lg-12 col-md-12">
                            <asp:Button runat="server" class="btn btn-primary" Text="Upload a new photo!"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
               <div class="panel-body">
                 <div class="row">
                 <div class="col-md-6 col-md-offset-3">
                  <div class="form-horizontal well" role="form">
                   <div class="row">
                     <div class="col-xs-6">
                        <img src="http://placehold.it/160x100" class="img-responsive img-radio"/>
                     <asp:Button runat="server" Text="Delete" type="button" class="btn btn-primary btn-radio"></asp:Button>
                
                    </div>
                     <div class="col-xs-6">
                       <img src="http://placehold.it/160x100" class="img-responsive img-radio"/>
                      <asp:Button runat="server" Text="Delete" type="button" class="btn btn-primary btn-radio"></asp:Button>
               
                     </div>
                    <div class="col-xs-6">
                      <img src="http://placehold.it/160x100" class="img-responsive img-radio"/>
                      <asp:Button runat="server" Text="Delete" type="button" class="btn btn-primary btn-radio"></asp:Button>
                
                    </div>
                  </div>
           
                 </div>
                </div>
              </div>
            


               
               </div>
           </div>  



            <div class="panel panel-default">
                <div class="panel-body">
                     <div class="form-horizontal">
                        <label for="Your_location">Your location</label>
                        <asp:TextBox runat="server" type="text" class="form-control" id="Your_location" placeholder="Fill me out"/>
                        <br/>
                        
                        
                    </div>
                </div>
            </div>
            
       






















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

