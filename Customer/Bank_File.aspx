<%@ Page Language="VB" Culture="en-AU" EnableEventValidation ="false"  AutoEventWireup="false"  CodeFile="Bank_File.aspx.vb" Inherits="Customer_Bank_File" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool_bank.ascx"  TagName="Toolbaar_Bank"   TagPrefix="tool_bank"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
  <title>Bank File</title>
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
  <tool_bank:Toolbaar_Bank ID="t_bank" runat="server" />
  </div>
  </form>
  </body>
  </html>
