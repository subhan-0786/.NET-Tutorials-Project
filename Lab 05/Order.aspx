<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Order.aspx.vb" Inherits="Order" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Place an Order</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="order">
            <h2 style="text-align:center;">Place an Order</h2>
            <table align="center" cellpadding="10">
                <tr>
                    <td><label for="product">Product Name:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlProduct" runat="server" required="required"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label for="quantity">Quantity:</label></td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <hr><br>
                        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="text-align:center;">
                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>