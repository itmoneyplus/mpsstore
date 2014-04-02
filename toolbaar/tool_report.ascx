<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool_report.ascx.vb"
    Inherits="toolbaar_tool_report" %>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <table id="toolbar_table" cellspacing="0" class="table_toolbaar_rep">
                <tr class="toolbaar1_tr">
                    <td bgcolor="gray" >
                        <asp:LinkButton ID="Link_Financial" runat="server" CssClass="toolbaar1_link" TabIndex="1">Financial Reports</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server">|</asp:Label>&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="Link_Periodic" runat="server" CssClass="toolbaar1_link" TabIndex="2">Periodic Reports</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr runat="server" visible="false" id="trfin">
        <td>
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
                <tr runat="server" id="trreportAdmin" visible="true">
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" class="toolbar_table">
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="Link_sales" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_sales.aspx"
                                        TabIndex="2">Sales</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
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
                            <tr class="toolbaar1_tr">
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
                            <tr class="toolbaar1_tr">
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
                            <tr class="toolbaar1_tr">
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
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
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
                            <tr class="toolbaar1_tr">
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
                            <tr class="toolbaar1_tr">
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
                                        TabIndex="17">Bad Debit</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="toolbaar1_tr">
                                <td class="toolbaar1_td_rep">
                                    <asp:LinkButton ID="LinkButton16" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_loan_decline.aspx"
                                        TabIndex="17">Loan Decline</asp:LinkButton>
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
    </tr>
    <tr runat="server" visible="false" id="trPer">
        <td>
            <table border="0" cellpadding="0" cellspacing="0" class="toolbar_table">
                <tr class="toolbaar1_tr">
                    <td class="toolbaar1_td_rep">
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_journal.aspx"
                            TabIndex="1">Financial Status</asp:LinkButton>
                    </td>
                </tr>
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
                <tr class="toolbaar1_tr">
                    <td class="toolbaar1_td_rep">
                        <asp:LinkButton ID="lbLoginReport" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                            TabIndex="2">Login Report</asp:LinkButton>
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
