<%@ Page Language="VB" AutoEventWireup="false" CodeFile="report_journal.aspx.vb" Inherits="Reports_report_journal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register src="~/toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Financial Status</title>
    
       <link rel="stylesheet" type="text/css" href="../css/style.css" />
      <link rel="stylesheet" type="text/css" href="../css/menu.css" />
    <script language="JavaScript" type="text/javascript">
        javascript: window.history.forward(1);
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
           /*width: 163px;*/
            width: 203px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <div>
           <%-- <tool1:Toolbaar1 ID="tool_first" runat="server" />--%>
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
        
        <asp:Panel ID="Panel2" runat="server">
    <table id="toolbarMarketing_table" cellspacing="0" class="toolbartellareport_table" 
        cellpadding="0">
        <tr>
            <td align="left">
                <ul id="navbarMarketing">
                    <li>
                    
                        <asp:LinkButton ID="Link_Financial" runat="server"  TabIndex="1" PostBackUrl="~/Customer/Financial_Reports.aspx">Financial Reports</asp:LinkButton>
                        
                    </li>
                    <li>
                    
                      <asp:LinkButton ID="Link_Periodic" runat="server" TabIndex="2" Font-Bold="True" 
                            ForeColor="#2E95C9" PostBackUrl="~/Customer/Periodic_Reports.aspx">Periodic Reports</asp:LinkButton>
                       
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
                                   <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="toolbaar1_link_active" PostBackUrl="~/Reports/report_journal.aspx"
                            TabIndex="1">Financial Status</asp:LinkButton>
                                </td>
                            </tr>
                           <%-- <tr >
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_cashed.aspx"
                                        TabIndex="4">Cheque Cashed</asp:LinkButton>
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_cheque_dishonoured.aspx"
                                        TabIndex="6">Dishonoured Cheques</asp:LinkButton>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Perodic_Report.aspx"
                            TabIndex="2">Periodic Report</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr"  style="display:none;">
                                            <td class="toolbaar1_td_rep">
                                                <asp:LinkButton ID="LinkButtonMonthlyReport" runat="server"  CssClass="toolbaar1_link"
                                                    PostBackUrl="~/Reports/FinancialMonthlyReport.aspx" TabIndex="3">Financial Monthly Report</asp:LinkButton>
                                            </td>
                                        </tr>
                                       
                           <tr class="toolbaar1_tr" visible="false">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="lbLoginReport" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                                        TabIndex="2">Login Report</asp:LinkButton>
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
                        <td colspan="3" class="rptHead" valign="top">
                           <b>Financial Status Report</b>
                        </td>
                        </tr>
                        <tr>
                            <td style="width:250px; padding-bottom:20px;">
                                <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                <asp:Label ID="label1" runat="server" CssClass="label_style">Please enter a beginning date:</asp:Label>
                            </td>
                            <td>
                               <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                    EnableScriptLocalization="true" ID="ScriptManager1" />
                                <asp:TextBox ID="txtFrmDate" runat="server" Style="width: 100px  ; margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDate"
                                    Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFrmDate"
                                    Display="None" ErrorMessage="Report beginning date Required" ValidationGroup="rpt"></asp:RequiredFieldValidator>
                            </td>
                            <td rowspan="2" valign="middle">
                               
                                <label>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="rpt" />
                                </label>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                <asp:Label ID="label_1" runat="server" CssClass="label_style">Please enter an ending date:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" Style="width: 100px" CssClass="align-center_teller"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                    Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                                    Display="None" ErrorMessage="Report Date Required" ValidationGroup="rpt"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button runat="server" ID="btnReport" 
                                    Text="Create Financial Status Report" ValidationGroup="rpt"
                                    CssClass="btn" />
                            </td>
                            <td></td>
                        </tr>
                        <tr >
                            <td colspan="3" style="height: 25px;">
                            
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                               <asp:Panel ID="pnlPrint" runat="server" Width="950px">
                                    <div id="PrintDiv" class="printable" style="width: 100%">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                   Financial Status from <asp:Label ID="lblHead" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center;">
                                                                  <asp:Button ID="btnDownLoad" runat="server" Text="Download & Save" Visible="false" />
                                                                
                                                                &nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:Button ID="btnPrint" runat="server" Text="View & Print" />&nbsp&nbsp&nbsp&nbsp
                                <br />
                                <br />
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
