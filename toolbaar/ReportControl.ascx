<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReportControl.ascx.vb"
    Inherits="toolbaar_ReportControl" %>
<%@ Register Src="~/toolbaar/Reporttabs.ascx" TagName="Toolbaar_Rep1" TagPrefix="tool_rep1" %>
<%@ Register Src="~/toolbaar/Reports_tab_periodic.ascx" TagName="Toolbaar_Rep2" TagPrefix="tool_rep2" %>
<head>
    <title>tool_report</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<div id="toolbar">
    <table id="toolbar_table" cellspacing="0" class="table_toolbaar_rep">
        <tr class="toolbaar1_tr">
            <td valign="top" class="toolbaar1_td_rep">
                <asp:LinkButton ID="Link_Financial" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                    TabIndex="1">Financial Reports</asp:LinkButton>&nbsp;&nbsp;
            </td>
            <td valign="top" class="toolbaar1_td_rep">
                <asp:LinkButton ID="Link_Periodic" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_report.aspx"
                    TabIndex="2">Periodic Reports</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table id="Table1" cellspacing="0">
        <tr>
            <td valign="top">
                <tool_rep1:Toolbaar_Rep1 ID="Toolbaar_Rep1" runat="server" Visible="false" />
            </td>
            <td valign="top">
                <tool_rep2:Toolbaar_Rep2 ID="Toolbaar_Rep2" runat="server" Visible="false" />
            </td>
        </tr>
    </table>
</div>
<div class="clear">
</div>
