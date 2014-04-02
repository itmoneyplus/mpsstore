<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Reporttabs.ascx.vb" Inherits="Reports_MoneyPlus_Reporttabs" %>
<head>
    <title>tool_reptabs</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div id="toolbar">
    <table id="toolbar_table" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table id="Table1" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="Link_teller" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/Tellers_Report.aspx"
                    TabIndex="1">Teller</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table2" cellspacing="0" runat="server" >
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="2">Sales</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table4" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="4">Cheque Cashed</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table5" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="5">Cheque Customer</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table6" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="6">Dishonoured Cheques</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table7" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="7">Loan/LOC Debtor</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table8" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="8">Loan/LOC Settlement</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table9" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton7" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="9">Debtor As AT</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table10" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton8" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="10">DDs Dishonoured</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table11" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton9" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_reayment_due.aspx"
                    TabIndex="11">Repayments Due</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table12" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton10" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="12">Repayments Received</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table13" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="13">Repayments Waived</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table14" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton12" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="14">Inter-branch Collection</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table15" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton13" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="15">Default Letters</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table16" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton14" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="16">Lapse of Term Period</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table17" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="LinkButton15" runat="server" CssClass="toolbaar1_link" PostBackUrl=""
                    TabIndex="17">Bad Debit</asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
