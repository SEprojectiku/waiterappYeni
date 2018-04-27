<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs"   Inherits="waiterApp.Default" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <title>Waiter</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
      <script defer src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>



    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="/css/css.css">
  </head>
  <body class="text-white">
      
   <div class="bg">
    <div class="container text-center "><form runat="server">
	    <h1 class="display-1 pt-5">Your Waiter</h1>
	    <p class="lead mb-5">Look for a restaurant, book and order!</p>
	    <div class="col-lg-6 mx-auto mb-5">
		    <div class="input-group">
		      <%--<input type="text" class="form-control" placeholder="Enter " aria-label="Search for...">
		      <span class="input-group-btn">
		        <button class="btn btn-primary" type="button">Search</button>
		      </span>--%>
               <%-- <input type="text" class="form-control input-lg" placeholder="Buscar" />--%>
                <asp:TextBox runat="server" CssClass="form-control input-lg" />
                    <span class="input-group-btn">
                        <%--<asp:ImageButton runat="server" CssClass="btn btn-info btn-lg " ImageUrl="fab fa-sistrix" />--%>
                        <button class="btn btn-info btn-lg" type="button">
                            <i class="fab fa-sistrix"></i>
                        </button>
                    </span> 
		    </div>
            
	    </div>
        <div class="row justify-content-center">
         <div class="btn-group mt-1 mb-3" role="group" aria-label="Basic example">
             <asp:Button runat="server" CssClass="btn btn-primary btn-lg" PostBackUrl="Login.aspx" Text="Login" />
            
            <asp:Button  runat="server" CssClass="btn btn-light btn-lg" PostBackUrl="~/signup.aspx" Text="Sign Up"/>
        <!-- butonu anchorla değiştirebiliyourz burda hrefi aşağıdaki spekersa hedefledik-->        
          </div></div>
		<button class="loginBtn loginBtn--facebook">
		  Login with Facebook
		</button>

		<button class="loginBtn loginBtn--google">
		  Login with Google
		</button></form>
    </div>
   </div>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
  
  </body>
</html>
