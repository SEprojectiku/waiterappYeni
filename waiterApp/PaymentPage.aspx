<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="waiterApp.PaymentPage" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>UI 1</title>
    <link rel="shortcut icon" href="paypal.png">
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600" rel="stylesheet">
    <link rel="stylesheet" href="css/stylepayment.css" charset="utf-8">
  </head>
  <body>
      <form runat="server">
    <div class="paypal">
      <div class="paypal__header">

        <div class="paypal__header-info">
          <span class="paypal__date">
    <asp:Label ID="orderdate" runat="server" Text="Label"></asp:Label></span>
          <span class="paypal__ref">0f-113</span>
        </div>
      </div>

      <div class="paypal__subheader-wrapper">
        <div class="paypal__subheader">
          <h1 class="paypal__username">Sefa, Hi</h1>
          <span class="paypal__help-text">you've purchased in our store:</span>
        </div>
      </div>

      <div class="paypal__cart">
        <h2 class="paypal__cart-title">Cart:</h2>
        <ul class="paypal__cart-list">
          <li class="paypal__cart-item">
<asp:DataList ID="DataList1" runat="server"><ItemTemplate>

            <asp:Label ID="Label1" class="paypal__item-name" runat="server" Text='<%#Eval("foodbeveragesName")%>'></asp:Label>
             <asp:Label ID="Label2" class="paypal__item-name" runat="server" Text='<%#Eval("piece")%>'></asp:Label>
            <asp:Label ID="Label3" class="paypal__item-name" runat="server" Text='<%#Eval("total")%>'></asp:Label>

    </ItemTemplate></asp:DataList>
    <span>Total Price is: </span><asp:Label ID="Total" runat="server" Text="Label"></asp:Label>
          </li>
          
        </ul>
	  <input class="w3-radio" type="radio" name="gender" value="Cash" checked>
      <label>Cash</label>
	  <input class="w3-radio" type="radio" name="gender" value="Credit Card">
      <label>Credit Card</label>
	  <asp:Button ID="paybutton" runat="server" Text="Pay"  class="w3-button w3-blue" OnClick="paybutton_Click" /></div>
    </div>

      </form>
  </body>
</html>
</body>
</html>