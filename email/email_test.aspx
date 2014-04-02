<%@ Page Language="VB" AutoEventWireup="false" CodeFile="email_test.aspx.vb" Inherits="email_email_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" MaxLength="250" Width="250px"></asp:TextBox>
        <asp:Button ID="btnSend" runat="server" Text="Send" />
    
    </div>
    </form>
</body>
</html>
