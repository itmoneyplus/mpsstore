<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Tellers_Report.aspx.vb"
    Inherits="Reports_Tellers_Report" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register src="../toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>
<%--<%@ Register Src="~/toolbaar/ReportControl.ascx" TagName="Toolbaar_Rep1" TagPrefix="tool_rep1" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tellers Report</title>
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
            width: 163px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
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
                            <li>
                                <asp:LinkButton ID="Link_Financial" runat="server" TabIndex="1" PostBackUrl="~/Customer/Financial_Reports.aspx"
                                    Font-Bold="True" ForeColor="#2E95C9">Financial Reports</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="Link_Periodic" runat="server" TabIndex="2" PostBackUrl="~/Customer/Periodic_Reports.aspx">Periodic Reports</asp:LinkButton>
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
                                         <tr class="toolbaar1_tr">
                                                <td class="toolbaar1_td_rep">
                                                    <asp:LinkButton ID="Link_teller" runat="server" CssClass="toolbaar1_link_active" PostBackUrl="~/Reports/Tellers_Report.aspx"
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
                    <td style="border: 1px solid gray; width: 82%; vertical-align: top">
                        <div align="left">
                            <br />
                            <table align="left" class="w100">
                                <tr>
                                    <td style="width: 250px;">
                                        <img alt="" src="../Images/White_Right_Arrow.GIF" />
                                        <asp:Label ID="label_1" runat="server" CssClass="label_style">Please select the teller number:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="drpTeller" CssClass="droplist_teller" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                        <asp:Label ID="label1" runat="server" CssClass="label_style">Please enter report date:</asp:Label>
                                    </td>
                                    <td>
                                               <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                            EnableScriptLocalization="true" ID="ScriptManager1" />
                                        <asp:TextBox ID="txtRepDate" runat="server" Style="width: 100px" CssClass="align-center_teller"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRepDate"
                                            Format="dd-MMM-yyyy" FirstDayOfWeek="Sunday"  OnClientShowing="showDate">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRepDate"
                                            Display="None" ErrorMessage="Report Date Required" ValidationGroup="rpt"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <label>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="rpt" />
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnReport" Text="Create Teller Report" ValidationGroup="rpt"
                                    CssClass="btn" />
                                        
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:Panel ID="pnlPrint" runat="server" Width="750px">
                                            <div id="PrintDiv" class="printable" style="width: 100%">
                                                
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblHead" runat="server" ></asp:Label>
                                            </td>
                                            </tr>
                                                <tr>
                                                    <td>
                                                        <table width="400px" cellpadding="0" cellspacing="0" align="right" class="tbl-tr-inner">
                                                            <tr>
                                                                <td style="width: 70%">
                                                                    <b><u><span>Till Opening Balance:</span></u></b>
                                                                </td>
                                                                <td style="width: 30%; text-align: right;">
                                                                    <b><u>
                                                                        <asp:Label ID="lblOB" runat="server" Text=""></asp:Label></u></b>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="frmSafeAbaztr" visible="false">
                                                                <td>
                                                                   <span> Total Cash Brought From Safe -&nbsp; <b>Abaz</b></span>&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblfrmSafeAbaz"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="frmSafeMplustr" visible="false">
                                                                <td>
                                                                   <span> Total Cash Brought From Safe - <b>M/Plus</b></span>&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblfrmSafeMplus"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="RepaymentTr" visible="false">
                                                                <td>
                                                                   <span> Loan / Loc Repayments - Cash In</span>&nbsp;&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblRepayment"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="PaymentCollectionTr" visible="false">
                                                                <td>
                                                                   <span> Payment Collection - Cash In&nbsp;</span>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblPaymentCollection"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <u><b><span>Total Cash In</span></b></u>&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <b><u>
                                                                        <asp:Label runat="server" ID="lblTotalCashIn"></asp:Label></u></b>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="ToSafeAbazTr" visible="false">
                                                                <td>
                                                                    <span>Total Cash Returned To Safe <b>- Abaz</b>&nbsp;</span>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblToSafeAbaz"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="ToSafeMplusTr" visible="false">
                                                                <td>
                                                                   <span> Total Cash Returned To Safe <b>- M/Plus</b></span>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblToSafeMplus"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="loanlocdrdwnCashoutTr" visible="false">
                                                                <td>
                                                                    <span>Loan / LOC / Drawdown - Cash Out</span>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblloanlocdrdwnCashout"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr visible="false" runat="server" id="MoneyGramSentTR">
                                                                <td>
                                                                    <span>Money Gram - Cash Out</span>
                                                                </td>
                                                                <td align="right">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" visible="false" id="ChequeCashedTR">
                                                                <td>
                                                                   <span> Cheque Cashed - Cash</span>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label runat="server" ID="lblChequeCashed"></asp:Label>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <u><b><span>Total Cash Out</span></b></u>&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <u>&nbsp;<b><asp:Label runat="server" ID="lblTotalCashout"></asp:Label></b></u></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <u><b><span>Till Closing balance</span></b></u>&nbsp;
                                                                </td>
                                                                <td align="right">
                                                                    <u>&nbsp;<b><asp:Label runat="server" ID="lblClosingBalance"></asp:Label></b></u></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                               <%-- <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="right" class="tdborder">
                                                        <asp:GridView ID="gvLoc" runat="server" AutoGenerateColumns="False" CssClass="gvreport"
                                                            GridLines="None" ShowFooter="True" ShowHeader="true" >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="LOC" ItemStyle-Width="400" HeaderStyle-Width="400px"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# Session("branch_prefix") %>
                                                                        &nbsp;
                                                                        <%# Eval("Customer_ID") %>
                                                                        &nbsp;
                                                                        <%#Eval("Given_Name")%>
                                                                        &nbsp;
                                                                        <%#Eval("Last_Name")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b><u>Subtotal</u></b>
                                                                    </FooterTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="New" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustID" runat="server" Text='<%# Eval("Customer_ID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblCustNew" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustNewTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Exist" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustExist" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustExistTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fee" ItemStyle-Width="115px" HeaderStyle-Width="115px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFee" runat="server" Text='<%# Eval("Total_Fee" , "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblFeeTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cash Out" ItemStyle-Width="115" HeaderStyle-Width="115"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount",  "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblAmountTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td class="tdborder" align="right">
                                                   <asp:GridView ID="gvPmtCol" runat="server" AutoGenerateColumns="False" CssClass="gvreport"
                                                            GridLines="None" ShowFooter="True" ShowHeader="true"  FooterStyle-Font-Bold="true"
                                                            FooterStyle-Font-Underline="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Payment Collection:" ItemStyle-Width="300" HeaderStyle-Width="400px"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# Session("branch_prefix") %>
                                                                        &nbsp;
                                                                        <%# Eval("Customer_ID") %>
                                                                        &nbsp;
                                                                        <%#Eval("Customer_Name")%>
                                                                        &nbsp;
                                                                      
                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="5" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5px"
                                                                    FooterStyle-Width="5px" HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                      
                                                                     &nbsp;
                                                                      </ItemTemplate>
                                                                    <FooterTemplate>
                                                                       
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px" HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                       &nbsp;
                                                                       </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Branch Name" ItemStyle-Width="170px" HeaderStyle-Width="170px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                     <%#Eval("Branch_Name")%>
                                                                       
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <b><u>Subtotal</u></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cash In" ItemStyle-Width="115" HeaderStyle-Width="115"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount",  "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblAmountTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Staff" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStaff" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Time" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLoanTime" runat="server" Text='<%# Eval("Time_Collect", "{0:t}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                </td>
                                                </tr>
                                                <tr>
                                                <td>
                                                &nbsp;
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="tdborder">
                                                        <asp:GridView ID="gvLoan" runat="server" AutoGenerateColumns="False" CssClass="gvreport"
                                                            GridLines="None" ShowFooter="True" ShowHeader="true"  FooterStyle-Font-Bold="true"
                                                            FooterStyle-Font-Underline="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Loan" ItemStyle-Width="300" HeaderStyle-Width="400px"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# Session("branch_prefix") %>
                                                                        &nbsp;
                                                                        <%# Eval("Customer_ID") %>
                                                                        &nbsp;
                                                                        <%#Eval("Given_Name")%>
                                                                        &nbsp;
                                                                        <%#Eval("Last_Name")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b><u>Subtotal</u></b>
                                                                    </FooterTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="New" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustID" runat="server" Text='<%# Eval("Customer_ID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblCustNew" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustNewTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Exist" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustExist" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustExistTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fee" ItemStyle-Width="115px" HeaderStyle-Width="115px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFee" runat="server" Text='<%# Eval("Total_Fee" , "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblFeeTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cash Out" ItemStyle-Width="115" HeaderStyle-Width="115"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount",  "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblAmountTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Staff" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStaff" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Time" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLoanTime" runat="server" Text='<%# Eval("Loan_Time", "{0:t}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="tdborder">
                                                        <asp:GridView ID="gvLoanRepay" runat="server" AutoGenerateColumns="False" CssClass="gvreport"
                                                            GridLines="None" ShowFooter="True" ShowHeader="true" FooterStyle-Font-Bold="true"
                                                            FooterStyle-Font-Underline="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Loan Repayments from:" ItemStyle-Width="300" HeaderStyle-Width="400px"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# Session("branch_prefix") %>
                                                                        &nbsp;
                                                                        <%# Eval("Customer_ID") %>
                                                                        &nbsp;
                                                                        <%#Eval("Given_Name")%>
                                                                        &nbsp;
                                                                        <%#Eval("Last_Name")%>
                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px" HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustID" runat="server" Text='<%# Eval("Customer_ID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblCustNew" runat="server" Visible="false"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustNewTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px" HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustExist" runat="server" Visible="false"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustExistTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="115px" HeaderStyle-Width="115px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-Font-Underline="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFee" runat="server" Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <b><u>Subtotal</u></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cash In" ItemStyle-Width="115" HeaderStyle-Width="115"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount",  "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblAmountTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Staff" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStaff" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Time" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLoanTime" runat="server" Text='<%# Eval("Transaction_Time", "{0:t}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                <td align="right" class="tdborder">
                                                <asp:GridView ID="gvChequeCash" runat="server" AutoGenerateColumns="False" CssClass="gvreport"
                                                            GridLines="None" ShowFooter="True" ShowHeader="true"  FooterStyle-Font-Bold="true"
                                                            FooterStyle-Font-Underline="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Cheque Cashed by:" ItemStyle-Width="300" HeaderStyle-Width="300px"
                                                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# Session("branch_prefix") %>
                                                                        &nbsp;
                                                                        <%# Eval("Customer_ID") %>
                                                                        &nbsp;
                                                                        <%#Eval("Given_Name")%>
                                                                        &nbsp;
                                                                        <%#Eval("Last_Name")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b><u>Subtotal</u></b>
                                                                    </FooterTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="New" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustID" runat="server" Text='<%# Eval("Customer_ID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblCustNew" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustNewTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Exist" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                                                    FooterStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustExist" runat="server"></asp:Label></ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCustExistTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cheque Amount" ItemStyle-Width="150px" HeaderStyle-Width="150px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChqAmt" runat="server" Text='<%# Eval("Cheque_Amount" , "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblChqTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Fee" ItemStyle-Width="115px" HeaderStyle-Width="115px"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFee" runat="server" Text='<%# Eval("Cheque_Fee" , "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblFeeTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cash Out" ItemStyle-Width="115" HeaderStyle-Width="115"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Pay_Cash_Now",  "{0:c}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblAmountTotal" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Staff" ItemStyle-Width="100" HeaderStyle-Width="100"
                                                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStaff" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                            </Columns>
                                                        </asp:GridView>
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                                                        <tr>
                                                        
                                                        <td align="left" valign="bottom" style="padding-left:15px">
                                                       <span> Balanced By:&nbsp;</span><asp:Label ID="lblLoginName" runat="server" ></asp:Label><br /><br />
                                                        <span>Staff Signature:&nbsp;</span>.............................................<br /><br />
                                                        <span>Check by Branch Manager:</span>&nbsp;.....................................
                                                        </td>
                                                        
                                                        <td valign="top" align="right" width="300px">
                                                        <table cellpadding="0" cellspacing="0" border="0" align="right" width="300px">
                                                           <tr>
                                                           <td align="left" style="padding-top:10px;">
                                                           <b><span>Till Count Calculator</span></b>
                                                           </td>
                                                           </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:GridView ID="gvTillCount" runat="server" AutoGenerateColumns="False" ShowFooter="false"
                                                                        ShowHeader="false" CssClass="gvreport" GridLines="Both" Width="300px" 
                                                                        CellPadding="3" CellSpacing="3">
                                                                        <Columns>
                                                                           
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" >
                                                                            <ItemTemplate>
                                                                            <label style='color:<%#Eval("Colour")%>;' ><%#Eval("Amount")%></label>
                                                                            </ItemTemplate>

        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtValue" runat="server" Width="60px" CssClass="txtpont"></asp:TextBox>
                                                                                   <%-- <asp:TextBox ID="lblAmtVal" runat="server" Text='<%# Eval("AmountValue") %>' CssClass="txtamt" style="display:none;" ></asp:TextBox>--%>
                                                                                   <asp:HiddenField  runat="server" Value='<%# Eval("AmountValue") %>' ID="lblAmtVal"  />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                               
                                                                               <asp:TemplateField ItemStyle-HorizontalAlign="right" ItemStyle-Width="100px">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblValue" runat="server" CssClass="lbltotal"></asp:Label>
                                                                                </ItemTemplate>

        <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            </table>
                                                        
                                                        </td>
                                                        </tr>
                                                        
                                                        
                                                        </table>
                                                        
                                                        
                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="300px">
                                                                        <tr>
                                                                            <td style="width: 200px; text-align: right; padding-right: 5px; font-weight: bold;">
                                                                                Total</td>
                                                                            <td style="width: 100px; text-align: right; padding-right: 5px; font-weight: bold;">
                                                                                <asp:Label ID="lblTillTotal" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 200px; text-align: right; padding-right: 5px; font-weight: bold; color:Red;">
                                                                                Balance </td>
                                                                            <td style="width: 100px; text-align: right; padding-right: 5px; font-weight: bold;">
                                                                                <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                  </div>
                                                  </asp:Panel>
                                                  
                                                  
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: center;">
                                        <br /><br />
                                        <asp:Button ID="btnDownload" runat="server" Text="Dowanload & Save" />&nbsp&nbsp&nbsp&nbsp&nbsp
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
<script type="text/javascript" src="../scripts/jquery.js"></script>

