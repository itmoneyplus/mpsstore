<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tools_admin.ascx.vb" Inherits="toolbaar_tools_admin" %>
<div id="toolbar">
    <table id="Table1" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table id="Table2" cellspacing="0">
        <tr class="label_italics">
            <td>
                Administration
            </td>
        </tr>
    </table>
    <table id="toolbar_table" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table id="Table3" cellspacing="0">
        <tr class="toolbaar1_tr">
            <td class="toolbaar1_td_rep">
                <asp:LinkButton ID="Link_creditdue" runat="server" CssClass="toolbaar1_link" PostBackUrl="~/Customer/Payment_Collection.aspx"
                    TabIndex="1">Login Report</asp:LinkButton>
            </td>
        </tr>
    </table>
    
    
</div>