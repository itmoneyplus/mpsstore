<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Tab_report.aspx.vb"
    Inherits="Reports_MoneyPlus_Tab_report" %>

<%@ Register src="~/toolbaar/tool_report.ascx" tagname="tool_report" tagprefix="uc1" %>

<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1" TagPrefix="tool1" %>
<%@ Register Src="~/toolbaar/ReportControl.ascx" TagName="Toolbaar_Rep1" TagPrefix="tool_rep1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports</title>
    <%--   CSS used--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script language="JavaScript" type="text/javascript">
        javascript: window.history.forward(1);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="align" >
       <tool1:Toolbaar1 ID="tool_first" runat="server" />
        <br />
        <br />
         <tool_rep1:Toolbaar_Rep1 ID="Toolbaar_Rep1" runat="server" />
         <%--<uc1:tool_report ID="tool_report1" runat="server" />--%> 
    </div>
  
    </form>
</body>
</html>
