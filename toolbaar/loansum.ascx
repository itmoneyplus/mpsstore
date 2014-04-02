<%@ Control Language="VB" AutoEventWireup="false" CodeFile="loansum.ascx.vb" Inherits="toolbaar_loansum" %>
    <head>
    <title>feelist</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" />  
    </head>
    <div align="center" >
    <table class="table_loanrepay"  cellspacing="0">
    <tr >
    <%--<tr style="border:1px solid gray; background: #EEEEEE;
	background: -moz-linear-gradient(top, #EEEEEE, #EEEEEE);
	background: -webkit-gradient(linear, 0% 0%, 0% 100%, from(#EEEEEE), to(#EEEEEE));">--%>
   
    <td style="background-color:#EEEEEE; padding-left:2px;  " colspan="3" >
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass ="align_loansumm" >
    </asp:Label></td>
    <td style="background-color:#EEEEEE; padding-left:2px;  " colspan="2">
    <asp:Label ID="Label2" runat="server" Text="Label"  CssClass="align_right_loansumm"></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="3">&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
    <td class="td_loansumm">
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="td_loansumm" >Loan amount (paid by credit)</asp:LinkButton></td>
    <td class="td1_loansumm">
    $&nbsp;&nbsp;<asp:TextBox ID="txtloanamt" runat="server" Width="80px" 
    CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm"></td>
    <td class="td_loansumm">Payment frequency</td>
    <td class="td1_loansumm">
    &nbsp;&nbsp;<asp:TextBox ID="txtpayfre" runat="server" Width="80px" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="td_loansumm"><asp:LinkButton ID="LinkButton2" runat="server" CssClass="td_loansumm" >Total fees &amp; charges(summary)</asp:LinkButton><asp:LinkButton ID="LinkButton3" runat="server" CssClass="td_loansumm" Visible="false" >Breakdown of Fees & Charges</asp:LinkButton></td>
    <td class="td1_loansumm">
    <asp:Label ID="Label8" runat="server" Text="$" Width="5%"></asp:Label><asp:TextBox ID="txttotal" runat="server" Width="80px" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm"></td>
    <td class="td_loansumm">Total amount paid</td>
    <td class="td1_loansumm">
    $<asp:TextBox ID="txtamtpaid" runat="server" Width="80px" 
    CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="td_loansumm">
    <asp:Label ID="Label3" runat="server" Text="Defer Establishment Fee" Visible="False"></asp:Label>
    </td>
    <td class="td1_loansumm">
    <asp:Label ID="Label9" runat="server" Text="$" Width="5%" Visible="False"></asp:Label><asp:TextBox ID="txtdefer" runat="server" Width="80px" Visible="false" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm"></td>
    <td class="td_loansumm">Total amount outstanding</td>
    <td class="td1_loansumm">
    $<asp:TextBox ID="txtamtout" runat="server" Width="80px" 
    CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="td_loansumm">
    <asp:Label ID="Label4" runat="server" Text="Credit Fee" Visible="False"></asp:Label>
    </td>
    <td class="td1_loansumm">
    <asp:Label ID="Label10" runat="server" Text="$" Width="5%" Visible="False" ></asp:Label><asp:TextBox ID="txtcre" runat="server" Width="80px"  Visible="false" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm">&nbsp;</td>
    <td class="td_loansumm">&nbsp;</td>
    <td class="td1_loansumm">&nbsp;</td>
    </tr>
     <tr>
    <td class="td_loansumm">
    <asp:Label ID="Label5" runat="server" Text="Variation Fee" Visible="False"></asp:Label>
    </td>
    <td class="td1_loansumm">
    <asp:Label ID="Label11" runat="server" Text="$" Width="5%" Visible="False"></asp:Label><asp:TextBox ID="txtvar" runat="server" Width="80px"  Visible="false" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm">&nbsp;</td>
    <td class="td_loansumm">&nbsp;</td>
    <td class="td1_loansumm">&nbsp;</td>
    </tr>


    <tr>
    <td class="td_loansumm">
    <asp:Label ID="Label6" runat="server" Text="Other Fee" Visible="False"></asp:Label>
    </td>
    <td class="td1_loansumm">
    <asp:Label ID="Label12" runat="server" Text="$" Width="5%" Visible="False"></asp:Label><asp:TextBox ID="txtothr" runat="server" Width="80px"  Visible="false" CssClass="align-center" ReadOnly="True"></asp:TextBox></td>
    <td class="td2_loansumm">&nbsp;</td>
    <td class="td_loansumm">&nbsp;</td>
    <td class="td1_loansumm">&nbsp;</td>
    </tr>


    <tr>
    <td class="td_loansumm">
    <asp:Label ID="Label7" runat="server" Text="Loan amount and total fees"></asp:Label>
    </td>
    <td class="td1_loansumm">
    $&nbsp;&nbsp;<asp:TextBox ID="txttotalamt" runat="server" Width="80px" CssClass="align-center" ReadOnly="True"></asp:TextBox>
    <br /><br />
    </td>
    <td class="td2_loansumm">&nbsp;</td>
    <td class="td_loansumm">&nbsp;</td>
    <td class="td1_loansumm">&nbsp;</td>
    </tr>
    </table>
    </div>