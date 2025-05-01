<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee List</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            padding-top: 50px;
        }
        .gridview {
            margin: 0 auto;
            border-collapse: collapse;
        }
        .gridview th, .gridview td {
            border: 1px solid #ccc;
            padding: 8px 12px;
        }
        .load-button {
            display: block;
            margin: 20px auto 0;
            padding: 8px 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style = "display: inline-block">
            <h2>EMPLOYEE LIST</h2>
            <asp:GridView ID="gridEmployees" runat="server" CssClass="gridview" AutoGenerateColumns="True" />
            <asp:Button ID="btnLoad" runat="server" Text="Load Employees" OnClick="btnLoad_Click" CssClass="load-button" />
        </div>
    </form>
</body>
</html>
