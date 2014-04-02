<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Payment_Collection.aspx.vb"
    Inherits="Customer_Payment_Collection" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/tool_bank.ascx" TagName="Toolbaar_Bank" TagPrefix="tool_bank" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Collection</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <link rel="stylesheet" type="text/css" href="../css/menu.css" />
    <script type="text/javascript" language="javascript">
        function ConfirmSubmit() {
            Page_ClientValidate();
            if (Page_IsValid) {
                return confirm('      Click OK to SAVE');
            }
            return Page_IsValid;
        }
    </script>

    <style type="text/css">
        p.MsoNormal
        {
            mso-style-parent: "";
            margin-bottom: .0001pt;
            font-size: 12.0pt;
            font-family: "Times New Roman";
            margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
        h1
        {
            margin-top: 12.0pt;
            margin-right: 0cm;
            margin-bottom: 0cm;
            margin-left: 35.45pt;
            margin-bottom: .0001pt;
            text-indent: -35.45pt;
            font-size: 10.0pt;
            font-family: Helvetica-Narrow;
            font-weight: normal;
        }
        table.MsoNormalTable
        {
            mso-style-parent: "";
            font-size: 10.0pt;
            font-family: "Times New Roman";
        }
        div.Section1
        {
            page: Section1;
        }
        span.GramE
        {
        }
    </style>
    
    <style type="text/css">
        #form1
        {
            margin-left: 80px;
        }
        .style1
        {
                      
            padding-left:23px;
           
            border:1px solid gray;
            vertical-align :top;            
           
        }
        .style3
        {
            width: 163px;
        }
        .style4
        {
            height: 30px;
        }
    </style>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="align">
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
           <%-- <tool_bank:Toolbaar_Bank ID="t_bank" runat="server" />--%>
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
                            <asp:LinkButton ID="Link_Payroll" runat="server"  TabIndex="7" 
                        PostBackUrl="~/Customer/SalaryDeductions.aspx">Payroll File</asp:LinkButton>
                        </li>
                    
                        <li>
                            <asp:LinkButton ID="lbPaymentCollection" runat="server" Font-Bold="True" ForeColor="#2E95C9"
                        TabIndex="8" PostBackUrl="~/Customer/Payment_Collection.aspx">Payment Collection</asp:LinkButton>
                        </li>
                            
                        </ul>
                    </td>
                    
                </tr>
            </table>
           
            <table cellspacing="0" cellpadding="0" width="98%"  >
            <tr>
           
            <td style="border:1px solid gray; width:82%;vertical-align :top">
            <div align="left">
            <br />
                    <table align="left" class="w100">
                               
                               <tr>
                                    <td colspan="3" class="rptHead" valign="top" >
                                       <b>Payment Collection</b> 
                                    </td>
                                    </tr>    
                                    <tr>
                                        <td style="width:200px; padding-bottom:20px;">
                                           <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="label3" runat="server" CssClass="label_style">Customer ID:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerID" runat="server" Width="100px" Style=" margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvCustID" runat="server" ControlToValidate="txtCustomerID"
                                                Display="None" ErrorMessage="Please enter a valid ID" SetFocusOnError="True"
                                                ValidationGroup="pc">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td > 
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="width:200px; padding-bottom:20px;">
                                            <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="label4" runat="server" CssClass="label_style" >Customer Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="50" Width="175px" Style=" margin-bottom:20px;" CssClass="align-center_teller"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvCustName" runat="server" ControlToValidate="txtCustomerName"
                                                Display="None" ErrorMessage="Please enter a customer name" SetFocusOnError="True"
                                                ValidationGroup="pc">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                        
                                    </tr>
                                     <tr>
                                        <td>
                                           <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="label1" runat="server" CssClass="label_style">Amount:</asp:Label>
                                        </td>
                                        <td>
                                                <asp:TextBox ID="txtInterAmount" runat="server" Width="60px" CssClass="align-center_teller"></asp:TextBox>$<asp:RequiredFieldValidator
                                            ID="rvAmount" runat="server" ControlToValidate="txtInterAmount" Display="None"
                                            ErrorMessage="Please enter a valid amount" SetFocusOnError="True" ValidationGroup="pc">*</asp:RequiredFieldValidator><asp:RangeValidator
                                                ID="RangeValidator1" runat="server" ControlToValidate="txtInterAmount" Display="None"
                                                ErrorMessage="Please enter a valid amount" MaximumValue="9999" MinimumValue="1"
                                                Type="Double" ValidationGroup="pc">*</asp:RangeValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                           <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="label2" runat="server" CssClass="label_style">This customer belongs to:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpBranch" runat="server" CssClass="droplist_paymentcollection">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvBranch" runat="server" ControlToValidate="drpBranch"
                                                Display="None" ErrorMessage="Please select the branch name" InitialValue="" SetFocusOnError="True"
                                                ValidationGroup="pc">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td style="width:200px; padding-bottom:20px;">
                                           <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="label5" runat="server" CssClass="label_style">Purpose of payment:</asp:Label>
                                        </td>
                                        <td class="style4">
                                                <asp:DropDownList ID="drpPurpose" runat="server" CssClass="droplist_paymentPurpose">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                                <asp:ListItem Value="Loan Repayment">Loan Repayment</asp:ListItem>
                                                <asp:ListItem Value="Debt Recovery">Debt Recovery</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvBranch0" runat="server" ControlToValidate="drpPurpose"
                                                Display="None" ErrorMessage="Please select the purpose of payment" InitialValue=""
                                                SetFocusOnError="True" ValidationGroup="pc">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="style4"></td>
                                    </tr>
                                     <tr>
                                        <td class="style4">
                                           <img src="../Images/White_Right_Arrow.GIF" alt="" />
                                            <asp:Label ID="lblTeller" runat="server"  CssClass="label_style">Teller:</asp:Label>
                                        </td>
                                        <td class="style4">
                                                  <asp:DropDownList ID="ddlTeller" runat="server">
                                                      <asp:ListItem Value="0" Text="--Select--" />
                                                      <asp:ListItem Value="1" Text="Teller 1" />
                                                      <asp:ListItem Value="2" Text="Teller 2" />
                                                      <asp:ListItem Value="3" Text="Teller 2" />
                                                      <asp:ListItem Value="4" Text="Teller 4" />
                                                     </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="rvTeller" runat="server" 
                                                         ControlToValidate="ddlTeller" ErrorMessage="Please select Teller No." 
                                                         Display="None" ValidationGroup="pc" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="style4"></td>
                                    </tr>
                                     <tr>
                                            <td></td>
                                            <td>
                                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="pc" />
                                            </td>
                                            <td>
                                                
                                            </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" ValidationGroup="pc"
                                        Width="100px" OnClientClick="javascript:return ConfirmSubmit()" />
                                            
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr >
                                        <td colspan="3" style="height: 25px;">
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" valign="top">
                                             <br />
                                                    <asp:Panel runat="server" ID="pnlprnt">
                                                        <table class="table" cellpadding="0" cellspacing="0" border="0" runat="server" id="tblPrint"
                                                            align="center">
                                                            <tr>
                                                                <td>
                                                                    <table border="1" width="575" height="315" style="border-collapse: collapse; margin-left: .3in"
                                                                        bordercolor="#111111" cellpadding="0" cellspacing="0" bordercolorlight="#FFFFFF"
                                                                        bordercolordark="#FFFFFF">
                                                                        <tr>
                                                                            <td valign="top" style="width: 706; border: 1.0pt solid #FFFFFF; padding-left: 5.4pt;
                                                                                padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in">
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    <b><span style="font-size: 16.0pt; color: black">Payment Collection Receipt</span></b></p>
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal" align="center" style="text-align: center">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal">
                                                                                    <img border="0" src="../Images/MPNoticeLogo.jpg" alt="Money Plus"></p>
                                                                                <p class="MsoNormal" style="text-align: right">
                                                                                    Abaz Pty Ltd A.C.N 118 434 021
                                                                               <br />
                                                                                    c/-
                                                                                    <asp:Label ID="lblTradingName" runat="server"></asp:Label>
                                                                                    <br />
                                                                                     <asp:Label ID="lblStreetNo" runat="server"></asp:Label>
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblStreetName" runat="server"></asp:Label>, &nbsp;<asp:Label ID="lblSuburb"
                                                                                        runat="server"></asp:Label>,
                                                                                    <asp:Label ID="lblState" runat="server"></asp:Label>
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblPostCode" runat="server"></asp:Label>
                                                                                    <br />
                                                                                     Tel:
                                                                                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
                                                                                    </p>
                                                                                <%--<p class="MsoNormal" style="text-align: right">
                                                                                   </p>
                                                                                <p class="MsoNormal" style="text-align: right">
                                                                                   </p>--%>
                                                                                <p class="MsoNormal">
                                                                                    <b>Date:</b>&nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label></p>
                                                                                <p class="MsoNormal" style="text-align: Left">
                                                                                    &nbsp;</p>
                                                                                <%--<p class="MsoNormal" style="text-align:Left">&nbsp;</P>
			                                        <p class="MsoNormal" style="text-align:Left">&nbsp;</P>
			                                        <p class="MsoNormal" style="text-align:Left">&nbsp;</P>
			                                        <p class="MsoNormal" style="text-align:Left">&nbsp;</P>--%>
                                                                                <p class="MsoNormal" style="text-align: left">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Customer No:</b>
                                                                                    <asp:Label ID="lblCustNo" runat="server"></asp:Label>
                                                                                </p>
                                                                                <%--<p class="MsoNormal" style="text-align:left">&nbsp;</P>--%>
                                                                                <p class="MsoNormal" style="text-align: Left">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Customer Name:</b>
                                                                                    <asp:Label ID="lblCustName" runat="server"></asp:Label></p>
                                                                                <%--<p class="MsoNormal" style="text-align: left">&nbsp;</p>--%>
                                                                                <p class="MsoNormal" style="text-align: left">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Account belongs to:</b>
                                                                                    <asp:Label ID="lblBranchName" runat="server"></asp:Label></p>
                                                                                <%--<p class="MsoNormal">&nbsp;</p>--%>
                                                                                <p class="MsoNormal">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Purpose of payment:</b>
                                                                                    <asp:Label ID="lblPurpose" runat="server"></asp:Label></p>
                                                                                <%--<p class="MsoNormal">--%>
                                                                                <p class="MsoNormal">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Total Amount: </b>
                                                                                    <asp:Label ID="lblAmount" runat="server"></asp:Label></p>
                                                                                <%-- <p class="MsoNormal">&nbsp;<p class="MsoNormal">&nbsp;<p class="MsoNormal">--%>
                                                                                <p class="MsoNormal">
                                                                                    &nbsp;</p>
                                                                                <p class="MsoNormal">
                                                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        Payment received by: </b>
                                                                                ..........................................</p>
                                                                                <p class="MsoNormal">
                                                                                    &nbsp;</p>
                                                                                    <p class="MsoNormal">
                                                                                    &nbsp;</p>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top" style="width: 706; border: 1.0pt solid #FFFFFF; padding-left: 5.4pt;
                                                                                padding-right: 5.4pt; padding-top: 0in; padding-bottom: 0in">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
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
                                                                  <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print Receipt" />
                                                                     &nbsp;&nbsp; <asp:Button ID="btnBack" runat="server" Text="Back" />
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
