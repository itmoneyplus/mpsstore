﻿<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Financial_Reports.aspx.vb" Inherits="Customer_Financial_Reports" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Financial Reports</title>
    <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <link rel="stylesheet" type="text/css" href="../css/menu.css" />

    <script language="JavaScript" type="text/javascript">
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
            width: 163px;
        }
    </style>
    
</head>
<body>
     <form id="form1" runat="server">
     <div>
        <div >
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
                        <asp:LinkButton ID="Link_Cash" runat="server"   CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                            TabIndex="3">Cash Movements</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="Link_Reports" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9" PostBackUrl="~/Customer/Financial_Reports.aspx"
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
          
        </div>
    <asp:Panel ID="Panel1" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                    <li >
                        <asp:LinkButton ID="Link_Financial" runat="server"   
                            TabIndex="1" PostBackUrl="~/Customer/Financial_Reports.aspx" Font-Bold="True" 
                            ForeColor="#2E95C9">Financial Reports</asp:LinkButton>
                        
                    </li>
                    <li>
                      <asp:LinkButton ID="Link_Periodic" runat="server" TabIndex="2" PostBackUrl="~/Customer/Periodic_Reports.aspx">Periodic Reports</asp:LinkButton>
                       
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
                                    <asp:LinkButton ID="Link_teller" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Tellers_Report.aspx"
                            TabIndex="1">Teller</asp:LinkButton>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_sales.aspx"
                                        TabIndex="2">Sales</asp:LinkButton>
                                </td>
                            </tr>
                            <tr >
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_cashed.aspx"
                                        TabIndex="4">Cheque Cashed</asp:LinkButton>
                                </td>
                            </tr>
                           <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_dishonoured.aspx"
                                        TabIndex="6">Dishonoured Cheques</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_loan_debtor.aspx"
                                        TabIndex="7">Loan/LOC Debtor</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton6" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_loan_settlement.aspx"
                                        TabIndex="8">Loan/LOC Settlement</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_debtor_as_at.aspx"
                                        TabIndex="9">Debtor As AT</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_directdebit_dishonoured.aspx"
                                        TabIndex="10">DDs Dishonoured</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton9" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_repayment_due.aspx"
                                        TabIndex="11">Repayments Due</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton10" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_repayment_rcvd.aspx"
                                        TabIndex="12">Repayments Received</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_repayment_waived.aspx"
                                        TabIndex="13">Repayments Waived</asp:LinkButton>
                                </td>
                            </tr>
                            <tr >
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton12" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_interbranch_collection.aspx"
                                        TabIndex="14">Inter-branch Collection</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton13" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_default_letters.aspx"
                                        TabIndex="15">Default Letters</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton14" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_lapse_term_period.aspx"
                                        TabIndex="16">Lapse of Term Period</asp:LinkButton>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton15" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_debt_recovery.aspx"
                                        TabIndex="17">Bad Debt</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr" >
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton16" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_loan_decline.aspx"
                                        TabIndex="17">Loan Decline</asp:LinkButton>
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
       
                                                 <br />
                                                 <br />
                                                
                                             </td>
                                          </tr>
                                                    
                                         </table>
                                          </div>
                                          </asp:Panel>  
                                          
                                         </td>
                                        </tr>
                                        <tr>
                              
                               
                                <td colspan="3" style="text-align:center;">
                                  
                                   
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