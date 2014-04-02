<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test_test" %>

<%@ Register src="../toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <div style="display:none;">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="lblPnl" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        </div>
        <asp:Literal ID="ltrlDrp" runat="server"></asp:Literal>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <uc1:tool_report ID="tool_report1" runat="server" />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
    </form>
</body>
</html>
