<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="letter_container.aspx.vb" Inherits="Customer_letter_container" %>

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
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
    <table class="MsoTableGrid" width="590px" style="margin-left:.6in; border-style:none; page-break-after:always;"  cellpadding="0" cellspacing="0">
    <tr>
    <td>
    <img src="../Images/Letter_Head.png" alt="logo"  style="height: 50px; width: 256px"/>
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
        <b>Ph: (02) 9621 4446 Fax: (02) 9676 1066</b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
        <b>Web: moneyplus.com.au</b>
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
       
    <tr class="align">
    <td class="rep_font">DIRECT DEBIT AUTHORITY DISHONOUR NOTICE</td>
    </tr>
    <tr class="align" >
    <td class="rep_font"> This is NOT an arrears letter
    </td>
    </tr>
    <tr>
    <td class="rep_font"><b> DIRECT DEBIT DISHONOUR NOTICE</b></td>
    </tr>   
    <tr><td><br /></td></tr>
    <tr>
    <td><asp:Label ID="lbldate1" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>  
    <tr><td><br /></td></tr>   
     <tr class="align-right">
     <td class ="rep_font1">Loan No:&nbsp;<asp:Label ID="lblloanid" runat="server" CssClass="rep_font1"></asp:Label>&nbsp; </td>
     </tr> 
     <tr><td><br /></td></tr>
    
     <tr>
     <td>
     <asp:Label ID="lblname" runat="server" CssClass="rep_font"></asp:Label>
     </td>
     </tr>
      <tr>
      <td>
      <asp:Label ID="lbladd" runat="server" CssClass="rep_font"></asp:Label>
      </td>
      </tr>
      <tr>
      <td>
      <asp:Label ID="lblst" runat="server" CssClass="rep_font"></asp:Label>
      </td>
      </tr>
      <tr><td><br /></td></tr>
       <tr>
      <td><asp:Label ID="lbltitle" runat="server" CssClass="rep_font"></asp:Label>
      </td>
      </tr>
       <tr><td><br /></td></tr>
       <tr>
       <td class="rep_font">
       <b style="text-decoration:underline">RE:Your Direct Debit Authority</b>
       <br />
       </td>
       </tr>
       <tr><td><br /></td></tr>
       <tr>
       <td class="rep_font">
       Your loan repayment for <b>$<asp:Label ID="lblamt" runat="server"></asp:Label></b>&nbsp;due on
       <asp:Label ID="lbldt" runat="server" CssClass="rep_font1"></asp:Label>
       &nbsp;has been dishonoured by your bank. This loan has incurred a dishonour fee of&nbsp;
       <asp:Label ID="lblfee" runat="server" CssClass="rep_font1"></asp:Label>&nbsp;
       <asp:Label ID="lblvar" runat="server" text="and a variation fee of" Visible="false">
       </asp:Label>&nbsp;<asp:Label ID="lblvarfee" runat="server" CssClass="rep_font1" Visible="false"></asp:Label>.<br />
       </td>
       </tr>
        <tr>
        <td class="rep_font">(Totalling<asp:Label ID="ltot" runat="server"></asp:Label>)<br />
        </td>
        </tr>
        <tr><td><br /></td></tr>
        <tr>
        <td class="rep_font">
        The repayment,dishonour fee <asp:Label ID="lblfeetotal" runat="server" Text="and variation fee " Visible="false"></asp:Label>
        has now been rescheduled for <asp:Label ID="lblredt" runat="server" CssClass="rep_font1"></asp:Label>
        for a total of <b>$<asp:Label ID="lbltotal" runat="server"></asp:Label></b>. 
        Please ensure that there are sufficient funds in your account to meet the payment.
        </td>
        </tr>
        <tr><td><br /></td></tr>
        <tr><td class="rep_font">
        Please be aware should a repayment be outstanding more than 60 days this may be 
        reported to a Credit Reporting Agency (i.e.Veda).</td></tr>
        <tr><td><br /></td></tr>
        <tr>
        <td class="rep_font">
            Should you have any queries please do not hesitate to contact this office on 
            02&nbsp;9621&nbsp;4446.</td>
          </tr>
         <tr><td>&nbsp;</td></tr>
          <tr><td>&nbsp;</td></tr>
        
         <%--<tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>--%>
        
         <tr class="align "><td class="rep_font">Manager</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr><td>&nbsp;</td></tr>
        
         <tr><td class="rep_font "><b style="text-decoration:underline">Important Notice:</b></td></tr>
         <tr><td class="rep_font"> All accounts in arrears will incur administration or enforcement fees</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
     </table>
    </asp:Panel>
    </div>
    <br />

   
   <%-- This is for payment stoped--%>
  <%-- --------------------------------------------------------------------------------------------%>
    <div>
    <asp:Panel ID="Panel2" runat="server">  
    <table class="MsoTableGrid" width="590px" style="margin-left:.6in; border-style:none; page-break-after:always;"  cellpadding="0" cellspacing="0">
    <tr>
    <td>
    <img src="../Images/Letter_Head.png" alt="logo" style="height: 50px; width: 256px"/>
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
        <b>Ph: (02) 9621 4446 Fax: (02) 9676 1066</b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
        <b>Web: moneyplus.com.au</b>
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
      

    <tr class="align">
    <td class="rep_font">DIRECT DEBIT AUTHORITY DISHONOUR NOTICE</td>
    </tr>
    <tr class="align" >
    <td class="rep_font"> This is NOT an arrears letter
    </td>
    </tr>
    <tr>
    <td class="rep_font"><span><b>DIRECT DEBIT DISHONOUR NOTICE-Payment Stopped</b></span></td>
    </tr>   
    <tr><td><br /></td></tr>
    <tr>
    <td><asp:Label ID="lbldate2" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr> 
    <tr><td><br /></td></tr>   
    <tr class="align-right">
    <td class ="rep_font1">Loan No:&nbsp;<asp:Label ID="lblloanid1" runat="server" CssClass="rep_font1"></asp:Label>&nbsp; </td></tr> 
    <tr> <td><br /></td></tr>
   
    <tr>
    <td>
    <asp:Label ID="lblname1" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lbladd1" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblst1" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
    <tr><td><br /></td></tr>
    <tr>
    <td>
    <asp:Label ID="lbltitle1" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
   
    <tr>
    <td class="rep_font">
    <b style="text-decoration:underline">RE:Your Direct Debit Authority</b>
    <br />
    </td>
    </tr>
    <tr><td><br /></td></tr>
    <tr>
    <td class="rep_font">
    Your loan repayment for <b>$<asp:Label ID="lblamt1" runat="server"></asp:Label></b>&nbsp;due on
    <asp:Label ID="lbldt1" runat="server" CssClass="rep_font1"></asp:Label>
    &nbsp;has been dishonoured by your bank. This loan has incurred a dishonour fee of&nbsp;
    <asp:Label ID="lblfee1" runat="server" CssClass="rep_font1"></asp:Label>&nbsp;
    <asp:Label ID="lblvar1" runat="server" text="and a variation fee of" Visible="false"></asp:Label>&nbsp;
    <asp:Label ID="lblvarfee1" runat="server" CssClass="rep_font1" Visible="false"></asp:Label>.<br />
    </td>
    </tr>
    <tr>
    <td class="rep_font">(Totalling<asp:Label ID="ltot1" runat="server"></asp:Label>)</td></tr>
    <tr><td><br /></td></tr>
    <tr>
    <td class="rep_font">
    The repayment,dishonour fee <asp:Label ID="lblfeetotal1" runat="server" Text="and variation fee " Visible="false"></asp:Label>
    has now been rescheduled for <asp:Label ID="lblredt1" runat="server" CssClass="rep_font1"></asp:Label>
    for a total of <b>$<asp:Label ID="lbltotal1" runat="server"></asp:Label></b>. 
    Please ensure that there are sufficient funds in your account to meet the payment.
    </td>
    </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td class="rep_font">
     Please be aware should a repayment be outstanding more than 60 days this may be 
     reported to a Credit Reporting Agency (i.e.Veda).
     </td></tr>
     <tr><td><br /></td></tr>
     <tr><td class="rep_font">
         Should you have any queries please do not hesitate to contact this office on 
         02&nbsp;9621&nbsp;4446.</td>
     </tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
        
     <%--<tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>--%>
    
    
     <tr class="align ">
     <td class="rep_font">Manager</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td class="rep_font ">
     <b style="text-decoration:underline">Important Notice:</b></td></tr>
     <tr><td class="rep_font">
      All accounts in arrears will incur administration or enforcement fees
     </td>
     </tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
    <%-- <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>--%>
     </table>
     </asp:Panel>
    </div>
      <br />

       
  <%--  This is for account closed--%>
   <%-- --------------------------------------------------------------------------------------------%>
   
   <div>
   <asp:Panel ID="Panel3" runat="server">
    <table class="MsoTableGrid" width="590" style="margin-left:.6in; border-style:none;"  cellpadding="0" cellspacing="0">
    <tr>
    <td>
    <img src="../Images/Letter_Head.png" alt="logo" style="height: 50px; width: 256px"/>
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
        <b>Ph: (02) 9621 4446 Fax: (02) 9676 1066</b>
        </td>
    </tr>
    <tr>
        <td class="rep_font_new_left">
        <b>Web: moneyplus.com.au</b>
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
      
    
    <tr class="align">
    <td class="rep_font">DIRECT DEBIT AUTHORITY DISHONOUR NOTICE</td>
    </tr>
    <tr class="align" >
    <td class="rep_font"> This is NOT an arrears letter
    </td>
    </tr>
    <tr>
    <td class="rep_font"><span><b>DIRECT DEBIT DISHONOUR NOTICE-Account Closed</b></span></td>
    </tr>   
    <tr><td><br /></td></tr>
    <tr>
    <td><asp:Label ID="lbldate3" runat="server" CssClass ="rep_font"></asp:Label></td>
    </tr>
    <tr><td><br /></td></tr>    
    <tr class="align-right">
    <td class ="rep_font1">Loan No:&nbsp;<asp:Label ID="lblloanid2" runat="server" CssClass="rep_font1"></asp:Label>&nbsp; </td></tr> 
    <tr><td><br /></td></tr>
    
    <tr>
    <td>
    <asp:Label ID="lblname2" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lbladd2" runat="server" CssClass="rep_font"></asp:Label>
    </td>
    </tr>
     <tr>
     <td>
     <asp:Label ID="lblst2" runat="server" CssClass="rep_font"></asp:Label>
     </td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td>
     <asp:Label ID="lbltitle2" runat="server" CssClass="rep_font"></asp:Label>
     </td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td class="rep_font">
     <b style="text-decoration:underline">RE:Your Direct Debit Authority</b>
     <br />
     </td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td class="rep_font">
     Your loan repayment for <b>$<asp:Label ID="lblamt2" runat="server"></asp:Label></b>&nbsp;due on
     <asp:Label ID="lbldt2" runat="server" CssClass="rep_font1"></asp:Label>
     &nbsp;has been dishonoured by your bank. This loan has incurred a dishonour fee of&nbsp;
     <asp:Label ID="lblfee2" runat="server" CssClass="rep_font1"></asp:Label>&nbsp;
     <asp:Label ID="lblvar2" runat="server" text="and a variation fee of" Visible="false"></asp:Label>&nbsp;
     <asp:Label ID="lblvarfee2" runat="server" CssClass="rep_font1" Visible="false"></asp:Label>.<br />
     </td>
     </tr>
     <tr>
     <td class="rep_font">(Totalling<asp:Label ID="ltot2" runat="server"></asp:Label>)<br /></td></tr>
     <tr><td><br /></td></tr> 
     <tr>
     <td class="rep_font">
        The repayment,dishonour fee <asp:Label ID="lblfeetotal2" runat="server" Text="and variation fee " Visible="false"></asp:Label>
        has now been rescheduled for <asp:Label ID="lblredt2"  runat="server" CssClass="rep_font1"></asp:Label>
        for a total of <b>$<asp:Label ID="lbltotal2" runat="server"></asp:Label></b>. 
        Please ensure that there are sufficient funds in your account to meet the payment.
        </td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td class="rep_font">
      Please be aware should a repayment be outstanding more than 60 days this may be 
      reported to a Credit Reporting Agency (i.e.Veda).
     </td>
     </tr>
     <tr><td><br /></td></tr>
     <tr>
     <td class="rep_font">
         Should you have any queries please do not hesitate to contact this office on 
         02&nbsp;9621&nbsp;4446.</td>
      </tr>
               
      <tr><td>&nbsp;</td></tr> 
      <tr>
      <td class="rep_font"> Manager</td>
      </tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr> 
       <tr><td><br /></td></tr>
        <tr><td><br /></td></tr>
      <tr>
      <td class="rep_font">
      <b style="text-decoration:underline">Important Notice:</b></td>
      </tr>
      <tr>
      <td class="rep_font">
      All accounts in arrears will incur administration or enforcement fees
     </td>
     </tr>
      <%--<tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>--%>
     </table>
     </asp:Panel>
     </div> 
    </form>
</body>
</html>
