<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cheque_detail_new.ascx.vb" Inherits="toolbaar_Cheque_detail" %>
  <head>
  <title>tool_cheque</title> 
  <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
  </head>
  <div align="center" >
   <table style="background-color:#F9F8F4;width:95%;border:1px solid black">
   <tr>
   <td colspan="6"  style="background-color:#C0C0C0;background-color:#EEEEEE;text-align :left">
   <b>Cheque Detail</b></td>
   </tr>
   <tr>
    <td  style ="text-align :left;width:13%">Cheque name:</td>
    <td  style ="text-align :left"><asp:Label ID="lblchknm" runat="server" Text="Label"></asp:Label></td>
    <td rowspan="4" >
	</td>
	</tr>
    <tr>
    <td style ="text-align :left">BSB:</td>
    <td style ="text-align :left" ><asp:Label ID="lblchkbsb" runat="server" Text="Label"></asp:Label></td>
	</tr>
     <tr>
	<td  style ="text-align :left">Cheque number:</td>
	<td  style ="text-align :left" ><asp:Label ID="lblcheno" runat="server" Text="Label"></asp:Label></td>
	</tr>
    <tr>
   	<td  style ="text-align :left">Account number:&nbsp;</td>
	<td  style ="text-align :left"><asp:Label ID="lblaccno" runat="server" Text="Label"></asp:Label></td>
	</tr>
    <tr>
	<td  style ="text-align :left">Cheque amount:</td>
    <td  style ="text-align :left">$<asp:Label ID="lblcheamt" runat="server" Text="Label"></asp:Label></td>
	
    <td style="width:24%"></td>
	<td style="width:13%"></td>
    <td style="width:10%"></td>
    </tr>
    <tr>
    <td  style ="text-align :left">Cheque fee:</td>
	<td  style ="text-align :left">$<asp:Label ID="lblchefee" runat="server" Text="Label"></asp:Label></td>
	<td style="width:14%"></td>
	<td style="width:24%"></td>
	<td style="width:13%"></td>
	<td style="width:10%"></td>
    </tr>
    <tr>
    <td  style ="text-align :left">Paid by cash:</td>
	<td  style ="text-align :left">$<asp:Label ID="lblpaidcash" runat="server" Text="Label"></asp:Label></td>
	<td style="width:14%"></td>
	<td style="width:24%"></td>
	<td style="width:13%"></td>
	<td style="width:10%"></td>
    </tr>
    <tr><td colspan="6">&nbsp;</td></tr>
    </table>
   	</div>
   
   	<div align="center" >
   	 <table style="background-color:#F9F8F4;width:95%;border:1px solid black">
     <tr><td>
   	 <asp:Button ID="btnprntrecpt" runat="server" Text="Print Receipt" />
     </td></tr>
     </table>
     </div>
    
   
 
