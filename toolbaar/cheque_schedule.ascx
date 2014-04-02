<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cheque_schedule.ascx.vb" Inherits="toolbaar_cheque_schedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Cheque Repayment</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    </head>
    <div align="center" id="MainContainer" >
    <br />
    <table class="table" align="center">
    <tr>
    <td  colspan="2" class="td_che_repay" >Cheque Cashed- Dishonoured-Repayments summary
    </td>
    <td colspan="2" class="td_che_repay" > Cheque Account Number:</td>
    <td class="td_che_repay" style="width:20%">&nbsp;</td>
   </tr> 
   <tr>
    <td  style ="text-align :left;width:30%"><img alt="cheque_img1" src="../Images/White_Right_Arrow.gif" width="10" height="10"/>Cheque Dishonoured:</td>
    <td  style ="text-align :left">&nbsp;$<asp:TextBox ID="txtdisamt" runat="server" TabIndex="1" style="width:70px;text-align:center"></asp:TextBox></td>
    <td style="width:5%"></td>
    <td style="width:24%">Payment frequency:</td>
    <td style="width:24%">
    &nbsp;&nbsp;<asp:TextBox ID="txtpayfre" runat="server" TabIndex="2" style="width:70px;text-align:center"></asp:TextBox>
   </td>
	</tr>
    <tr>
    <td style ="text-align :left"> <img alt="cheque_img2" src="../Images/White_Right_Arrow.gif" width="10" height="10"/>Total Fees & charges(summary):</td>
    <td style ="text-align :left" >&nbsp;$<asp:TextBox ID="txttotfee" runat="server" TabIndex="3" style="width:70px;text-align:center"></asp:TextBox></td>
	<td style="width:5%"></td>
	<td style="width:24%">Amount recovered:</td>
    <td style="width:24%"> 
    $<asp:TextBox ID="txtamtrec" runat="server" TabIndex="4" style="width:70px;text-align:center"></asp:TextBox>
    </td>
	</tr>
    <tr><td colspan="2">&nbsp;</td>	<td style="width:5%"></td><td style="width:24%">Amount owing:</td><td style="width:24%">$<asp:TextBox ID="txtamtowe" runat="server" TabIndex="5" style="width:70px;text-align:center"></asp:TextBox></td> </tr>
    <tr><td style ="text-align :left">&nbsp;&nbsp;Total repayment amount plus fees:</td><td style="width:5%">&nbsp;$<asp:TextBox ID="txtamtplusfee" runat="server" TabIndex="6" style="width:70px;text-align:center"></asp:TextBox></td></tr> 
    <tr><td></td></tr>
    <tr><td colspan ="6"><asp:Button ID="Button1" runat="server" Text="Repayment" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Cheque Detail" /> &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Debit Form" />&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" Text="Schedule" />&nbsp;&nbsp;</td></tr>
    </table>
   	</div>