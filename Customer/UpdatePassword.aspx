<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UpdatePassword.aspx.vb" Inherits="Customer_ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/Reports_tab_periodic.ascx" TagName="Toolbaar_Rep1" TagPrefix="tool_rep1" %>
<%@ Register src="../toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>
<%@ Register src="../toolbaar/tools_admin.ascx" tagname="tools_admin" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
    
    <style type="text/css">
        #form1
        {
            margin-left: 80px;
        }
        .style1
        {
            width: 137px;            
            padding-left:23px;
           
            border:1px solid gray;
            vertical-align :top;            
            border-right-style:none;
        }
        .style3
        {
            width: 163px;
        }
        .style4
        {
            height: 66px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <%--<tool1:Toolbaar1 ID="Toolbaar1" runat="server" />--%>
            <div id="title" style="padding: 0px; margin: 0px; position: absolute; float: left;
                top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label>
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                    [Logout]</a>
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>
            </div>
            <ul id="menu" style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                 <li>
                        <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server"   CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server"  CssClass="toolbaar1_link"   PostBackUrl="~/Customer/Financial_Reports.aspx"
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
                        <asp:LinkButton ID="Link_Administration" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"    PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="7">Administration</asp:LinkButton>
                    </li>
            </ul>
            <br />
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table"
                cellpadding="0">
                <tr>
                    <td align="left">
                        <ul id="navbarOnlineJoined">
                            <li>
                                <asp:LinkButton ID="Link_admin" runat="server" Font-Bold="True" ForeColor="#2E95C9"
                                    PostBackUrl="" TabIndex="1" Text="Name Login"></asp:LinkButton>
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="98%">
                <tr>
                    <td class="style1">
                        <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                            <tr runat="server" id="trreportAdmin" visible="true">
                                <td class="style3">
                                    <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                                        <%--<tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep" >
                                                <asp:LinkButton ID="Link_UpdatePassword" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/UpdatePassword.aspx"
                                                    TabIndex="1" >Change Password</asp:LinkButton>
                                            </td>
                                        </tr>--%>
                                      
                                        <tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="lnkChangePassword" runat="server" CssClass="toolbaar1_link_active" PostBackUrl="~/Customer/ChangePassword.aspx"
                                                    TabIndex="2">Change Password</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <%--<tr class="toolbaar1_tr">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="lnkCreateUser" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx" 
                                                    TabIndex="2">Create User</asp:LinkButton>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="border: 1px solid gray; width: 82%; vertical-align: top">
                        <div align="left">                          
                            <table align="left" class="w100">
                              
                                    <tr style="display:none;">
                                        <td style="width:220px;">
                                            <img alt="" src="../Images/White_Right_Arrow.GIF" />&nbsp;&nbsp;
                                            <asp:Label ID="lblCustOfficerName" runat="server" CssClass="label_style"> Please select Name:</asp:Label>
                                            
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNames" runat="server" CssClass="droplist_teller">
                                                        </asp:DropDownList>
                                           
                                        </td>
                                        <td rowspan="3" valign="middle">
                                           
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:220px; padding-bottom:20px;" >
                                            <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            &nbsp;&nbsp;<asp:Label ID="lblNewPassword" runat="server"  CssClass="label_style">New Password:</asp:Label>
                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Style="width: 130px; margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td >
                                            <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            &nbsp;&nbsp;<asp:Label ID="lblConfirmPassword" runat="server"  CssClass="label_style">Confirm Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Style="width: 130px ; " CssClass="align-center_teller"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn"/>
                                            
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr >
                                        <td colspan="3" style="height: 25px;">
                                        
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3" style="text-align: right;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                   
                            
                               
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
