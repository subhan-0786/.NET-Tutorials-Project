<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Search.aspx.vb" Inherits="Search" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Search Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="search">
            <h2 style="text-align:center;">Search Products</h2>
            <table align="center" cellpadding="10">
                <tr>
                    <td><label for="search">Enter product name:</label></td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <hr><br>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="text-align: center;">
                <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="False" Visible="false" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                        <asp:BoundField DataField="Unit_Price" HeaderText="Unit Price" />
                        <asp:BoundField DataField="Stock_Quantity" HeaderText="Stock Quantity" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>