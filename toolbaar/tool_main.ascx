<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool_main.ascx.vb" Inherits="WebUserControl" %>
<head>
    <title>tool_main</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <link rel="stylesheet" type="text/css" href="../css/menu.css" />
</head>

<div id="title"
    style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
    <asp:Label ID="lblTitle" runat="server" Text="Money Plus" Width></asp:Label>  
    <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
           [Logout]</a>  
    <asp:LinkButton ID="LinkButton8" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>        
</div>

<%--<div id="toolbar">--%>
   
    <ul id="menu" style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
        <li>
            <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                TabIndex="1">Home</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                TabIndex="2">Customer</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File.aspx"
                TabIndex="3">Cash Movements</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                TabIndex="4">Reports</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx"
                TabIndex="5">Marketing</asp:LinkButton></li>
       <%-- <li>
            <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                TabIndex="6">Online Joined</asp:LinkButton></li>--%>
        <li>
            <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"
                TabIndex="7">Administration</asp:LinkButton></li>                 
      
    </ul>
<%--</div>--%>
