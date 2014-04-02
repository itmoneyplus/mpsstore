<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Print_AgeS_Report.aspx.vb"
    Inherits="Reports_Print_AgeS_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Age Stats</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<body onload="window.print();" ondblclick='JavaScript:history.go(-1);'>
    <form id="form1" runat="server">
    <div align="left">
        &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" CssClass="italics1-doc" Text="Label" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
