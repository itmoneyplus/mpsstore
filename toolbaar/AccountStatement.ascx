<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AccountStatement.ascx.vb" Inherits="toolbaar_AccountStatement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
<title>Statement of Loan</title> 
 <script type="text/javascript"  src="../frm_val.js"></script>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
<style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>
</head>
<div style="margin-left:30px">
<asp:Panel ID="Panel7" runat="server"  >
<table  cellspacing="0" class="payreceipt_table">
<tr>
<td style="font-size: medium; font-weight: bold; text-align: left; " 
                    class="style1">
<b>Statement Of Loan</b>
</td>
</tr>
<tr class="font_acc">
<td style="border-top: 0.1px solid gray; width: 50%; vertical-align: top; padding-left:22px;">
 <br />
 <br />
<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/White_Right_Arrow.GIF" />&nbsp;<asp:Label ID="label_1" runat="server" CssClass="label_style">Please enter statement start date:</asp:Label><asp:TextBox ID="txtstartdt" runat="server" CssClass ="align-center " Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartdt" format="dd/MM/yyyy"   OnClientShowing ="showDate"></ajaxToolkit:CalendarExtender>
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr class="font_acc">
<td style="padding-left:22px;">
<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/White_Right_Arrow.GIF" />&nbsp;<asp:Label ID="label1" runat="server" CssClass="label_style">Please enter statement end date:</asp:Label>&nbsp;<asp:TextBox ID="txtenddt" runat="server" CssClass="align-center" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtenddt" format="dd/MM/yyyy"  OnClientShowing ="showDate"></ajaxToolkit:CalendarExtender>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnloan" runat="server" Text="Create Loan Statement" />&nbsp;&nbsp;&nbsp;
</td>
</tr>
<tr><td>&nbsp;</td></tr>

<tr><td>&nbsp;</td></tr>
</table> 
</asp:Panel>
<div align="center">
<asp:Panel ID="Panel8" runat="server">
<table width="95%" style="border-collapse: collapse; border-style:none ; margin-left:.03in"  cellpadding="0" cellspacing="0">
<tr>
<td>
<asp:UpdatePanel ID="CollapseDelegate" runat="server">
<ContentTemplate>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</ContentTemplate>
</asp:UpdatePanel>       
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td class ="align-center">
<asp:Button ID="btnprnt" runat="server" Text="Print Loan Statement"  Visible ="false"/>
<asp:Button ID="btncnclst" runat="server" Text="Go Back and Re-Create" Visible ="false" />
</td>
</tr>
</table> 
</asp:Panel>
</div>
</div> 



 

 
