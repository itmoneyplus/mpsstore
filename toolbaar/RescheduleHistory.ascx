<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RescheduleHistory.ascx.vb" Inherits="toolbaar_RescheduleHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
<title>Reschedule History</title> 
<link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>

<div align="center" >
<table cellspacing="0"  class="payreceipt_table">
<tr>
<td style="background-color :#E8E8E8; width :95%;height:23px" >
<b class ="align-center">Reschedule History</b>
</td>
</tr>
<tr>
<td style="padding-left:30px;" >
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:Literal ID="ltReschdl" runat="server" Visible="false"  ></asp:Literal>
<%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
</ContentTemplate>
</asp:UpdatePanel>       
</td>
</tr>
<tr>
<td class ="align-center1">
<b><asp:Label ID="Label1" runat="server" Text="There is no Reschedule History" Visible ="false"></asp:Label></b>
<br />
</td>
</tr>
</table>
<br />
</div>

