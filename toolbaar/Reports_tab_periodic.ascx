<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Reports_tab_periodic.ascx.vb"
    Inherits="toolbaar_Reports_tab_periodic" %>
<head>
    <title>tool_periodic</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div id="toolbar">
    <table cellspacing="0">
        <tr>
            <td>
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
                            <asp:LinkButton ID="Link_Financial" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Reports/report_journal.aspx"
                                TabIndex="1">Financial Status</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="Table2" cellspacing="0">
                    <tr class="toolbaar1_tr">
                        <td class="toolbaar1_td_rep">
                            <asp:LinkButton ID="Link_Periodic" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Perodic_Report.aspx"
                                TabIndex="2">Periodic Report</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="Table3" cellspacing="0">
                    <tr class="toolbaar1_tr">
                        <td class="toolbaar1_td_rep">
                            <asp:LinkButton ID="lbLoginReport" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/CreateUser.aspx"
                                TabIndex="2">Login Report</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</div>
