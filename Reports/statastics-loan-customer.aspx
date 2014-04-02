﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="statastics-loan-customer.aspx.vb"
    Inherits="Reports_statastics_loan_customer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/Reporttab_Statistics.ascx" TagName="Toolbaar_Repsta" TagPrefix="tool_repsta" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Loan & Customer Statastics Report</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../css/menu.css" />
    <script language="javascript" type="text/javascript">
        function showDate(sender, args) {
            if (sender._textbox.get_element().value == "") {
                var todayDate = new Date();
                sender._selectedDate = todayDate;
            }
        }
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
        .style4
        {
            height: 66px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="align">
        <%--<tool1:Toolbaar1 ID="tool1" runat="server" />--%>
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
                        <asp:LinkButton ID="Link_Reports" CssClass="toolbaar1_link" runat="server"  PostBackUrl="~/Customer/Financial_Reports.aspx"
                            TabIndex="4">Reports</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" 
                                ForeColor="#2E95C9"  PostBackUrl="~/Customer/Marketing_Report.aspx"
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
        <asp:Panel ID="Panel1" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                    <li >
                         <asp:LinkButton ID="Link_Marketing" runat="server"  PostBackUrl="~/Customer/Marketing_Report.aspx" TabIndex="1">Marketing Reports</asp:LinkButton>
                                              
                    </li>
                    <li>
                      <asp:LinkButton ID="Link_Statistics" runat="server"  PostBackUrl="~/Customer/Statistics_Report.aspx"
                                    TabIndex="2" Font-Bold="True" ForeColor="#2E95C9">Statistics Reports</asp:LinkButton>
                       
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
                                     <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Grp_search.aspx"
                                TabIndex="1">Group Search</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="Link_cust_analysis" runat="server" CssClass="toolbaar1_link"
                                PostBackUrl="~/Customer/Cust_Analysis.aspx" TabIndex="2">Customer Analysis</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                     <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Loan_Status.aspx"
                                TabIndex="3">Loans Status</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                      <asp:LinkButton ID="LinkButton5" runat="server" CssClass="toolbaar1_link_active"   PostBackUrl="~/Reports/statastics-loan-customer.aspx"
                                TabIndex="4">Customers & Loans</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr"  >
                                <td class="toolbaar1_td_rep">
                                      <asp:LinkButton ID="LinkButton6" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/statastics-customer-joined.aspx"
                                TabIndex="5">Customers Joined On</asp:LinkButton>
                                    
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    &nbsp;
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
        <table align="left" class="w100">
                         <tr>
                                <td>
                                                 <div style="text-align: left">
                                   &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                            height="10" /> 
                                             <asp:Label ID="label5" runat="server" CssClass="label_style">Please enter amount from</asp:Label>
                                              &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="txtFromAmount" 
                                                runat="server" CssClass="align-center" Style="width: 100px" Width="80px"></asp:TextBox><asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromAmount" 
                                                Display="None" ErrorMessage="Please enter from amount" ValidationGroup="rptcl"></asp:RequiredFieldValidator><asp:RangeValidator 
                                                ID="RangeValidator1" runat="server" ControlToValidate="txtFromAmount" 
                                                Display="None" ErrorMessage="Please enter valid from amount" 
                                                MaximumValue="9999" MinimumValue="1" Type="Double" ValidationGroup="rptcl"></asp:RangeValidator><br /><br />
                                                &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                            height="10" /> 
                                             <asp:Label ID="label6" runat="server" CssClass="label_style">Please enter amount to</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                              <asp:TextBox ID="txtToAmount" runat="server" CssClass="align-center" 
                                                Style="width: 100px" Width="80px"></asp:TextBox> 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="txtToAmount" Display="None" 
                                                ErrorMessage="Please enter to amount" ValidationGroup="rptcl"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                ControlToValidate="txtToAmount" Display="None" 
                                                ErrorMessage="Please enter valid to amount" MaximumValue="9999" 
                                                MinimumValue="1" Type="Double" ValidationGroup="rptcl"></asp:RangeValidator>
                                        <br /><br />
                                        &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                            height="10" />
                                        <asp:Label ID="label7" runat="server" CssClass="label_style">Please enter a beginning date:</asp:Label>
                                        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                            EnableScriptLocalization="true" ID="ToolkitScriptManager1" />
                                        <asp:TextBox ID="txtfrom_loanstatus" runat="server" CssClass="align-center" Style="width: 100px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom_loanstatus"
                                            Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                                        </ajaxToolkit:CalendarExtender>
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;<img alt="Select Date" src="../Images/White_Right_Arrow.gif" width="10"
                                            height="10" />
                                        <asp:Label ID="label8" runat="server" CssClass="label_style">Please enter an ending date:</asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtto_loanstatus" runat="server" CssClass="align-center" Style="width: 100px"> </asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtto_loanstatus"
                                Format="dd-MMM-yyyy"  FirstDayOfWeek="Sunday" OnClientShowing="showDate">
                            </ajaxToolkit:CalendarExtender>
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="rptcl" />                                         
                                        <br />
                                        <asp:Button ID="btnReport" runat="server" Text="Create Customers & Loans Statistics Report" CssClass="btn_letter" ValidationGroup="rptcl" />
                                       
                                        <br />
                                        <br />
                                        <br />
                                       
                                         <asp:Panel ID="pnlPrint" runat="server">
                                          Customers & Loans Borrowed - Statastics Report for the period   <asp:Label ID="lblHead" runat="server" Text=""></asp:Label>
                                            <br /><br />
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </asp:Panel>
                                        <br /><br />
                                        <asp:Button ID="btnPrint" runat="server" Text="View & Print" Visible="False" />
                                         <br /><br />
                                        <asp:Panel ID="Panel2" runat="server" >
                                         Customers & Loans Borrowed - Statastics Report for the period   <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br /><br />
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                        </asp:Panel>
                                         <br /><br />
                                            <asp:Button ID="Button1" runat="server" Text="Download &amp; Save" 
                                            Visible="False" />
                                        &nbsp;<asp:Button ID="btnPrint1" runat="server" Text="View & Print" Visible="False" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                            <td>
                            &nbsp;
                            </td>
                            </tr>
                            
                           
                            <tr>
                            <td>
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
