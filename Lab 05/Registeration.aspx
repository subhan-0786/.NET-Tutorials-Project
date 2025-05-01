<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Registeration.aspx.vb" Inherits="Registeration" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Registration Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 style="text-align:center;">REGISTER YOURSELF</h1>
            <table align="center" cellpadding="10">
                <tr>
                    <td><label for="name">Full Name:</label></td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><label for="email">Address:</label></td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><label for="phone">Phone:</label></td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <hr><br />
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
