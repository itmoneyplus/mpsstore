<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Tab_Marketing.aspx.vb" Inherits="Customer_Tab_Marketing" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/Tool_Marketing.ascx" TagName="Toolbaar_mar"   TagPrefix="tool_mar"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Reports Marketing</title>
 <%--   CSS used--%>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
 <script language="JavaScript" type="text/javascript" >
         javascript: window.history.forward(1);
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="align">
<tool1:Toolbaar1 ID="tool_first" runat="server" />
<br/>
<br/>
<tool_mar:Toolbaar_mar ID="tool_market" runat ="server" />
</div>
</form>
</body>
</html>

