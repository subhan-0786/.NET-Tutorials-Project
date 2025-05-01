<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Page Life Cycle Events</title>


        <style type="text/css">
          #Text1 {
            text-align: center;
            width: 495px;
            height: 20px;
            margin-left: auto;  
            margin-right: auto; 
          }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <div> 

            <input id="Text1" runat="server" type="text" />
            <br /><br /><br />
             
            <div id="msg" runat="server"></div>
            <br /><br /><br />
             
            &nbsp;<input id="Button1" runat="server" type="button" value="CLICK BUTTON" />
        </div>
    </form>
</body>
</html>
