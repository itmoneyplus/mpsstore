﻿<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="SalaryDeductions.aspx.vb" Inherits="Customer_SalaryDeductions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool_bank.ascx" TagName="Toolbaar_Bank"   TagPrefix="tool_bank"%>
<%@ Register Src="~/toolbaar/Cust_Payroll.ascx" TagName="Toolbaar_Payroll"   TagPrefix="tool_pay"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
<title>Salary Deductions</title>
      <%--   CSS used--%>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
<link rel="stylesheet" type="text/css" href="../css/menu.css" />

<script language="JavaScript" type="text/javascript" >
         javascript: window.history.forward(1);
</script> 

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
            width: 178px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="align">
    <%--<tool1:Toolbaar1 ID="tool_first" runat="server" />--%>
    <div id="title" 
                style="padding: 0px; margin: 0px; position: absolute; float: left; top: 0px; left: 0px;">
                <asp:Label ID="lblTitle" runat="server" Text="Money Plus" CssClass="menu_left"></asp:Label>  
                <a class="menu_right" href="../Login.aspx" onclick="javascript: return confirm('Please click OK to logout.');">
                       [Logout]</a>  
                <asp:LinkButton ID="LinkButton_back" runat="server" CssClass="menu_right" TabIndex="8">[Back]</asp:LinkButton>        
            </div>
           
                <ul id="menu" 
                style="padding: 0px; margin: 24px; position: absolute; top: 8px; left: -24px;">
                    <li>
                        <asp:LinkButton ID="Link_Home" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Default.aspx"
                            TabIndex="1">Home</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Customer" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/AddSearch.aspx"
                            TabIndex="2">Customer</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Cash" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
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
                            
                </ul>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarBankFile">
                
                      <li >
                            <asp:LinkButton ID="Link_Till" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Till.aspx"
                                    TabIndex="1"  >Update Till</asp:LinkButton></li>
                        
                        <li ><asp:LinkButton ID="Link_Safe" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Safe.aspx"
                            TabIndex="2"  >Update Safe</asp:LinkButton></li>
                        
                        <li >
                            <asp:LinkButton ID="Link_Movements" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Cash_Movements_Reports.aspx"
                            TabIndex="3"  >Cash Movements</asp:LinkButton></li>
                            
                        <li>
                            
                                <asp:LinkButton ID="Link_NAB" runat="server" CssClass="toolbaar1_link" TabIndex="4"  PostBackUrl="~/Customer/Bank_File_NAB.aspx">NAB Debit</asp:LinkButton>
                                
                        </li>
                        <li>
                        
                          <asp:LinkButton ID="Link_CBA" runat="server" PostBackUrl="~/Customer/Bank_File_CBA.aspx" CssClass="toolbaar1_link"
                        TabIndex="5" >CBA Debit</asp:LinkButton>
                           
                        </li>
                        <li>
                            <asp:LinkButton ID="Link_Customer_Credit" runat="server" CssClass="toolbaar1_link"  
                        TabIndex="6" PostBackUrl="~/Customer/Customer_Credit.aspx">Customer Credit</asp:LinkButton>
                        </li>
                    
                        <li>
                            <asp:LinkButton ID="Link_Payroll" runat="server"  TabIndex="7" Font-Bold="True" ForeColor="#2E95C9"
                        PostBackUrl="~/Customer/SalaryDeductions.aspx">Payroll File</asp:LinkButton>
                        </li>
                    
                        <li>
                            <asp:LinkButton ID="lbPaymentCollection" runat="server" 
                        TabIndex="8" PostBackUrl="~/Customer/Payment_Collection.aspx">Payment Collection</asp:LinkButton>
                        </li>
                    
                </ul>
            </td>
            
        </tr>
    </table>
   
    <table cellspacing="0" cellpadding="0" width="98%"  >
    <tr>
    <td class="style1" >
            <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                
                <tr runat="server" id="trreportAdmin" visible="true">
                    <td class="style3">
                        <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="Link_payroll_due" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_PayrollDue.aspx" TabIndex="1" >Payroll Deduction Due</asp:LinkButton>
                                </td>
                            </tr>                          
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="Link_viewpayroll" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_PayrollRec.aspx"  TabIndex="2">View Payroll Deductions</asp:LinkButton>
                                </td>
                            </tr>
                           
                            
                        </table>
                    </td>
                </tr>
            </table>
            
    </td> 
    <td style="border:1px solid gray; width:82%;vertical-align :top">
    <div align="left">
    <br />
      
                    
                    </div> 
                </td>
           </tr>
          </table>
  </asp:Panel>
   <%-- <tool_bank:Toolbaar_Bank ID="t_bank" runat="server" />
    <tool_pay:Toolbaar_Payroll ID="t_payroll" runat ="server" />--%>
    </div>
    </form>
</body>
</html>