<script type="text/javascript">
    $(document).ready(function() {
        gridloop();
        //  alert("hi");
        $("#<%=gvTillCount.ClientID %> tr").each(function() {
            $(this).find('.txtpont')
         .each(function(col) {
             $(this).blur(function(event) {
                 gridloop();
             });

         });

        });

        function gridloop() {
            var PointTotal = 0;
            $('#<%=gvTillCount.ClientID%>')
     .find('tr')
     .each(function(row) {
         var txtval = 0;
         var txtamt = 0

         $(this).find('.txtpont')
                .each(function(col) {
                    txtval = Number($(this).val());

                });

         $(this).find(':hidden')
                .each(function(col) {
                    txtamt = Number($(this).val());
                });
         $(this).find('.lbltotal')
                .each(function(col) {
                    var t = Number(txtval * txtamt)
                    $(this).html("$" + parseFloat(t).toFixed(2));
                });

         PointTotal += Number(txtval * txtamt);
     });

            var tb = parseFloat(PointTotal).toFixed(2);
            $('#<%=lblTillTotal.ClientID%>').text("$" + parseFloat(tb).toFixed(2));

            var Cb = $('#<%=lblClosingBalance.ClientID%>').html();
            var bal = 0;
            Cb = Cb.replace('$', '');
            Cb = Cb.replace(',', '');
            tb = tb.replace(',', '');
            if (parseFloat(Cb) > parseFloat(tb)) {
                $('#<%=lblBalance.ClientID%>').css('color', 'red');
                bal =  Number(parseFloat(tb)) - Number(parseFloat(Cb));

            }
            else if (parseFloat(Cb) < parseFloat(tb)) {
                $('#<%=lblBalance.ClientID%>').css('color', 'green');
                bal = parseFloat(tb) - parseFloat(Cb)


            }
            else {
                $('#<%=lblBalance.ClientID%>').css('color', 'black');
                bal = 0.0;
            }
            // alert(bal);
            $('#<%=lblBalance.ClientID%>').text("$" + parseFloat(bal).toFixed(2));

        };
        $('.tdborder').each(function() {

            if (!$('td:not(:empty)', this).length)
                $(this).hide();

        });
        //
    });
    
</script>

</body>
</html>
