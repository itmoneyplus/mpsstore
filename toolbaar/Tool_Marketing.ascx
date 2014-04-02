<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Tool_Marketing.ascx.vb" Inherits="toolbaar_Tool_Marketing" %>
<%@ Register Src="~/toolbaar/Reporttab_Marketing.ascx" TagName="Toolbaar_Repmar"   TagPrefix="tool_repmar"%>
<%@ Register Src="~/toolbaar/Reporttab_Statistics.ascx" TagName="Toolbaar_Repsta"   TagPrefix="tool_repsta"%>

<head>
    <title>tool_marketing</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    </head>
    <div id="toolbar">
    <table id="toolbar_table" cellspacing="0"  class="table_toolbaar_rep">
    <tr  class ="toolbaar1_tr">
    <td  valign ="top"  class="toolbaar1_td_rep">
    <asp:LinkButton ID="Link_Marketing" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx" TabIndex="1">Marketing Letters</asp:LinkButton>&nbsp;&nbsp;
    </td>
    <td valign ="top" class="toolbaar1_td_rep">
    <asp:LinkButton ID="Link_Statistics" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Tab_Marketing.aspx"  TabIndex="2" >Statistics</asp:LinkButton>
    </td>
    </tr>  
    </table>
    <table id="Table1" cellspacing="0"  >
    <tr>
    <td valign ="top">
    <tool_repmar:Toolbaar_Repmar  ID="Toolbaar_mar" runat="server" Visible ="false" />
    </td>
    <td valign ="top">
    <tool_repsta:Toolbaar_Repsta ID="Toolbaar_sta" runat="server"  Visible ="false" />
    </td>
    </tr>
    </table>
    </div> 