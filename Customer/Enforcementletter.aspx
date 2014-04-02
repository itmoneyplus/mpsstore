<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Enforcementletter.aspx.vb" Inherits="Customer_enforcementletter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Print Notice Using:</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
      <script type="text/javascript"  >
   window.history.forward(1);
   function  new_page() {
    window.location.assign("LoanSummary.aspx");
}
</script>
</head>
    <body  ondblclick="new_page();"  onload="window.print();">
    <form id="form1" runat="server" >
    <div>
    <asp:Panel ID="Panel1" runat="server" >
    <table class="MsoTableGrid" width="562" style="margin-left:.9in; border-style:none"  cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <img src="../Images/Letter_Head.png" alt="logo" style="height: 50px; width: 256px "/>
        </td>
    </tr>
     <tr>
        <td class="rep_font_new_left">
        <b>15 Campell Street, Blacktown, NSW 2148</b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
        <b>Email: loans@moneyplus.com.au </b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
       <b> Ph: (02) 9621 4446 Fax: (02) 9676 1066</b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
      <b> Web: moneyplus.com.au</b> 
        </td>
    </tr>   
   
  <tr>
    <td class="rep_font_new">
    This notice is sent by Geeghis Pty Ltd
    </td>
    </tr>
    <tr>
    <td class="rep_font_new">
    (ABN 93 139  094 625) T/as Moneyplus
    </td>
    </tr>
    <tr>
    <td class="rep_font_new">
    Netlending on behalf of the credit
    </td>
    </tr>
    <tr>
    <td class="rep_font_new">
    provider Abaz Pty Ltd. Australian
    </td>
    </tr>
    <tr>
    <td class="rep_font_new">
    credit licence number 391104
    </td>
    </tr>
    <tr>
    <td class="align-right">
    &nbsp;
    </td>
    </tr>
   
   
    <tr>
    <td class="align-center">ENFORCEMENT NOTIFICATION LETTER</td>
    </tr> 
    <tr><td><br /></td></tr>   
    <tr>
    <td><asp:Label ID="lbldate" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>
    
    <tr><td><br /></td></tr>
    <tr>
    <td><asp:Label ID="lblname" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>
    <tr>
    <td> <asp:Label ID="lbladd" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>
    <tr>
    <td> <asp:Label ID="lblst" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>   
    <tr><td><br /></td></tr>
    <tr>
    <td>
    <asp:Label ID="lbltitle" runat="server" CssClass ="rep_font"></asp:Label>            
    </td>
    </tr>
    <tr><td><br /></td></tr>         
    <tr><td class ="rep_font">RE:
    <b style="text-decoration:underline">Loan Default :$<asp:Label ID="lbllnamt" runat="server"></asp:Label>&nbsp; Prelude to Civil Action</b>
    <br/>
    </td>
    </tr>
    <tr><td class="rep_font">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loan Contract No:<asp:Label ID="lbllnno" runat="server"></asp:Label></td></tr>
    <tr><td> <br /></td></tr>
    <tr>
    <td class ="rep_font">
    We are calling in the loan for all monies to be paid. Please urgently 
	contact us by phone, fax or e-mail to resolve this matter within 5 working 
	days. Should you fail to do so we will forward the file to our legal 
	department to obtain a court order to cover all monies owed with costs 
	escalating substantially.
    </td> 
    </tr> 
    <tr><td> <br /></td></tr>
    <tr>
    <td class ="rep_font">
    You will also be reported to the Veda Advantage, the 
	credit Bureau used by the majority of Australian Credit Union, Banks, 
	Building Societies and finance companies.&nbsp; We may report your identity particulars and the details of any payments overdue by 
	60 days or more. If we have reasonable cause we may also list your default 
	as a serious credit infringement.
	</td> 
    </tr> 
    <tr><td> <br /></td></tr>
    <tr>
    <td class ="rep_font"> Please contact us urgently.
    </td>
    </tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
  
    
     
    <tr class="align"><td class ="rep_font">Branch Manager</td></tr>
    
    </table>
    </asp:Panel>
     </div>
    </form>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
</body>
</html>
