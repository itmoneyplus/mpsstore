<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Customer_Default" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool_first"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    
    <head runat="server">
    <title>Desk</title>
     <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <link rel="stylesheet" type="text/css" href="../css/menu.css" />
     <script language="JavaScript" type="text/javascript" >
     
         javascript: window.history.forward(1);
         
     </script>
    </head>
    <body>
    <form id="form2" runat="server">
    <%--<tool_first:Toolbaar1 ID ="tool1" runat="server" />--%>
    <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label> 
                
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       [Logout]</a>  
                <asp:LinkButton ID="LinkButton_Back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton> 
                <asp:Label ID="LabelAccount" runat="server" CssClass="menu_right" Text=""></asp:Label>       
            </div>
            <%-- <table id="toolbar_table" cellspacing="0" class="table_toolbaar">
                    <tr class="toolbaar1_tr">
                        <td class="toolbaar1_td">
                            <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                                TabIndex="1">Home</asp:LinkButton>
                            <asp:Label ID="Label1" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                                TabIndex="2">Customer</asp:LinkButton>
                            <asp:Label ID="Label2" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File.aspx"
                                TabIndex="3">Cash Movements</asp:LinkButton>
                            <asp:Label ID="Label3" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                                TabIndex="4">Reports</asp:LinkButton>
                            <asp:Label ID="Label4" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx"
                                TabIndex="5">Marketing</asp:LinkButton>
                            <asp:Label ID="Label5" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                                TabIndex="6">Online Joined</asp:LinkButton>
                            <asp:Label ID="Label6" runat="server">|</asp:Label>
                            <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link"
                                TabIndex="7">Administration</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton>
                        </td>
                        <td class="toolbaar1_td_right">
                            <a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                                [Logout]</a>
                        </td>
                    </tr>
                </table>--%>
                <ul id="menu" 
                style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                    <li>
                        <asp:LinkButton ID="Link_Home" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"  PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Marketing" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Marketing_Report.aspx"
                            TabIndex="5">Marketing</asp:LinkButton>
                    </li>
                   <%-- <li>
                        <asp:LinkButton ID="Link_Audit" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Online_Joined.aspx"
                            TabIndex="6">Online Joined</asp:LinkButton>
                    </li>--%>
                    <li>
                        <asp:LinkButton ID="Link_Administration" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                        </li>
                   <%--<li class="menu_right"><a class="toolbaar1_link" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       <b> [Logout]</b></a></li>
                    <li class="menu_right">
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" TabIndex="8">[Back]</asp:LinkButton></li>--%>           
                </ul>
    <div class="align-right">
    <table cellpadding="0" cellspacing="0" class="table_desk"  >
    <tr>
    <td class="td_desk">
    <p>&nbsp;</p> 
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    </td>
    </tr>
    </table> 
    </div>
	<br />
	<br />
	<br />
	<br />
	<br />
	<br />
    <div class ="align-right2"><img alt="logo" id="img"  src="../Images/logo.png" width="320" height="100"  /> </div>
    </form>
    </body>
    </html>