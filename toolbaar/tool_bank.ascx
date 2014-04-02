<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool_bank.ascx.vb" Inherits="toolbaar_tool_bank" %>
<head>
    <title>tool_main</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div id="toolbar">
    <%--  <table id="toolbar_table" cellspacing="0" class="table_toolbaar_bank">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td">
              <asp:LinkButton ID="Link_Till" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Till.aspx"
                    TabIndex="1">Update Till</asp:LinkButton>
                <asp:Label ID="Label1" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_Safe" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Safe.aspx"
                    TabIndex="2">Update Safe</asp:LinkButton>
                <asp:Label ID="Label2" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_Movements" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="3">Cash Movements Report</asp:LinkButton>
                <asp:Label ID="Label3" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_NAB" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                    TabIndex="4">NAB Debit</asp:LinkButton>
                <asp:Label ID="Label4" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_CBA" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_CBA.aspx"
                    TabIndex="5">CBA Debit</asp:LinkButton>
                <asp:Label ID="Label5" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_Customer_Credit" runat="server" CssClass="toolbaar1_link"
                    TabIndex="6" PostBackUrl="~/Customer/Customer_Credit.aspx">Customer Credit</asp:LinkButton>
                <asp:Label ID="Label6" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_Payroll" runat="server" CssClass="toolbaar1_link" TabIndex="7"
                    PostBackUrl="~/Customer/SalaryDeductions.aspx">Payroll File</asp:LinkButton>
                <asp:Label ID="Label7" runat="server">|</asp:Label>
                <asp:LinkButton ID="lbPaymentCollection" runat="server" CssClass="toolbaar1_link"
                    TabIndex="8" PostBackUrl="~/Customer/Payment_Collection.aspx">Payment Collection</asp:LinkButton>
                <asp:Label ID="Label9" runat="server">|</asp:Label>
                <asp:LinkButton ID="Link_Credit" runat="server" CssClass="toolbaar1_link" TabIndex="9"
                    Enabled="false">Credit File</asp:LinkButton>
                <asp:Label ID="Label8" runat="server">|</asp:Label>
            </td>
        </tr>
    </table>--%>
    <ul id="menu1">
    <li>
      <asp:LinkButton ID="Link_Till" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Till.aspx"
                    TabIndex="1">Update Till</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_Safe" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Update_Safe.aspx"
                    TabIndex="2">Update Safe</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_Movements" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Cash_Movements_Reports.aspx"
                    TabIndex="3">Cash Movements Report</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_NAB" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_NAB.aspx"
                    TabIndex="4">NAB Debit</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_CBA" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Bank_File_CBA.aspx"
                    TabIndex="5">CBA Debit</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_Customer_Credit" runat="server" CssClass="toolbaar1_link"
                    TabIndex="6" PostBackUrl="~/Customer/Customer_Credit.aspx">Customer Credit</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="Link_Payroll" runat="server" CssClass="toolbaar1_link" TabIndex="7"
                    PostBackUrl="~/Customer/SalaryDeductions.aspx">Payroll File</asp:LinkButton></li>
                
                <li><asp:LinkButton ID="lbPaymentCollection" runat="server" CssClass="toolbaar1_link"
                    TabIndex="8" PostBackUrl="~/Customer/Payment_Collection.aspx">Payment Collection</asp:LinkButton></li>
                
              <%--  <li><asp:LinkButton ID="Link_Credit" runat="server" CssClass="toolbaar1_link" TabIndex="9"
                    Enabled="false">Credit File</asp:LinkButton></li>--%>
                
    </ul>
</div>
