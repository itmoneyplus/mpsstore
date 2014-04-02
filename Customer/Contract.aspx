<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="Contract.aspx.vb" Inherits="Customer_partcontract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
 <title>Contract</title>
 <link rel="stylesheet" type="text/css" href="../css/style.css" />
 <script type="text/javascript">
window.history.forward(1);
function  new_page() {
    window.location.assign("LoanSummary.aspx");
}
 </script>
     
 </head>
 <body onload="window.print();" ondblclick="new_page();">
 <form id="form1" runat="server" >
    <div>
 <asp:Panel ID="P1" runat="server" >
 <table class="MsoTableGrid"  cellspacing="0" cellpadding="0"  style="margin-left:.17in;width:700px">
 <tr>
 <td  class="td_top_part" style="width:1301px;text-align :justify">
 <p style="color:#000000; font-size :16px">
 <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SMALL AMOUNT CREDIT CONTRCT </b></p>
 </td>
 </tr>
 <tr><td></td></tr>
 <tr>
 <td>
 <span class="font_p_contract">We,&nbsp;&nbsp;&nbsp; Abaz Pty Ltd  A.C.N 118 434 021&nbsp;Australian Credit Licence 391104 (&quot;us / we&quot;) of</span> 
 </td>
 </tr>
 <tr>
 <td>
 <span class="font_p_contract">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; First Floor 15 Campbell Street, Blacktown NSW 2148</span>
 </td>
 </tr>
 <tr><td class="font_p_contract">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tel:&nbsp;<asp:Label ID="Label20" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fax:&nbsp;<asp:Label ID="Label21" runat="server"></asp:Label></td></tr>
 <tr>
 <td>
 <p>
 <span class="font_p_left_contract">offer the Borrower 
 named in the schedule below, a loan of the amount specified in the schedule on 
 the terms and conditions set out in this contract (the &#39;Credit Contract&#39;).&nbsp;
 </span>
 </p>
 </td>
 </tr>
 <tr><td class="font_p_contract"><span class="part_font_contract">SIGNED </span>
 <span class="font_p_contract">by</span>
 <span class="part_font_contract"> the Authorised Officer of the credit &nbsp;<br />
     provider&nbsp; </span>
 </td>
 </tr> 
 <tr><td>&nbsp;</td></tr>
 <tr><td>&nbsp;</td></tr>
 </table>
 <table  class="MsoTableGrid"  cellspacing="0" cellpadding="0" style="margin-left:.17in;width:755px">
 <tr>
 <td  style="width:49%">
 &nbsp;.........................................................................</td>
 <td style="width:60%">
 &nbsp;........................................................................</td>
  </tr>
 <tr>
 <td style="width:49%">
 <span class="font_p_contract">Print name</span>
 </td>
 <td style="width:60%"><span class="font_p_contract">Signature</span></td>
 </tr>
 </table>
 <span style="font-family:Times New Roman;font-weight:700">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="font-size :14px">&nbsp; SCHEDULE</span>
 </span>
 <p style="font-size :14px"><b><asp:Label ID="Label1" runat="server" Text="The Borrowers' details:" Visible ="false" ></asp:Label></b></p>
 <p style="font-size :14px"><b><asp:Label ID="Label2" runat="server" Text="The Borrower's details:" Visible ="false" ></asp:Label></b></p>
 <table border="0" width="658px"  cellpadding="0" cellspacing="0" style="border-collapse: collapse;margin-left:5; border-color:#111111;height:78px" id="AutoNumber16">
 <tr>
 <td style="width:355px">
 <table border="0" cellpadding="0" cellspacing="2" style="border-collapse: collapse;margin-left:5;border-color:#111111"  width="88%" id="AutoNumber17">
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server"></asp:Label></span></td>
 </tr>
 </table>
 </td>
 <td style="width:303px"> 
    <table border="0" cellpadding="0" cellspacing="2" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="95%" id="AutoNumber18">
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" ></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" ></asp:Label></span></td>
    </tr>
   </table>
   </td>
   </tr>
   </table>
   <br />
   <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="88%" id="AutoNumber19">
   <tr>
   <td style="width:54%">
	<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="82%" id="AutoNumber20">
	<tr>
	<td style="width:44%">
 	<span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;Customer No:&nbsp;<asp:Label ID="Label11" runat="server" ></asp:Label></span></td>
 	</tr>
	</table>
    </td>
    <td style="width:46%">
    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;margin-left:5;border-color:#111111" width="67%" id="AutoNumber21">
	<tr>
    <td style="width:56%"><span style="font-size :14px">&nbsp;&nbsp;&nbsp;Loan No:&nbsp;<asp:Label ID="Label12" runat="server" ></asp:Label></span></td>
	</tr>
	</table>
    </td>
    </tr>
   </table>
    <p style="margin-top:18.0pt;margin-bottom:10.0pt">
        <span style="font-size :13.5px;font-family: Times New Roman;margin-left:.17in;width: 300px">
    <b>Financial Table prepared as at &nbsp;<asp:Label ID="Label13" runat="server"></asp:Label>&nbsp;("Disclosure Date&quot;) </b>The Loan Date is the date we first provide the loan to you.</span></p>
  
   <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" style="margin-left:.17in;border-style:none; border-color:inherit; border-collapse: collapse; height :354px ;width:600px" >
   <tr>
   <td style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: 1.5pt double windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 250px">
   <span style="font-size :14px; font-family: Times New Roman">Amount of credit</span>
   </p>
   </td>
   <td  style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: 1.5pt double windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm; height:30px">
   <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse;border-color:#111111" width="60%" id="AutoNumber7">
   <tr>
   <td style="width:250px" valign="bottom">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt">
   <span style="font-size :14px; font-family: Times New Roman"><b>$<asp:Label ID="Label14" runat="server"></asp:Label></b></span></p>
   </td>
   </tr>
   </table>
   </td>
   </tr>
   <tr>
   <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm ; height:30px">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
   <span style="font-size :14px; font-family: Times New Roman">Repayments</span>
   </p>
   </td>
   <td  style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm; height:30px">
   <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse;border-color:#111111"  width="90%" id="Table2">
   <tr>
   <td style="width:450px" valign="bottom">
   <p class="MsoNormal_p_contract_new" 
           style="margin-top:2.0pt; margin-bottom:2.0pt; width: 415px;">
   <span style="font-size :14px; font-family: Times New Roman">You must make <asp:Label ID="Label16" runat="server" ></asp:Label>   &nbsp;repayments of 
       $<asp:Label ID="Label49" runat="server" Text="Label"></asp:Label>&nbsp; due 
       <asp:Label ID="Label50" runat="server" Text="Label"></asp:Label> commencing from <asp:Label ID="Label48" runat="server"></asp:Label></span></p>
  </td>
  </tr>
  </table>
  </td>
  </tr>
<tr>
   <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm ; height:30px">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
   <span style="font-size :14px; font-family: Times New Roman">Total amount of repayments</span>
   </p>
   </td>
   <td  style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm; height:30px">
   <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse;border-color:#111111"  width="60%" id="Table1">
   <tr>
   <td style="width:250px" valign="bottom">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 415px;">
   <span style="font-size :14px; font-family: Times New Roman"><b>$<asp:Label ID="Label15" runat="server"></asp:Label></b><br />This is the total of the amount you must pay</span></p>

  </td>
  </tr>
  </table>
  </td>
  </tr>
  <tr>
  <td valign="middle" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman">Final Repayment Date</span>
  </p>
  </td>
  <td valign="middle" style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 250px">
  <span style="font-size :14px; font-family: Times New Roman">
      <asp:Label ID="Label51" runat="server" Text="Label"></asp:Label></span>
  </p> 
  </td>
  </tr>
   <tr>
  <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:76px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman"><b>Credit Fees and Charges </b></span>
  </p> 
  </td>
  <td valign="top" style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:76px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width:400px">
  <span style="font-size :14px; font-family: Times New Roman">You must pay 
      to us the following credit fees and charges at the time specified below, or if 
      no time is specified on demand. The amount becomes due and we can debit your 
      account when the relevant event occurs. All fees are not refundable.
  </span>
  </p> 
  </td>
  </tr>
  <tr>
  <td valign="middle" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 220px"><span style="font-size :14px; font-family: Times New Roman">
      Establishment fee payable on the Loan Date</span>
  </p>
  </td>
  <td valign="middle" style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt">
  <span style="font-size :14px; font-family: Times New Roman">
      $<asp:Label ID="Label53" runat="server" Text="Label"></asp:Label></span></p> 
  </td>
  </tr>
  <tr>
  <td style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
     <span style="font-size :14px; font-family: Times New Roman"> Monthly credit fee</span></p> 
  </td>
  <td style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 400px">
  <span style="font-size :14px; font-family: Times New Roman">$<asp:Label ID="Label18" runat="server"></asp:Label>&nbsp;per month for 
      <asp:Label ID="Label52" runat="server" Text="Label"></asp:Label> month(s) The credit fee is payable monthly and is included in your repayments. If the loan is not repaid on due date, the monthly fee continues to be payable each month until your loan is repaid in full.
 </span> 
  </p>
  </td>
  </tr>
  <tr>
  <td style="width:210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 250px">
    <span style="font-size :14px; font-family: Times New Roman"> Enforcement expenses</span></p></td>
  <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 420px">
  <span style="font-size :14px; font-family:Times New Roman ">$50.00 each time you fail 
      to make a payment. This fee covers internal costs and some external costs. 
      Additional enforcement expenses may become payable, the amount of which is 
      unascertainable.</span></p> 
  </td>
  </tr> 
 
  <tr>
  <td style="width:210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">
 <span style="font-size :14px"></span><span style="font-size :14px; font-family: Times New Roman"> 
 Bank dishonour fee</span>
 </td>
   <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">
 
   <span style="font-size :14px; font-family: Times New Roman">$30.00 the amount payable by us each time a cheque or direct debit used to make a repayment is dishonoured.</span></td>
   </tr>
     <tr>
  <td style="width:210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">
 <span style="font-size :14px"></span><span style="font-size :14px; font-family: Times New Roman"> 
Government charges</span>
 </td>
   <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">

   <span style="font-size :14px; font-family: Times New Roman">If government charges or duties are payable in respect of this contract, we may debit these to your account any time after they are incurred.</span></td>
   </tr>
   <tr>
   <td style="width:210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">
 <span style="font-size :14px"></span><span style="font-size :14px; font-family: Times New Roman"> 
<b>Total Fees</b> (excluding unascertainable fees and fees that may or may not be payable).</span>
 </td>
  <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 420px">
   <span style="font-size :14px; font-family: Times New Roman">
       $<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></span></p> </td>
   </tr>
   </table>
            <span style="font-size :small;color :Gray">&nbsp;&nbsp;&nbsp;&nbsp; NETL </span><asp:Label ID="Label36" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
 <p class="MsoNormal_p_contract_new"  style="margin-top:10.0pt; margin-bottom:20.0pt; width: 755px">
  &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1 of&nbsp; 7</span>
  </p>
  <p>&nbsp;</p>
  <p>&nbsp;</p>
  <DIV style="page-break-after:always"></DIV>
  <p>
<span style="font-size :14px; font-family: Times New Roman;margin-left:.17in">
&nbsp;&nbsp;You authorise and direct us to pay your loan as follows.</span>
</p>
  <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" style="margin-left:.17in;border-style:none; border-color:inherit; border-collapse: collapse; height :100px ;width:150px" >
    <tr>
    <td style="width:250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">

    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px; font-family: Times New Roman"><b>Establishment fee</b></span>
    </p>
     <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
	</span>
	</p> 
	 <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:330px">
    <span style="font-size :14px"><b> Amount paid to you or credited to your bank account </b> 
	</span>
	</p>
	 <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px"><b>&nbsp; </b> 
	</span>
	</p>
	  <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
	</span>
	</p> 
	 <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px"><b> Total</b> 
	</span>
	</p>
    </td>
   <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">
  
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:300px">
   <span style="font-size :14px"><b>$<asp:Label ID="Label56" runat="server" Text="Label"></asp:Label></b></span></p>
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:300px">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
	</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:300px">
        <span style="font-size :14px"> <b>$<asp:Label ID="Label57" runat="server" Text="Label"></asp:Label></b></span></p> 
     <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:280px">
    <span style="font-size :14px"><b>&nbsp;</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
	</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:300px">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
	</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:300px">
        <span style="font-size :14px"><b>$<asp:Label ID="Label58" runat="server" Text="Label"></asp:Label>&nbsp;(Including GST)</b></span></p> 
    </td>
    </tr>
   
  </table>
   <p style="font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:680px">&nbsp;
   </p>
    <p style="margin-left:.17in;font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:680px">Paymay 
        Pty Limited manages our loans for us and so you will normally deal with them.</p>
      <p style="font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:700px">&nbsp;</p>
       <p style="margin-left:.17in;font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:700px"><b>IF YOU 
           CANNOT MAKE A PAYMENT, CONTACT PAYMAY IMMEDIATELY TO DISCUSS YOUR</b><br/><b>SITUATION.</b></p>
 <p style="margin-left:.17in;font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:680px">We may 
     pay Paymay Pty Limited commission or management fees, and Paymay may pay us a 
     guaranteed return.</p>
      <p style="margin-left:.17in;font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:680px">The amounts of these payments are unascertainable at the date of this contract.</p>
      <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p> <span style="font-size :small;color :Gray">&nbsp;&nbsp;&nbsp;&nbsp;NETL </span><asp:Label ID="Label41" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label></p>
<p class="MsoNormal_p_contract_new"  style="margin-top:5.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label27" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2 of&nbsp; 7</span></p>
 <p>&nbsp;</p>
 
  <div style="page-break-after:always"></div>
<table border="0"  cellpadding="0" cellspacing="1" style="border-collapse: collapse ;width:600px;border-color:#111111 ;margin-left :.15in" id="AutoNumber22" >
  <tr>
    <td  style ="width:641px" valign="top" colspan="2" >
    <span style="font-size :17px;background-color:#FFFFFF;font-weight:bold;font-family:Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TERMS AND CONDITIONS OF CREDIT CONTRACT
    </span>
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td valign="top">
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm;margin-bottom: .0001pt; width: 116px;">
    <b><span style="font-family: Times New Roman;font-size :14px">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span style="font-family: Times New Roman;font-size :14px;width: 350px">
	Repayments</span></b>&nbsp;</p> 

    <p class="MsoNormal_p_contract_new" style=" text-align:left;width:370px;margin-top:3.0pt" >
    <span style="font-family: Times New Roman;font-size :14px">You must make 
    all payments on the due date. Repayments
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style=" text-align:left; width: 330px;margin-top:3.0pt" >
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px "> are to 
    be made as directed by us. We may choose the order of how we apply your repayments to any money you owe to us.
    </span>

    </p>
      
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:3.0pt">
    <span style="font-family: Times New Roman;font-size :14px; line-height:17px">If any 
    repayment is due to be made on a day which&nbsp;is not a business day, the 
    repayment must be made&nbsp;on the next business day.
    </span>
    </p> 
    
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 340px;margin-top:3.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px">If 
	any direct debit or electronic funds transfer used for repayment is dishonoured, the repayment will be treated as not having been made.
    </span>
    </p>

	<p class="MsoNormal_p_contract_new" style="text-align:left;width:330px;margin-top:3.0pt">
    <span style="font-family: Times New Roman;font-size :14px; line-height:17px">The total amount we can recover from you is twice the amount paid to you or as you direct on the Loan Date plus reasonable enforcement expenses.
	</span>
	</p> 
	
	<p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:3.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px">We do not pay interest on any credit balance 
	in your account.
	</span>
	</p> 
	 
	<p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm; margin-top:3.0pt; margin-bottom: .0001pt">
    <b><span style="font-family: Times New Roman;font-size :14px">2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Monthly credit fee</span></b></p> 
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:3.0pt">
        <span style="font-family: Times New Roman;font-size :14px; text-align :justify;line-height :19px">During the term of your loan, the repayments shown in the schedule include your monthly credit fee. If you do not repay the loan in full on the Final Repayment Date, you must pay the monthly credit fee each month in advance commencing on the 
        Final Repayment Date. This does not affect your obligation to repay the loan in full on the Final Repayment Date. You will be in default of your repayment obligations after the Final Repayment Date. All fees are not refundable.
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm; margin-top:1.0pt; margin-bottom: .0001pt">
    <b><span style="font-family: Times New Roman;font-size :14px">3.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span style="font-family: Times New Roman;font-size :14px;width: 350px">
	Default</span></b>&nbsp;</p> 
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:7.0pt;margin-bottom:7.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height :19px"><b>When 
	there is default&nbsp;</b>
    </span>
    </p> 
  
	<p class="MsoNormal_p_contract_new" style="margin-right:0cm;margin-bottom:0cm; margin-left:1.7pt;margin-bottom:.0001pt;line-height:normal;width: 350px;margin-top:7.0pt;margin-bottom:7.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">If any one or 
	more of the following occur we may decide default has occurred. You must 
	ensure default does not occur.</span>
	</p> 
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm; width: 330px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(a)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">There 
        is default of any term or condition of this&nbsp;loan contract.</span>
	</p>
	
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;width: 330px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(b)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">Any 
	representation made by you to our agents or <br />us proves to be untrue or 
	misleading.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;  margin-bottom: .0001pt;width: 330px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(c)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext">You 
	become bankrupt or are jailed.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;  margin-bottom: .0001pt;width: 330px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(d)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">You 
	breach any material undertaking given at <br />any time to us.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="margin-left:0cm;margin-bottom:.0001pt;text-indent:0cm; text-align:justify;line-height:normal;page-break-after:avoid;margin-top:5.0pt">
    <b>
    <span style="font-family: Times New Roman;font-size :14px;width: 330px">Our 
	rights on default</span></b>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt">
    <span style="font-family: Times New Roman; color: windowtext;font-size :14px; line-height :19px">
    At any time after default occurs, we can take 
	any of the following actions after giving any notice
	    required by law and , if required by law, the period specified in the notice has passed and the 
        default has not been rectified.</span></p>
       <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(a)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;Demand 
        and require immediate payment of any money <br />due under this loan contract.
    </span>
    </p>  
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt; margin-right: 0cm;text-align:left;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt" >
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(b)</span>
        <span style="font-family: Times New Roman; color: windowtext;font-size :14px">
        Call up the loan and require payment of the entire balance owing under this loan 
        contract.
    </span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt; margin-right: 0cm;text-align:left;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt" >
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(c)</span>
        <span style="font-family: Times New Roman; color: windowtext;font-size :14px">
       Terminate this contract.
    </span>
    </p>
	</td> 
    <td valign="top">
   
    
   
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height:17px;width: 330px">We can take 
    action even if we do not do so promptly after the default occurs; so long as 
	the default remains and notice as required by law is given.&nbsp;
   </span>
   </p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height:17px;width: 330px">
    If you default under this contract, the maximum amount we can recover from you is twice the adjusted credit amount. In addition, we are still entitled to recover reasonable enforcement expenses.
   </span>
   </p>
    <p class="MsoNormal_p_contract_new" style="page-break-after:avoid;width: 350px;margin-top:5.0pt"><b>
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height:17px">Enforcement 
    expenses</span>&nbsp;</b>
    </p> 
  
    <p class="MsoNormal_p_contract_new"  style="text-align:left;width: 335px;margin-top:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">Enforcement expenses may become payable under the loan contract if you default. You 
    must pay on demand and we may debit your account with our costs in 
    connection with any exercise or non exercise of rights arising from any 
    default, including:</span></p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;text-align:left;font-size :14px;text-align:left;width: 300px;margin-top:5.0pt" >
	(a)<span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman;font-size :14px">&nbsp;&nbsp;</span><span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">legal costs and expenses on a full indemnity basis or solicitor and own 
    client basis, whichever is higher;</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;text-align:left;font-size :14px;text-align:left;width: 330px;margin-top:5.0pt" >
	(b)<span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman;font-size :14px">&nbsp;&nbsp;</span><span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">our internal costs.
    </span>
    </p>
   <p class="MsoNormal_p_contract_new" style="margin-bottom:1.0pt;margin-top:1.0pt;width: 330px;margin-top:5.0pt" >
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">These costs 
    will not exceed our reasonable enforcement costs including internal costs.</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="margin-bottom:1.0pt;margin-top:1.0pt;width: 330px;margin-top:5.0pt" >
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">If you default at any time, we may elect not to charge default fees at that time. However, in these cases we reserve the right to charge a default fee at a later time, including after the loan is repaid in full.</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm;width: 330px;margin-top:5.0pt">
    <b><span style="font-family: Times New Roman;font-size :14px">4.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :21px">
	General matters</span></b>&nbsp;
	</p> 

    
    <p class="MsoNormal_p_contract_new" style="text-indent: 0cm;page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left;line-height :19px">
	Lender's certificate</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman; color: windowtext;text-align:left;line-height :19px">A certificate signed by or on behalf as to an amount payable to us 
	is conclusive and binding on you.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: 0cm;page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;width: 360px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left; line-height :19px">
	How we can deal with this loan contract</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;line-height :19px;margin-top:5.0pt">
    <span style="font-size :14px;font-family: Times New Roman; color: windowtext;text-align:left">We may assign, novate, or otherwise deal with our rights under this loan 
        contract in any way we wish. We may disclose personal and credit information 
        about you in connection with any such dealing or proposed dealing. You must sign 
        anything and do anything we reasonably require to enable any dealing with this 
        loan contract.&nbsp; Of&nbsp; course, any dealing with our rights does not 
        change your obligations under this loan contract in any 
	way.
	</span>
	</p>
	<span style="font-size :14px"> </span>
	<p class="MsoNormal_p_contract_new" style="text-indent: 0cm; page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;width: 380px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left;margin-top:1.0pt;margin-bottom:15.0pt; line-height :21px">
    Consumer legislation
    </span>&nbsp;
    </p>
    <p class="MsoNormal_p_contract_new" style="width: 330px;line-height :19px;margin-top:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman;text-align:left">To the 
        extent that this loan contract is regulated&nbsp;under consumer 
		legislation (eg the National Credit Code), any provisions which do not 
		comply with that legislation have no effect, and to the extent necessary, 
    this loan contract is to be read so it does not impose obligations 
    prohibited by that legislation.
    </span>
    </p> 
     <p class="MsoNormal_p_contract_new" style="width: 330px;line-height :19px;margin-top:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman;text-align:left">We encourage you to obtain independent legal advice and independent financial advice.
    </span>
    </p> 
   
     
     
  </td>
  </tr>
  <tr><td>&nbsp;</td></tr>
</table>
<span style="font-size :small;color :Gray;margin-top:5.0pt">NETL </span><asp:Label ID="Label46" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>

  <p class="MsoNormal_p_contract_new"  style=" margin-top:5.0pt;margin-bottom:20.0pt; width: 755px;">
  <asp:Label ID="Label28" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 of&nbsp; 7</span></p>
<div style="page-break-after:always"></div>
<p>&nbsp;</p>

<table border="0"  cellpadding="0" cellspacing="1" style="border-collapse: collapse ;width:600px;height:960px;border-color:#111111;margin-left:.15in"  >
  <tr>
   <td  valign="top"  >
   <p class="MsoNormal_p_contract_new" style="text-indent: 0cm; page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;width: 380px;margin-top:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left;margin-top:1.0pt;margin-bottom:15.0pt; line-height :21px">
    Notices
    </span>&nbsp;
    </p>
    <p class="MsoNormal_p_contract_new" style="width: 330px;line-height :19px;margin-top:2.0pt">
    <span style="font-size :14px; font-family: Times New Roman;text-align:left">Any notices or other documents to be given or served under or in connection with this credit contract may be:
    </span>
    </p> 
   <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:1.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(a)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;Delivered personally to you (or, if you are a company,
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	&nbsp;&nbsp;
	</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp; to one of your directors);
    </span>
    </p>  
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(b)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;posted to or left at your residential last known to us;
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(c)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;posted to or left at the address shown in your credit
    </span>
    </p>
     <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt">
   &nbsp;&nbsp;&nbsp;&nbsp;
   <span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">contract;
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(d)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;sent by email to your email address last known to us 
    </span></p> 
     <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;&nbsp;&nbsp;&nbsp; (if you have consented as required by any <br />applicable law) or; 
    </span></p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:2.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(e)</span><span style="font-family: Times New Roman; color: windowtext;font-size :14px;line-height:17px">&nbsp;given in any other way permitted by law.
    </span>
    </p> 
    
   </td>
    <td >&nbsp;</td>
    <td style="width:320px" valign="top">
    <p class="MsoNormal_p_contract_new" style="width: 330px;margin-top:2.0pt">
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px">A notice may be signed by one or more of our employees, solicitors, or agents on our behalf.</span>
    </p>
     <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;width: 330px;text-align :left;margin-top:3.0pt">
    <span style="font-size :14px; font-family: Times New Roman"><b>Change of personal information</b></span></p> 
    <p class="MsoNormal_p_contract_new" style="margin-top:5.0pt ;width:350px">
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px">You must promptly inform us if your personal information changes ( eg change of residential address, phone number(s) or place of employment). You must, on request, provide any information about your personal or financial affairs that we reasonably request to enable us to assist in your performance of your obligations under this contract.</span></p>
    <p class="MsoNormal_p_contract_new" style="text-indent: 0cm; line-height: normal; page-break-after: avoid; margin-left: 0cm; margin-right: 0cm; margin-top:1.0pt;margin-bottom:1.0pt;width: 350px;">
    <span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700">
    General</span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="width: 355px;margin-top:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px;width: 355px">If there are 
    two or more of you, each of you is individually liable, and all of you are 
    jointly liable.&nbsp;References to a person includes companies and trusts and 
    any other kind of body.&nbsp;Singular words include plural words and vice versa.
    </span>
 	</p>
   
	</td>
  </tr>
</table>
<span style="font-size :small;color :Gray;margin-top:5.0pt">NETL </span><asp:Label ID="Label47" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
<p class="MsoNormal_p_contract_new"  style=" margin-top:5.0pt;margin-bottom:20.0pt;width: 755px;">
<asp:Label ID="Label29" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4 of&nbsp; 7</span></p>
<%--''''''''''''''''''''''''''''''''''''''''''''--%>
  
  <p>&nbsp;</p>
  <div style="page-break-after:always"></div>

<table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;width:600px;border-color:#111111" id="AutoNumber24">
 <tr>
 <td>
 <h1 style="text-align: left; margin-right: 0cm; margin-top: 5.0pt; margin-bottom:5.0pt;text-align : center;width:720px">
 <b>
 <span style="font-size: 20px; font-family: Times New Roman; text-align :center;text-decoration:underline">
 ACKNOWLEDGMENT</span></b></h1>
<span style="font-size :14px; font-family: Times New Roman">
                        You acknowledge the terms and conditions of this contract including the 
                        schedule, and agree to be bound by the terms and conditions of this contract. 
                        Make sure you understand the total costs of this loan including any fees payable 
                        to others. If you have any questions, ask before you sign this contract.</span></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>

</table>
 <table border="1" cellpadding="0" cellspacing="0" style="margin-left:11.0pt;border-collapse: collapse;border-color:#111111;width:520px;height:440px" id="AutoNumber34">
 <tr>
 <td >
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left:5.0pt;border-collapse: collapse;border-color:#111111;width:520px; height:430px" id="AutoNumber35">

 <tr><td colspan="2"><b>
 <span style="font-size :15px; font-family: Times New Roman;margin-top:3.0pt;margin-bottom:3.0pt;width: 560px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;IMPORTANT</span>
 </b>
 </td>
 </tr>
 <tr><td  colspan="2">&nbsp;</td></tr>
 <tr>
<td valign="top" style="width:220px">
<b><span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BEFORE YOU SIGN</span></b>
 </td>
 <td valign="top" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<b><span style="font-size :14px; font-family: Times New Roman ;width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; THINGS YOU 
 MUST KNOW</span></b>
 </td>
 </tr>
  <tr>
  <td valign="top" >
  <ul  >
  <li class="MsoNormal_p_contract_new" style=" text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
  <span style="font-size :14px; font-family: Times New Roman">READ THIS 
    CONTRACT DOCUMENT so that you know exactly what contract you are entering
     into and what you will have to do under the
     contract.</span>
   </li>
   <li class="MsoNormal_p_contract_new" style="text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
  <span style="font-size :14px; font-family: Times New Roman">
    You should also read the information statement:  </span>
   <br />
   <span style="font-size :14px; font-family: Times New Roman">
    &quot;<b>THINGS YOU SHOULD KNOW 
    ABOUT YOUR PROPOSED CREDIT CONTRACT&quot;</b></span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
    Fill in or cross out any blank spaces.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    Get a copy of this contract document.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <b><span style="font-size :14px; font-family: Times New Roman">Do not</span></b><span style="font-size :14px; font-family: Times New Roman"> 
 
    sign this contract document if&nbsp;there</span>
   <br />
   <span style="font-size :14px; font-family: Times New Roman"> is 
    anything you do not understand.</span>
   </li>
    </ul>
    </td>
    <td valign="top" >
    <ul>
    <li class="MsoNormal_p_contract_new" style="text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
        Once you sign this contract document, you&nbsp;will be 
        bound by it. However, you may end the contract before you obtain credit,or a 
        card or other means is used to obtain goods or services for which credit is to 
        be provided under the contract, by telling the credit provider in writing, but 
        you will still be liable for any fees or charges already incurred. 
    </span>
    </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt; text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    You <b>do not</b> have to take out consumer 
    credit insurance unless you want to. However, If this
     contract says so, you must take out
     insurance over<br /> any mortgaged property that is used as security, such as a 
        house or car.  </span>
   </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px"> 
    <span style="font-size :14px; font-family: Times New Roman">
    If you take out insurance, the credit 
    provider cannot insist on any particular
    insurance company.</span>
     </li>
     <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
    If this contract document says so, the 
    credit provider can vary the annual 
    percentage rate (the interest rate), the 
    repayments and the fees and charges and 
    can add new fees and charges without 
    your consent.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    If this contract document says so, the
    credit provider can charge a fee if you pay 
    out your contract early.</span>
    </li>
    </ul>
    </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;border-color:#111111;width:600px;height:50px" id="AutoNumber26" >
    <tr><td>&nbsp;</td></tr>
    <tr  style="font-size :14px; font-family: Times New Roman">
    <td valign="top" >I/we acknowledge receiving 
	<b>$<asp:Label ID="Label30" runat="server"></asp:Label>&nbsp;</b>in <asp:Label ID="Label31" runat="server"></asp:Label>.</td></tr>
	<tr><td>I/we acknowledge receiving a copy of the Contract.</td></tr>
    <tr><td>I/we acknowledge and accept the scanned documents as originals.
    </td>
    </tr> 
    <tr><td>&nbsp;</td></tr>
    </table>
    <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" style="margin-left:9.0pt;border-collapse: collapse;width:600px; height:212px">
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt; margin-top:5.0pt; margin-bottom:5.0pt;width:550px">
    <b><span style="font-size :14px; font-family: Times New Roman">Signed </span></b>
    <span style="font-size :14px; font-family: Times New Roman">by </span>
    </td>
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:300px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the presence of</span>     
    </td>
    </tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :14px; font-family: Times New Roman">
            ........................................................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px;font-size :14px; font-family: Times New Roman">
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           ................................................................................</td>
    </tr>
     <tr style="page-break-inside: avoid">
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
            
     <span style="font-size :14px; font-family: Times New Roman">&nbsp;Person receiving cash/loan </span>  
     </td>
     <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Signature of witness</span>     
    </td>
    </tr>
     <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
    <span style="font-size :14px; font-family: Times New Roman">
         ........................................................................ </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        .................................................................................</span></td>
    </tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;Print name</span></td>
    <td valign="top" style="width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Print name of witness</span></td>
    </tr>

    <tr>
    <td style="width:350px"></td>
    <td style="margin-top:5.0pt;font-family :Comic Sans MS;font-size :13px;width:390px" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label33" runat="server" Width="280px" ></asp:Label></td>
    </tr>
    <tr>
    <td  style="width:350px"></td>
    <td style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ..................................................................................</td>
    </tr>
    <tr>
    <td style="width:350px">&nbsp;</td>
    <td style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address of witness</td>
    </tr>
    <tr>
   <td style ="width:650px;text-align :left" class="MsoNormal_p_contract_new">
      &nbsp;
      Date of Credit Contract&nbsp; <asp:Label ID="Label39" runat="server"></asp:Label>
      <br />
      <br />
    <span style="font-size :small;color :Gray;margin-top:10.0pt">&nbsp; NETL </span><asp:Label ID="Label44" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label></td>
    <td>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </td>
     </tr>
     <tr><td>&nbsp;</td></tr>
     
     </table>
<p class="MsoNormal_p_contract_new"  style=" margin-bottom:20.0pt; width: 755px;">
 &nbsp; &nbsp;&nbsp; <asp:Label ID="Label38" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5 of&nbsp; 7</span></p>
<%--..............................................
--%>


<%--''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''--%>

<div style="page-break-after:always"></div>

    <p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
            <span style="font-family:Arial Black;font-size:14px">&nbsp;&nbsp;&nbsp; INFORMATION STATEMENT</span></p>
        <p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
            <span style="font-family:Arial Black;font-size:14px">&nbsp; THINGS YOU SHOULD KNOW ABOUT 
YOUR PROPOSED CREDIT CONTRACT</span> </p>
<p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
    &nbsp;</p>
    <p style="margin-top:0; margin-bottom:0;width:680px">
         <span style="font-family:Arial Narrow;font-size:14px;text-align:left ">&nbsp;&nbsp;&nbsp; 
         <b>This is a prescribed notice required by law and not all of the information will 
         apply to you.</b> This statement tells you about </span>
    </p>
         <p style="margin-top:0; margin-bottom:0;width:680px">
         <span style="font-family:Arial Narrow;font-size:14px;text-align:left ">&nbsp;&nbsp;&nbsp;&nbsp;some of the rights and obligations of yourself and your credit provider.</span>
    </p>
<p  style="margin-top:0; margin-bottom:0;width:680px">
<span style="font-family:Arial Narrow;font-size:14px">&nbsp;&nbsp;&nbsp;&nbsp;It does not state the terms and 
conditions of your contract.</span>
</p>
<p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
    &nbsp;</p>
<p  style="margin-top:0; margin-bottom:.15cm;width:700px">
<span style="font-family:Arial Narrow;font-size:14px">&nbsp;&nbsp;&nbsp;&nbsp; If 
    you have any concerns about your contract, contact your credit provider and, if 
    you still have concerns, your credit provider&#39;s  <br />
 &nbsp;&nbsp;&nbsp; &nbsp;external dispute resolution scheme, or get legal advice.
</span>
</p>
<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="font-family :Arial Narrow;font-size:12px"  >
 <span style="font-family: Arial Black; font-weight:700;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    THE CONTRACT</span>&nbsp;&nbsp;&nbsp;
 </td>
</tr>
</table>
<table border ="1" style="border-collapse: collapse;border-color:#000000;width:680px;margin-left:.15in">
<tr>
<td>
<table border ="0"  cellspacing="1" style="width:680px;margin-left:.15in" >
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px"> 
       1.&nbsp;How can I get details of my proposed credit contract?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your credit provider must give you a pre-contractual statement containing 
certain information about your contract. The pre-contractual</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; statement, and this document, must be given to you before- </td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; your contract is entered into; or </li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you make an offer to enter into the contract;<br/> 
</li>
</ul> 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;whichever happens first.  </td>
</tr>

<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px">2.&nbsp;How Can I get a copy of the final contract?</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;If the 
    contract document is to be signed by you and returned to your credit 
    provider, you must be given a copy to keep. Also, the credit
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;provider must give you a copy of the final contract within 
    14 days after it is made.&nbsp; This rule does not, however, apply, if the credit 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; provider has previously given you&nbsp; copy 
    of the contract document to keep. If you want another copy of your contract write to your credit  </td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;provider and 
    ask for one.Your credit provider may charge you a fee.&nbsp;Your credit provider has to give you a copy -</td>
</tr>

<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp; within 14 days of 
    your written request if the original contract came into existence 1 year or 
    less before your <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request; or
    </li>
<li>&nbsp;&nbsp;&nbsp;&nbsp; otherwise within 30 days of your written request.
</li>
</ul> 
</td>
</tr> 
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px">3.&nbsp;Can I terminate the contract?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes. You can terminate the contract by writing to the credit provider 
    so long as - 
</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;you have not obtained any credit under the contract; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a card or other means of obtaining credit given to you by your 
    credit provider has not been used to acquire goods or services for<br />&nbsp;&nbsp;&nbsp;&nbsp;which credit is to be provided under the contract.
</li>
</ul> 
</td>
</tr> 
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;However, you will still have to pay any 
    fees or charges incurred before you terminated the contract.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" 
         >4.&nbsp;Can I pay my credit contract out early?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.Pay your credit 
    provider the amount required to pay out your credit contract on the day
    you wish to end your contract.

</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">5.&nbsp;How can I find out the pay out figure?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can write to your credit provider at any time and ask for a statement of the pay out figure as at any date you 
    specify.&nbsp;
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can also ask for details of how the 
    amount is made up.&nbsp;
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your credit provider must 
    give you the statement within 7 days after you give your request to the credit 
    provider.You may&nbsp;be charged
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; a fee for the statement.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >6.&nbsp;Will I pay less interest if I pay out my contract early?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.The interest you can be 
	charged depends on the actual time money is owing.However, you may have to 
	pay an early termination

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; charge (if your contract permits your credit 
	provider to charge one) and other fees.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >7.&nbsp;Can my contract be changed by my credit provider?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes, 
    but only if your contract says so.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >8.&nbsp;Will I be told in advance if my credit provider is going to make a change in the contract?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;That depends on the type of change.&nbsp; 
    For example-
</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;You get at least same day notice for a change to an annual percentage rate.&nbsp; 
    That notice may be a written notice<br />&nbsp;&nbsp;&nbsp; to you or a notice published in a newspaper.
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;You get 20 days advance written notice for-
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a change in the way in which interest is calculated;
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a change in credit fees and charges; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;any other changes by your credit provider;
</li>
</ul> 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp; except where 
    the change reduces what you have to pay or the change happens
    automatically under the contract</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >9.&nbsp;Is there 
    anything I can do if I think that my contract is unjust?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.&nbsp;You should first talk 
    to your credit provider. Discuss the matter and see if you can come to some arrangement. If that is not successful
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you may contact your 
	credit provider's external dispute resolution scheme.External dispute resolution is a free service established to

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; provide you with an independent 
	mechanism to resolve specific complaints.You credit provider&#39;s external dispute resolution provider is the
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     Credit Ombudsman Service Limited and 
    can be contacted on 1800 
    138 422 or 02 9273 8400, by fax at 9273 8440, by email 
	at

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="mailto:info@cosl.com.au">info@cosl.com.au</a> or in writing to PO 
    Box A252 SYDNEY SOUTH 
    NSW 1235. Alternatively, you can go to 
    court. You may wish to get

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  legal advice, for example from your community legal centre or legal Aid. You can also contact ASIC, the 
	regulator, for information on
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1300 300 630 or through ASIC's website at http://www.asic.gov.au
</td>
</tr>
</table>
</td>
</tr>
</table>
<span style="font-size :small;color :Gray;margin-top:10.0pt">&nbsp;&nbsp;&nbsp;&nbsp; NETL </span><asp:Label ID="Label42" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
<p class="MsoNormal_p_contract_new"  style=" margin-bottom:10.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp; <asp:Label ID="Label34" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6 of&nbsp; 7</span></p>
<p>&nbsp;</p>
<%--.........................
--%>
<div style="page-break-after:always"></div>
<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="width:680px">
 <span style="font-family: Arial Black; font-weight:700;font-size :18px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;INSURANCE</span>&nbsp;&nbsp;&nbsp;
 </td>
</tr>
</table>
<table border ="1" style="border-collapse: collapse;border-color:#000000;width:680px;margin-left:.15in">
<tr>
<td>
<table border ="0"  cellspacing="1" style="width:680px" >
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">10.&nbsp;Do I have to take out insurance?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Your credit provider can insist you take out or pay the cost of types of insurance specifically allowed by law.These are compulsory third<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;party personal injury insurance, mortgage indemnity insurance or insurance over property covered by any mortgage.&nbsp; 
    Otherwise, you can<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;decide if you want to take out insurance or not. If you take 
    out insurance, the credit prvider can not insist that you use any particular<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;insurance company.</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">11.&nbsp;Will I get details of my insurance cover?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Yes, if you have taken out insurance over mortgaged property or consumer credit insurance and the premium is financed by your credit<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;provider. In that case the insurer must give you a copy of the policy with in 14 days after the insurer has accepted the insurance proposal.<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Also, if you acquire an interest in any such insurance policy which is taken out by your credit provider then, within 14 days of that<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;happening, your credit provider must ensure you have a written notice of the particulars of that insurance.<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;You can always ask the insurer for details of your insurance contract. If you ask in writing your insurer must give you a statement<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;containing all the provisions of the contract.</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">12.&nbsp;If the 
    insurer does not accept my proposal, will I be told?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Yes, if the insurance was to be financed by the credit contract. The insurer will inform you if the proposal is rejected .</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">13.&nbsp;In that 
    case, what happens to the premiums?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Your credit provider must give you a refund or credit unless the insurance is to be arranged with another insurer.</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">14.&nbsp;What 
    happens if my credit contract ends before any insurance contract over mortgaged<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; property?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;You can end the insurance contract and get a proportionate rebate of any premium from the insurer.</td>
</tr>
</table> 
</td> 
</tr> 
</table> 
<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="width:680px">
 <span style="font-family: Arial Black; font-weight:700;font-size :18px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GENERAL</span>&nbsp;&nbsp;&nbsp;
 </td>
</tr>
</table>
<table border ="1" style="border-collapse: collapse;border-color:#000000;width:680px;margin-left:.15in">
<tr>
<td>
<table border ="0"  cellspacing="1" style="width:680px" >
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">15.&nbsp;What do I do if I cannot make a repayment?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Get in touch with your 
    credit provider immediately.&nbsp; Discuss the matter and see if you can come to 
    some arrangement.You can ask your

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   credit provider to change your contract 
    in a number of ways:-

</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px">
<li>&nbsp;&nbsp;&nbsp;&nbsp;to extend the term of the contract and reduce the payments; or 
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;to 
    extend the term of your contract and delay payments for a set time; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;to delay payments for a set time.
</li>
</ul>
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">16.&nbsp;What if my credit provider and I cannot agree on a suitable arrangement?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;If the credit provider 
    refuses your request&nbsp; to change the repayment, you can ask the credit provider 
    to review this decision if you think it is 

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;wrong. 
    
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;if the credit provider still refuses your 
	request you can complain to the external dispute resolution scheme that your credit

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;provider belongs to. Further details about this scheme are set out 
	below in question 18.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">17.&nbsp;Can my credit provider take action against me?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Yes, if you are in default 
    under your contract.&nbsp; But the law says that you cannot be unduly harassed or threatened for repayments.
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;If you think you are being unduly harassed or 
    threatened, contact the credit provider's external dispute resolution scheme or ASIC, 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;or get legal advice.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">18.&nbsp;Do I have any other rights and obligations?
</td>
</tr>
<tr>
<%--<td style="font-family :Arial Narrow;font-size:13px">Yes. The law will give you other rights and obligations. You should also<b> READ YOUR CONTRACT </b>carefully.</td>--%>
<td style="font-family :Arial Narrow;font-size:13px"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   IF YOU HAVE ANY COMPLAINTS ABOUT YOUR CREDIT CONTRACT, OR WANT MORE INFORMATION, CONTACT YOUR <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   CREDIT PROVIDER.
  YOU MUST ATTEMPT TO RESOLVE YOUR COMPLAINT WITH YOUR 
	CREDIT PROVIDER BEFORE <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   CONTACTING YOUR CREDIT PROVIDER'S EXTERNAL 
	DISPUTE RESOLUTION SCHEME. IF YOU HAVE A COMPLAINT <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   WHICH REMAINS UNRESOLVED 
	AFTER SPEAKING TO YOUR CREDIT PROVIDER YOU CAN CONTACT YOUR CREDIT <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   PROVIDER'S EXTERNAL DISPUTE RESOLUTION SCHEME 
	OR GET LEGAL ADVICE. EXTERNAL DISPUTE RESOLUTION IS A<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   FREE SERVICE ESTABLISHED TO 
	PROVIDE YOU WITH AN INDEPENDENT MECHANISM TO RESOLVE SPECIFIC<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   COMPLAINTS. 
	YOUR CREDIT PROVIDER'S EXTERNAL DISPUTE RESOLUTION PROVIDER IS THE 
	CREDIT OMBUDSMAN<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   SERVICE LIMITED AND CAN BE CONTACTED ON 1800 138 422 OR 02 
	9273 8400, BY FAX AT 9273 8440, BY EMAIL AT<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
	<a href="mailto:INFO@COSL.COM.AU">INFO@COSL.COM.AU</a> OR IN WRITING TO PO 
	BOX A252 SYDNEY SOUTH NSW 1235.PLEASE KEEP THIS INFORMATION<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   STATEMENT.YOU 
    MAY WANT SOME INFORMATION FROM IT AT A LATER DATE.</b>
</td>

</tr>
</table> 
</td> 
</tr>
</table>


<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>

<span style="font-size :small;color :Gray">&nbsp;&nbsp;&nbsp; NETL </span><asp:Label ID="Label43" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
<p class="MsoNormal_p_contract_new"  style="margin-top:5px; margin-bottom:20.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label35" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7 of&nbsp; 7</span></p>
<p>&nbsp;</p>

<%--
'''''''''''''''''''''''''''''''''''''''''''''new page--%>
</asp:Panel>

<asp:Panel ID="P2" runat="server" Visible ="false" >
<br />
 <table class="MsoTableGrid"  cellspacing="0" cellpadding="0" style="border:1px solid #000000; border-collapse: collapse; margin-left:.15in;width:700px">

 <tr class="part_tr">
 <td  valign="top" class="td_part" style="height:70px" >
 
 <span class="part_font_contract"> Borrowers Please Note</span> <br />
<span class="part_font_contract">We recommend that you obtain legal and financial advice in relation to this loan.</span>
<br />

 <span class="part_font_contract">If you repay early, deferred establishment fees may apply.Deferred establishment fees may be significant. Please read the details below carefully.
 </span>

 </td>
 </tr>
 </table>
 <table class="MsoTableGrid"  cellspacing="0" cellpadding="0"  style="margin-left:.15in;width:700px">
 <tr>
 <td  class="td_top_part" style="width:1301px;text-align :justify">
 <p style="color:#000000; font-size :16px"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OFFER AND PERSONAL LOAN CONTRACT</b></p>
 </td>
 </tr>
 <tr>
 <td>
 <span class="font_p_contract">We,&nbsp;&nbsp;&nbsp; Abaz Pty Ltd  A.C.N 118 434 021&nbsp;Australian Credit Licence 391104 (&quot;us / we&quot;) of</span> 
 </td>
 </tr>
 <tr>
 <td>
 <span class="font_p_contract">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; First Floor 15 Campbell Street, Blacktown NSW 2148</span>
 </td>
 </tr>
 <tr><td class="font_p_contract">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tel:&nbsp;<asp:Label ID="Label_20" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fax:&nbsp;<asp:Label ID="Label_21" runat="server"></asp:Label></td></tr>
 <tr>
 <td>
 <p>
 <span class="font_p_left_contract">offer the Borrower 
 named in the schedule below, a loan of the amount specified in the schedule on 
 the terms and conditions set out in this Offer and Personal Loan Contract.&nbsp;
 </span>
 </p>
 </td>
 </tr>
 <tr><td class="font_p_contract"><span class="part_font_contract">SIGNED </span>
 <span class="font_p_contract">by</span>
 <span class="part_font_contract"> the Authorised Officer of the credit &nbsp;<br />
     provider </span>
 </td>
 </tr> 
 <tr><td>&nbsp;</td></tr>
 <tr><td>&nbsp;</td></tr>
 <tr><td>
 <p style="font-size :14px"><b><asp:Label ID="Label_2" runat="server" Text="The Borrower's details:" Visible ="false" ></asp:Label></b></p>
     </td></tr>

 </table>
 <table  class="MsoTableGrid"  cellspacing="0" cellpadding="0" style="margin-left:.15in;width:755px">
 <tr><td></td></tr>
 <tr>
 <td  style="width:49%">
 &nbsp;.........................................................................</td>
 <td style="width:60%">
 &nbsp;........................................................................</td>
  </tr>
 <tr>
 <td style="width:49%">
 <span class="font_p_contract">Print name</span>
 </td>
 <td style="width:60%"><span class="font_p_contract">Signature</span></td>
 </tr>
 </table>
 <br />
 <br />
 <span style="font-family:Times New Roman;font-weight:700">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size :14px">SCHEDULE</span>
 </span>
 <p style="font-size :14px"><b><asp:Label ID="Label_1" runat="server" Text="The Borrowers' details:" Visible ="false" ></asp:Label></b></p>
 <table border="0" width="658px"  cellpadding="0" cellspacing="0" style="border-collapse: collapse;margin-left:5; border-color:#111111;height:78px" id="Table3">
 <tr>
 <td style="width:355px">
 <table border="0" cellpadding="0" cellspacing="2" style="border-collapse: collapse;margin-left:5;border-color:#111111"  width="88%" id="Table4">
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_3" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_4" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_5" runat="server"></asp:Label>&nbsp;</span>
 </td>
 </tr>
 <tr>
 <td style="width:95%">
 <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_6" runat="server"></asp:Label></span></td>
 </tr>
 </table>
 </td>
 <td style="width:303px"> 
    <table border="0" cellpadding="0" cellspacing="2" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="95%" id="Table5">
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_7" runat="server" ></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_8" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_9" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
    <td style="width:100%">
    <span style="font-size :14px">&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_10" runat="server" ></asp:Label></span></td>
    </tr>
   </table>
   </td>
   </tr>
   </table>
   <br />
   <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="88%" id="Table6">
   <tr>
   <td style="width:54%">
	<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-left:5;border-color:#111111" width="82%" id="Table7">
	<tr>
	<td style="width:44%">
 	<span style="font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;Customer No:&nbsp;<asp:Label ID="Label_11" runat="server" ></asp:Label></span></td>
 	</tr>
	</table>
    </td>
    <td style="width:46%">
    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;margin-left:5;border-color:#111111" width="67%" id="Table8">
	<tr>
    <td style="width:56%"><span style="font-size :14px">&nbsp;&nbsp;&nbsp;Loan No:&nbsp;<asp:Label ID="Label_12" runat="server" ></asp:Label></span></td>
	</tr>
	</table>
    </td>
    </tr>
    </table> 
    <p style="margin-top:18.0pt;margin-bottom:10.0pt">
        <b><span style="font-size :14px;font-family: Times New Roman">Financial Table prepared as at &nbsp;<asp:Label ID="Label_13" runat="server"></asp:Label>&nbsp;("Disclosure Date")</span>
   </b>
   </p>
   
   <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" style="border-style:none; border-color:inherit; border-collapse: collapse; height :354px ;width:550px" >
   <tr>
   <td style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: 1.5pt double windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 250px">
   <span style="font-size :14px; font-family: Times New Roman">Amount of credit</span>
   </p>
   </td>
   <td  style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: 1.5pt double windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm; height:30px">
   <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse;border-color:#111111" width="60%" id="Table9">
   <tr>
   <td style="width:250px" valign="bottom">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt">
   <span style="font-size :14px; font-family: Times New Roman"><b>$<asp:Label ID="Label_14" runat="server"></asp:Label></b></span></p>
   </td>
   </tr>
   </table>
   </td>
   </tr>
   <tr>
   <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm ; height:30px">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
   <span style="font-size :14px; font-family: Times New Roman">Total amount of repayments</span>
   </p>
   </td>
   <td  style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm; height:30px">
   <table border="0" cellpadding="0" cellspacing="1" style="border-collapse: collapse;border-color:#111111"  width="60%" id="Table10">
   <tr>
   <td style="width:250px" valign="bottom">
   <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt">
   <span style="font-size :14px; font-family: Times New Roman"><b>$<asp:Label ID="Label_15" runat="server"></asp:Label></b></span></p>
  </td>
  </tr>
  </table>
  </td>
  </tr>
  <tr>
  <td valign="middle" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman">Repayment type</span>
  </p>
  </td>
  <td valign="middle" style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 250px">
  <span style="font-size :14px; font-family: Times New Roman">Principal and fee repayments</span>
  </p> 
  </td>
  </tr>
  <tr>
  <td valign="middle" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt ; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman">Number of repayments</span>
  </p>
  </td>
  <td valign="middle" style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt">
  <span style="font-size :14px; font-family: Times New Roman"><asp:Label ID="Label_16" runat="server" ></asp:Label></span>
  </p> 
  </td>
  </tr>
  <tr>
  <td style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman">First 
  repayment date</span>
  </p> 
  </td>
  <td style="width: 379px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 400px">
  <span style="font-size :14px; font-family: Times New Roman">
  One month from the date we provide the loan. The date we provide the loan is called the &quot;Loan Date&quot;</span> 
  </p>
  </td>
  </tr>
  <tr>
  <td style="width:210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom:0cm;height:30px"  valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 250px">
  <span style="font-size :14px; font-family: Times New Roman">Repayment period and amount</span>
  </p> 
  </td>
  <td style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px" valign="top">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 420px">
  <span style="font-size :14px; font-family:Times New Roman ">$<asp:Label ID="Label_17" runat="server"></asp:Label>&nbsp;each month, commencing 
  one month after the loan date. </span>
  </p> 
  </td>
  </tr> 
  <tr>
  <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:76px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width: 220px">
  <span style="font-size :14px; font-family: Times New Roman">Credit fees and charges </span>
  </p> 
  </td>
  <td valign="top" style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:76px">
  <p class="MsoNormal_p_contract_new" style="margin-top:2.0pt; margin-bottom:2.0pt; width:400px">
  <span style="font-size :14px; font-family: Times New Roman">You must pay 
    us on demand, the following credit fees and charges.These fees and charges 
    are payable when the service is provided or the expense incurred unless 
    otherwise specified. Unless otherwise stated all fees are non-refundable.
  </span>
  </p> 
  </td>
  </tr>
  <tr>
  <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 3px double #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:40px">
 <span style="font-size :14px">Credit</span><span style="font-size :14px; font-family: Times New Roman"> 
   Fee payable monthly in arrears on the same day each month as the Loan Date</span>
 </td>
   <td valign="top" style="width: 379px; border-left: medium none; border-right: 1.5pt double #000000; border-top: 1px solid #000000; border-bottom: 3px double #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:40px">
   <span style="font-size :14px; font-family: Times New Roman">$<asp:Label ID="Label_18" runat="server"></asp:Label></span></td>
   </tr>
   </table>
   <br />
 <span style="font-size :small;color :Gray">NETL </span><asp:Label ID="Label_36" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
 <p class="MsoNormal_p_contract_new"  style="margin-top:10.0pt; margin-bottom:20.0pt; width: 755px">
  <asp:Label ID="Label_19" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1 of&nbsp; 9</span>
  </p>
  <p>&nbsp;</p>
  
  <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" style="border-style:none; border-color:inherit; border-collapse: collapse; height :965px ;width:600px" >
  <tr>
   <td valign="top" style="width:250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: 1.5pt double windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:250px">
    <p class="MsoNormal_p_contract_new" >
    
    <span style="font-size :14px; font-family: Times New Roman;width: 250px">Deferred Establishment Fee</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: 1.5pt double windowtext; border-right: 1.0pt solid #000000; border-top: 1px solid #000000; border-bottom: 3px double #000000;height: 250px;width:400px">
    <p class="MsoNormal_p_contract_new" style="width:400px">
    <span style="font-size :14px;width:400px;margin-top:1.0pt; margin-bottom:1.0pt">You have not been charged the full cost of 
	setting up your loan.</span></p>
        <p class="MsoNormal_p_contract_new" style="width:400px">
            <span style="font-size :14px;width:400px;margin-top:1.0pt; margin-bottom:1.0pt">If, before <asp:Label ID="Label22" runat="server"></asp:Label>
            &nbsp;months from the Loan Date have passed, you repay more than the scheduled 
            monthly payments then a Deferred Establishment Fee will apply as follows. 
	</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="width:400px;margin-top:5.0pt; margin-bottom:3.0pt" >
	<span style="font-size :14px">
	If yor repay from 76% to 100% of the amount of credit within this time then we will charge you $<asp:Label ID="Label_24" runat="server"></asp:Label>&nbsp;(the full Deferred Establishment Fee)</span>
	</p>
	
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:5.0pt; margin-bottom:3.0pt" >
	<span style="font-size :14px">If you repay up to 75% of the amount of credit within this time then we will charge you a pro rata Deferred Establishment Fee according to the proportion of the amount of credit you repay. For example, if you repay 50% of the amount of credit on a day less than <asp:Label ID="Label_23" runat="server"></asp:Label>  months after the Loan Date, in addition to your scheduled monthly payments, then we will charge you $<asp:Label ID="Label23" runat="server"></asp:Label>&nbsp;(being 50% of the Deferred Establishment Fee). 
	</span></p>
  
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:5.0pt; margin-bottom:3.0pt">
	<span style="font-size :14px">Deferred Establishment fees are payable if you repay early for any reason , including because of a demand by us after default.
	</span> 
	</p>
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:5.0pt; margin-bottom:3.0pt">
	<span style="font-size :14px">You should note that if you repay the loan early 
	you may pay less than if you keep the loan for the entire 
	term.</span>
	</p>
	</td>
   </tr>
   <tr>
   <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm;padding-bottom:0cm; height:45px">
    <p class="MsoNormal_p_contract_new" style="width: 220px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px">Direct debit variation fee</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 45px; width:400px">
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt" >
    <span style="font-size :14px; font-family: Times New Roman">$50.00 </span>
	<span style="font-size :14px">payable if you request a change or require a 
	change to your direct debit and or payment arrangements with us.</span>
	</p>
	</td>
   </tr>
   <tr>
    <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:60px">
    <p class="MsoNormal_p_contract_new" style="width: 220px;margin-top:1.0pt; margin-bottom:1.0pt" >
    <span style="font-size :14px; font-family: Times New Roman">Government 
    charges</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 60px;width:400px">
         
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">If government 
    charges or duties are payable in respect of this Contract, we may debit 
    these to your account any time after they are incurred.</span>
    </p>
    </td>
    </tr>
        <tr>
    <td valign="top" style="width: 280px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px">
     <p class="MsoNormal_p_contract_new" style="width: 280px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">If you request an 
    additional copy of a statement</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 30px;width:400px">
    <p class="MsoNormal_p_contract_new" style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">$5.00 per additional 
        statement</span></p>
    </td>
    </tr>
        <tr>
    <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
     <p class="MsoNormal_p_contract_new" style="width: 250px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">If you request a credit 
         reference report</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; height: 30px;width:400px" >
               
    <p class="MsoNormal_p_contract_new" style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">$10.00 per report</span></p>
    </td>
    </tr>
    <tr>
    <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
     <p class="MsoNormal_p_contract_new" style="width: 250px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">If you request a variation to your loan agreement</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 30px;width:400px">
          
    <p class="MsoNormal_p_contract_new" style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">$50.00 per variation</span>
    </p>
    </td>
    </tr>
    <tr>
  <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px">
    <p class="MsoNormal_p_contract_new" style="width: 220px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">Dishonour fee</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 45px;width:400px">
            
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">$30.00 for each 
    dishonoured payment.&nbsp; This fee is only payable 
    </span>
   <span style="font-size :14px; font-family: Times New Roman">when a payment is 
    dishonoured.&nbsp;
    </span>
    </p>
    </td>
    </tr>
    <tr>
    <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:45px">
    <p class="MsoNormal_p_contract_new" style="width: 220px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">Cheque 
    dishonour fee</span>
    </p>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;height: 45px;width:400px">
          
    <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
    <span style="font-size :14px; font-family: Times New Roman">$30.00&nbsp;This fee 
        is payable whenever you present a cheque </span>
    </p>
        <p class="MsoNormal_p_contract_new"  style="width:400px;margin-top:1.0pt; margin-bottom:1.0pt">
            <span style="font-size :14px; font-family: Times New Roman">which is 
            dishonoured.</span>
    </p>
    </td>
   </tr>
   <tr>
   <td valign="top" style="width: 300px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:60px">
    
    <span style="font-size :14px; font-family: Times New Roman">Total fees and 
    charges assuming the loan runs for the entire term<b>
    </b>
	</span>
    <span style="font-size :14px; font-family: Times New Roman">(excluding 
    unascertainable and contingent amounts)</span>
   </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext;  height: 60px;width:400px">
    <span style="font-size :14px; font-family: Times New Roman">$<asp:Label ID="Label_25" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
    <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:40px">
    <p class="MsoNormal_p_contract_new" style="width: 220px" >
    <span style="font-size :14px; font-family: Times New Roman">Enforcement 
    expenses</span>
    </p> 
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; margin-top:1.0pt; margin-bottom:1.0pt;height:40px;width:400px">
            
    <p class="MsoNormal_p_contract_new"  style="width:400px">
    <span style="font-size :14px; font-family: Times New Roman">These fees are 
    payable if you default on your loan and we must take steps to enforce the 
    loan.</span>
    </p> 
    </td>
    </tr>
    <tr>
    <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:60px">
   
    <span style="font-size :14px; font-family: Times New Roman">Enforcement 
    notification letter</span>

    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; margin-top:1.0pt; margin-bottom:1.0pt;height: 60px;width:400px">
    <span style="font-size :14px; font-family: Times New Roman">$20.00 for each 
    and every default notification letter we send you to enforce the loan.&nbsp; This 
    fee is only payable when we send you a enforcement notification letter.</span>

    </td>
    </tr>
    <tr>
    <td valign="top" style="width: 210px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:50px">
    <span style="font-size :14px; font-family: Times New Roman">Notice of default letter</span>
    </td>
    <td valign="top" style="padding: 0cm 5.4pt; border-left: medium none; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; margin-top:1.0pt; margin-bottom:1.0pt;height:50px;width:400px">
    <span style="font-size :14px; font-family: Times New Roman">$50.00 for the 
    final letter of demand we send you to enforce the loan.&nbsp; This fee is only 
    payable when we send you notice of default letter.</span>

    </td>
  </tr>
   <tr>
    <td colspan="2" valign="top" 
           style="padding: 0cm 5.4pt; border-left: 1.5pt double windowtext; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.0pt solid windowtext; height:40px">
  
    <span style="font-size :14px; font-family: Times New Roman;width:400px">If you default at any time,we may elect not to charge default fees at that time.However,in these cases</span>
        
            <span style="font-size :14px; font-family: Times New Roman;width:400px">we reserve the right to charge default fee at a later time,including after the loan is repaid in full.</span>

    </td>
  
  </tr>
  <tr >
    <td colspan="2" valign="top" 
          style="width:800px;padding: 0cm 5.4pt; border-left: 1.5pt double windowtext; border-right: 1.5pt double windowtext; border-top: medium none; border-bottom: 1.5pt double windowtext; height:80px; font-size:14px; font-family:Arial Narrow;">
    <b>We can change any of the financial information 
    described above without your consent, including the fees and charges, the 
    amount of repayments, the dates for debiting interest and the dates for 
    making repayments, and interest rates (except during a fixed rate term).<br />
    We may introduce new fees and charges without your consent.</b>
    
    </td>
  </tr>
  </table>
   <span style="font-size :small;color :Gray">&nbsp;NETL </span><asp:Label ID="Label_40" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
  <p class="MsoNormal_p_contract_new"  style=" margin-top:10.0pt; margin-bottom:20.0pt;width: 755px;">
  <asp:Label ID="Label_26" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2 of&nbsp; 9</span></p>
  <p>&nbsp;</p>

  
  <p>
<span style="font-size :14px; font-family: Times New Roman">
<b>&nbsp;&nbsp; Other terms and conditions</b></span>
</p>
<table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" style="border-style:none; border-color:inherit; border-collapse: collapse; height :158px ;width:640px" >
    <tr>
    <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:40px">
    <p class="MsoNormal_p_contract_new" 
            style="page-break-after: avoid;margin-top:4.0pt; margin-bottom:6.0pt;width:220px; height: 17px;">
    <span style="font-size :14px; font-family: Times New Roman">Loan purpose</span>
    </p> 
    </td>
    <td valign="top" style="width: 389px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: 3px double #000000; border-bottom: 1.0pt solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:40px">
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:6.0pt; margin-bottom:4.0pt;width:400px">
    <span style="font-size :14px; font-family: Times New Roman">The purpose of the loan is to...........................................................</span>
    </p>
    </td>
    </tr>
    <tr>
    <td valign="top" style="width: 250px; border-left: 1.5pt double windowtext; border-right: 1.0pt solid windowtext; border-top: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
    <p class="MsoNormal_p_contract_new" 
            style="page-break-after: avoid;margin-top:4.0pt; margin-bottom:4.0pt;width:220px; height: 17px;">
    <span style="font-size :14px; font-family: Times New Roman">Loan term</span>
    </p> 
    </td>
    <td valign="top" style="width: 389px; border-left: medium none; border-right: 1.5pt double windowtext; border-top: 3px double #000000; border-bottom: 1.0pt solid #000000; padding-left: 5.4pt; padding-right: 5.4pt; padding-top: 0cm; padding-bottom: 0cm;height:30px">
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:4.0pt; margin-bottom:4.0pt;width:400px">
    <span style="font-size :14px; font-family: Times New Roman">25 months</span>
    </p>
    </td>
    </tr>
    <tr>
    <td valign="top" 
            style="padding: 0cm 5.4pt; border-bottom: 1.5pt double windowtext; border-left: 1.5pt double windowtext; border-right: 1px solid #000000; border-top: 1.0pt solid #000000" >
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:220px">
    <span style="font-size :14px; font-family: Times New Roman">Payment of 
    loan</span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:220px">
        &nbsp;</p>
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:220px">
        &nbsp;</p> 
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:220px">
    <span style="font-size :14px">Special conditions</span>
    </p> 
    </td>
    <td valign="top" 
            style="padding: 0cm 5.4pt; border-bottom: 1.5pt double windowtext; border-left: 1px solid #000000; border-right: 1.5pt double windowtext; border-top: 1.0pt solid #000000" >
    <p class="MsoNormal_p_contract_new" style="page-break-after: avoid;margin-top:2.0pt; margin-bottom:2.0pt;width:420px">
   <span style="font-size :14px; font-family: Times New Roman">As at the 
    Disclosure Date, we understand your loan will be paid to you or as you 
	direct either in cash, or by credit to your bank account using the details 
	provide.</span>
	</p> 
	</td>
  </tr>
  </table>
 <p style="font-size :14px;margin-top:2.0pt; margin-bottom:2.0pt;width:680px">We reserve the right to 
withdraw from this Loan Contract if this offer is not accepted within 14 days 
from <br />the Disclosure Date or if anything occurs which in 
our opinion, acting reasonably, makes settlement undesirable.</p> <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>

<p> <span style="font-size :small;color :Gray">NETL </span><asp:Label ID="Label_41" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label></p>
<p class="MsoNormal_p_contract_new"  style="margin-top:5.0pt; width: 755px;">
<asp:Label ID="Label_27" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 of&nbsp; 9</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<table border="0"  cellpadding="0" cellspacing="1" style="border-collapse: collapse ;width:600px;border-color:#111111 ;margin-left :.15in" id="Table11" >
 
  <tr>
    <td  style ="width:641px" valign="top" colspan="2" >
    <span style="font-size :18px;background-color:#FFFFFF;font-weight:bold;font-family:Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TERMS AND CONDITIONS OF CREDIT CONTRACT
    </span>
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td valign="top" style="height: 900px">
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm;margin-bottom: .0001pt; width: 116px;">
    <b><span style="font-family: Times New Roman;font-size :14px">1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span style="font-family: Times New Roman;font-size :14px;width: 350px">
	Repayments</span></b>&nbsp;</p> 
    <p class="MsoNormal_p_contract_new" style=" text-align:left;width:370px;margin-top:2.0pt; margin-bottom:2.0pt" >
    <span style="font-family: Times New Roman;font-size :14px">You must make 
    all payments on the due date.&nbsp;
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style=" text-align:left; width: 330px;margin-top:5.0pt; margin-bottom:5.0pt" >
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px ">Repayments are to 
    be made by direct debit from your bank account or such other way as we 
    agree or specify. You must sign any forms required by us to 
    effect repayments. The amount of each repayment will 
    not include any applicable direct debit fees, or similar taxes or charges.
    Until the term has expired and all amounts owing to us 
    have been paid, you must maintain an account with direct 
    debit and or credit authorisation to us. Payments will be credited to you only when actually received by us.
    </span>

    </p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px; line-height:17px">If any 
    repayment is due to be made on a day which is not a Business Day, the 
    repayment must be made on the next business day.
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 340px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px;margin-top:7.0pt;margin-bottom:7.0pt">If 
	any direct debit or cheque used for repayment is dishonoured, the repayment 
	will be treated as not having been made, and interest will continue to accrue on the 
    unpaid daily balance until actual payment is received by us.
    </span>
    </p>
   
	<p class="MsoNormal_p_contract_new" style="text-align:left;width:330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px; line-height:17px;margin-top:7.0pt;margin-bottom:7.0pt">If you have more than one account with us and 
	you make a payment without telling us writing how the payment is to be 
	applied, we can apply it to any one or more of the accounts in any way we 
	think fit.
	</span>
	</p> 
	   
	<p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px;margin-top:7.0pt;margin-bottom:7.0pt">We do not pay interest on any credit balance 
	in your account.
	</span>
	</p> 
	  
	<p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;margin-bottom:7.0pt;margin-top:7.0pt">If you have more than one account with us and one of those accounts is in arrears, we can apply funds from one account to cover the amount in arrears in the other account.
    </span>
	</p> 
	<p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm; margin-top:3.0pt; margin-bottom: .0001pt">
    <b><span style="font-family: Times New Roman;font-size :14px">2.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span style="font-family: Times New Roman;font-size :14px;width: 350px">
	Payments</span></b>&nbsp;</p> 
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px; text-align :justify">The Amount Borrowed will be paid to you in cash.&nbsp;
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm; margin-top:1.0pt; margin-bottom: .0001pt">
    <b><span style="font-family: Times New Roman;font-size :14px">3.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span style="font-family: Times New Roman;font-size :14px;width: 350px">
	Default</span></b>&nbsp;</p> 
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height :19px;margin-top:7.0pt;margin-bottom:7.0pt"><b>When 
	there is default&nbsp;</b>
    </span>
    </p> 
	<p class="MsoNormal_p_contract_new" style="margin-right:0cm;margin-bottom:0cm; margin-left:1.7pt;margin-bottom:.0001pt;line-height:normal;width: 350px">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">If any one or 
	more of the following occur we may decide default has occurred. You must 
	ensure<br /> default does not occur.</span>
	</p> 
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm; width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(a)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">There 
	is default of any term or condition of this &nbsp; loan agreement.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(b)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">You 
	fail to pay any person (including us and/or other lenders etc) any money by 
	the due date.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(c)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">Any 
	representation made by you to our agents or <br />us proves to be untrue or 
	misleading.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;  margin-bottom: .0001pt;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(d)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext">You 
	become bankrupt or are jailed.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;  margin-bottom: .0001pt;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(e)</span><span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman; color:windowtext; font-size :14px">&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext; text-align :justify">You 
	breach any material undertaking given at <br />any time to us.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="margin-left:0cm;margin-bottom:.0001pt;text-indent:0cm; text-align:justify;line-height:normal;page-break-after:avoid;margin-top:5.0pt; margin-bottom:5.0pt">
    <b>
    <span style="font-family: Times New Roman;font-size :14px;width: 330px">Our 
	rights on default</span></b>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman; color: windowtext;font-size :14px; line-height :19px">
    At any time after default occurs, we can take 
	any of the following actions after giving any notice
	</span>
	</p>
	</td> 
    <td valign="top">
    <p class="MsoNormal_p_contract_new" style="text-align:left; width: 350px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;line-height:17px;">required by law and, if required by law, the period 
	specified in the notice has passed and the default has not been rectified.
	</span>
	</p> 

    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt;text-align:left; margin-right: 0cm;width: 330px;margin-bottom:1.0pt;margin-top:1.0pt">
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(a)</span> <span style="font-family: Times New Roman; color: windowtext;font-size :14px">Demand and require immediate payment of any money<br /> due under this loan 
    agreement.
    </span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height:21px; margin-left: 17.85pt; margin-right: 0cm;text-align:left;width: 330px;margin-bottom:1.0pt;margin-top:1.0pt" >
    <span style="font-family:Times New Roman;font-size :14px;text-align:left">
	(b)</span>
        <span style="font-family: Times New Roman; color: windowtext;font-size :14px">Call up the loan and require payment of the entire balance owing under this 
     loan agreement.
    </span>
    </p>
   
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height:17px;width: 330px">We can take 
    action even if we do not do so promptly after the default occurs so long as 
	the default remains unrectified and we have given appropriate notice.&nbsp;
   </span>
   </p>
    <p class="MsoNormal_p_contract_new" style="page-break-after:avoid;width: 350px;margin-top:5.0pt; margin-bottom:5.0pt"><b>
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height:17px">Enforcement 
    expenses</span>&nbsp;</b>
    </p> 
  
    <p class="MsoNormal_p_contract_new"  style="text-align:left;width: 335px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">Enforcement 
    expenses may become payable under the loan agreement if you default. You 
    must pay on demand and we may debit your account with our costs in 
    connection with any exercise or non exercise of rights arising from any 
    default, including:</span></p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;text-align:left;font-size :14px;text-align:left;width: 300px" >
	(a)<span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman;font-size :14px">&nbsp;&nbsp;</span><span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">legal costs and expenses on a full indemnity basis or solicitor and own 
    client basis, whichever is higher;</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;text-align:left;font-size :14px;text-align:left;width: 330px" >
	(b)<span style="font-style:normal; font-variant:normal; font-weight:normal; font-family:Times New Roman;font-size :14px">&nbsp;&nbsp;</span><span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">our internal costs.
    </span>
    </p>
   <p class="MsoNormal_p_contract_new" style="margin-bottom:1.0pt;margin-top:1.0pt;width: 330px" >
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :19px">These costs 
    will not exceed our reasonable enforcement costs including internal costs.</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -35.45pt; page-break-after: avoid; margin-left: 35.45pt; margin-right: 0cm;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <b><span style="font-family: Times New Roman;font-size :14px">4.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span style="font-family: Times New Roman;font-size :14px;text-align:left;line-height :21px">
	General matters</span></b>&nbsp;
	</p> 

    <p class="MsoNormal_p_contract_new" style="page-break-after:avoid;width: 380px;margin-top:5.0pt; margin-bottom:5.0pt"><b>
    <span style="font-family: Times New Roman;font-size :14px;text-align:left; line-height :21px">Payments</span></b>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-family: Times New Roman; color: windowtext;font-size :14px;text-align:left;line-height :19px">
    You must make payments without deducting or setting off any money you think 
    we owe you for any reason.</span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: 0cm;page-break-after: avoid; margin-left: 0cm; margin-right: 0cm">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left;line-height :19px">
	Lender's certificate</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 330px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman; color: windowtext;text-align:left;line-height :19px">A certificate signed by or on behalf of us as to an amount payable to us 
	is conclusive and binding on you in the absence of manifest error. In 
	providing any certificate, we will act reasonably.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: 0cm;page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;width: 360px">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left; line-height :19px">
	How we can deal with this loan agreement</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-align:left;width: 350px;line-height :19px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-size :14px;font-family: Times New Roman; color: windowtext;text-align:left">or otherwise deal with its rights under this loan agreement in any way it 
	wishes. You must sign anything and do anything we reasonably require to 
	enable any dealing with this loan agreement.&nbsp; Of&nbsp; course, any dealing with 
	our rights does not change your obligations under this loan agreement in any 
	way.
	</span>
	</p>
	<span style="font-size :14px"> </span>
	<p class="MsoNormal_p_contract_new" style="text-indent: 0cm; page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;width: 380px">
	<span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700;text-align:left;margin-top:1.0pt;margin-bottom:15.0pt; line-height :21px">
    Consumer legislation
    </span>&nbsp;
    </p>
    <p class="MsoNormal_p_contract_new" style="width: 330px;line-height :19px;margin-top:5.0pt; margin-bottom:5.0pt">
    <span style="font-size :14px; font-family: Times New Roman;text-align:left">To the 
        extent that this loan agreement is regulated <br />under consumer 
	legislation (eg the Consumer Credit <br /> Code), any provisions which do not 
	comply with<br /> that legislation have no effect, and to the extent <br />necessary, 
    this loan agreement is to be read so it<br />does not impose obligations 
    prohibited by that legislation.
    </span>
    </p> 
  </td>
  </tr>
  <tr><td>&nbsp;</td></tr>
</table>
<span style="font-size :small;color :Gray;margin-top:5.0pt">NETL </span><asp:Label ID="Label_46" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>

  <p class="MsoNormal_p_contract_new"  style=" margin-top:5.0pt;margin-bottom:20.0pt; width: 755px;">
  <asp:Label ID="Label_28" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4 of&nbsp; 9</span></p>
<p>&nbsp;</p>
<table border="0"  cellpadding="0" cellspacing="1" style="border-collapse: collapse ;width:600px;height:960px;border-color:#111111;margin-left:.15in"  >
  <tr>
   <td  valign="top"  >
    <p class="MsoNormal_p_contract_new" style="width: 330px;text-align:left">
    <span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight: normal">
    We encourage you to obtain independent legal advice and independent 
    financial advice.
    </span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="page-break-after:avoid;width:330px;margin-top:5.0pt; margin-bottom:5.0pt"><b>
    <span style="font-size :14px; font-family: Times New Roman">Financial 
    difficulty</span>
    </b></p> 
    <p class="MsoNormal_p_contract_new" style="width: 330px">
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px">You should 
    inform us as soon as possible if you 
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px">are </span>
        in financial difficulty.&nbsp;We will 
    discuss your problems with you, with a view to finding an acceptable 
    solution.</span>
    </p>
    <p class="MsoNormal_p_contract_new" style="text-indent: 0cm; line-height: normal; page-break-after: avoid; margin-left: 0cm; margin-right: 0cm;margin-top:5.0pt; margin-bottom:5.0pt;width: 350px;">
    <span style="font-size :14px; font-family: Times New Roman; text-transform: none; font-weight:700">
    General</span>
    </p> 
    <p class="MsoNormal_p_contract_new" style="width: 355px">
    <span style="font-size :14px; font-family: Times New Roman;line-height:19px;width: 355px">If there are 
    two or more of you, each of you is individually liable, and all of you are 
    jointly liable.&nbsp;References to a person includes companies and trusts and 
    any other kind of body.&nbsp;Singular words include plural words and vice versa.</span>
    </p>
	<p class="MsoNormal_p_contract_new" style="width: 350px;margin-top:5.0pt; margin-bottom:5.0pt" >
    <span style="font-size :14px;line-height:20px"><b>Privacy consent</b></span>
    </p>
	<p class="MsoNormal_p_contract_new" style="width: 330px">
    <span style="font-size :14px;line-height:19px">We may collect and use your personal 
	information for arranging or providing credit, insuring credit and for 
	direct marketing of products and services offered by us or any organisation 
	we are affiliated with or represent.</span>
	</p> 
	<p class="MsoNormal_p_contract_new" style="width: 350px;margin-top:5.0pt; margin-bottom:5.0pt" >
    <span style="font-size :14px;line-height:19px">The information provided by you will be held 
	by us.<br />You can gain access to the information by contacting us.<br /> You have the to request not to receive direct marketing material.</span>
	</p> 
	<p class="MsoNormal_p_contract_new" style="width: 330px;margin-top:5.0pt; margin-bottom:5.0pt" >
    <span style="font-size :14px;line-height:19px">You agree that we, any mortgage broker, 
	mortgage originator, mortgage manager, and any other person or company who 
	at any time provides or has any interest in the credit, and who may be 
	overseas entities, can do any of the following at any time.</span>
	</p>
	<p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; line-height: normal; margin-left: 17.85pt; margin-right: 0cm;width: 300px">
    <span style="font-size :14px; font-family: Times New Roman; color: windowtext">(a)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Seek and use commercial credit information about you to assess an application for 
	consumer credit or commercial credit.</span>
	</p>
    <p class="MsoNormal_p_contract_new" 
           style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;text-align :left; height: 60px;width: 310px" >
     <span style="font-size :14px; font-family: Times New Roman; color: windowtext">(b)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Seek and use 
	consumer credit information about you to assess an application for 
	commercial credit or consumer credit.</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;text-align :left;width: 300px" >
    <span style="font-size :14px; font-family: Times New Roman; color: windowtext">(c)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Seek 
	and use a credit report about you provided by a credit reporting agency to 
	collect overdue payments from you.</span>
	</p>

    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;margin-bottom: .0001pt;text-align :left;width: 300px">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(d)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px;margin-top:2.0pt;margin-bottom:2.0pt;width: 360px">Provide 
	information to a mortgage insurer to assess the risk of providing mortgage insurance or to assess the risk of default. 
	</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;text-align :left;width: 300px" >
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(e)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Seek from and use 
	or give to another credit provider any information about your account, 
	credit worthiness, credit standing, credit history or credit capacity. In 
	particular, we may provide an &quot;opinion&quot; on you.</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; margin-bottom: .0001pt;text-align :left;width: 300px">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(f)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Seek from and use 
	or give to any mortgage broker, mortgage originator, mortgage manager, 
	financial consultant, accountant, lawyer, or other adviser acting in 
	connection with any financing provided or proposed to be provided to you any 
	personal information, consumer or commercial credit information.</span>
	</p>
   </td>
    <td >&nbsp;</td>
    <td style="width:320px" valign="top">

    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; width: 330px;text-align :left">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(g)&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Give to a credit 
	reporting agency personal or commercial information about you. The 
	information may include identity particulars; the fact that the Lender is a 
	current credit provider to you; payments which become overdue more than 60 
	days, and for which action is commenced; advice that payments are no longer 
	overdue; advice that cheques drawn by you in excess of $100 have been 
	dishonoured more than once; in specified circumstances that in the  opinion 
	of the Lender you have committed a serious credit infringement; and the 
	credit provided to you by the Lender has been paid or otherwise discharged.</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;width: 300px;text-align :left">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(h)&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Disclose any 
	report or personal information about you to another person in 
	connection with funding financial accommodation by means of an arrangement 
	involving securitisation, or any other proposed transfer of or proposed 
	dealing with your loan.</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; width: 310px;text-align :left">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(i)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:20px">Provide 
	information to any person who proposes to guarantee or has guaranteed 
	repayment of any credit provided to you.</span>
	</p> 
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm;width: 330px;text-align :left" >
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext">(j)&nbsp;&nbsp;</span><span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:19px">Disclose personal 
	and credit information about<br /> you as required by law, or to organisations <br />
	involved in providing credit to you, or any <br />associate, or contractor of 
	ours, (including, for <br />example, stationery printing houses, mail<br /> houses, 
	lawyers, accountants), people <br /> considering acquiring or taking an interest in 
	our<br /> business, or our assets or any tribunal or court<br /> inquiring into any 
	transaction we have with you<br /> or any person who dealt with those 
	transactions.</span>
	</p>
    <p class="MsoNormal_p_contract_new" style="text-indent: -17.85pt; margin-left: 17.85pt; margin-right: 0cm; width: 310px;text-align :left">
	<span style="font-size :14px; font-family: Times New Roman; color: windowtext;line-height:20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If you do not provide personal information, we 
	may be unable to arrange credit for you.</span>
	</p>
	</td>
  </tr>
</table>
<span style="font-size :small;color :Gray;margin-top:5.0pt">NETL </span><asp:Label ID="Label_47" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>

<p class="MsoNormal_p_contract_new"  style=" margin-top:5.0pt;margin-bottom:20.0pt;width: 755px;">
<asp:Label ID="Label_29" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5 of&nbsp; 9</span></p>
<%--''''''''''''''''''''''''''''''''''''''''''''--%>
  
 <p>&nbsp;</p>
<table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;width:600px;border-color:#111111" id="Table12">
 <tr>
 <td>
 <h1 style="text-align: left; margin-right: 0cm; margin-top: 5.0pt; margin-bottom:5.0pt;text-align : center;width:720px">
 <b>
 <span style="font-size: 20px; font-family: Times New Roman; text-align :center;text-decoration:underline">
 ACKNOWLEDGMENT</span></b></h1>
<span style="font-size :14px; font-family: Times New Roman">
You acknowledge the terms and conditions of this agreement including the 
schedule, and agree to be bound by the terms and conditions of this agreement. </span>
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
 <td class="MsoNormal_p_contract_new" style="margin-top:3.0pt;margin-bottom:3.0pt;width: 720px">
<b>
<span style="font-size :14px; font-family: Times New Roman">
 If the borrower is a company, or if this loan is predominantly for business purposes or investment purposes,
this loan will not be regulated by the Consumer Credit Code despite any statement that the Consumer
Credit Code applies to this loan.</span>
 </b>
 </td>
 </tr>
</table>
 <table border="1" cellpadding="0" cellspacing="0" style="margin-left:7.0pt;border-collapse: collapse;border-color:#111111;width:520px;height:440px" id="Table13">
 <tr>
 <td >
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left:7.0pt;border-collapse: collapse;border-color:#111111;width:520px; height:430px" id="Table14">
 <tr><td  colspan="2">&nbsp;</td></tr>
 <tr>
 <td colspan="2"><b>
 <span style="font-size :15px; font-family: Times New Roman;margin-top:3.0pt;margin-bottom:3.0pt;width: 560px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;IMPORTANT</span>
 </b>

 </td>
 </tr>
 <tr>
<td valign="top">
<b><span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BEFORE YOU SIGN</span></b>
 </td>
 <td valign="top" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<b><span style="font-size :14px; font-family: Times New Roman ;width:450px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; THINGS YOU 
 MUST KNOW</span></b>
 </td>
 </tr>
  <tr>
  <td valign="top" >
  <ul  >
  <li class="MsoNormal_p_contract_new" style=" text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :14px">
  <span style="font-size :14px; font-family: Times New Roman">READ THIS 
    CONTRACT DOCUMENT so that you know exactly what contract you are entering
     into and what you will have to do under the <br />
     contract.</span>
   </li>
   <li class="MsoNormal_p_contract_new" style="text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :14px">
  <span style="font-size :14px; font-family: Times New Roman">
    You should also read the information statement:  </span>
   <br />
   <span style="font-size :14px; font-family: Times New Roman">
    &quot;<b>THINGS YOU SHOULD KNOW 
    ABOUT YOUR PROPOSED CREDIT CONTRACT&quot;</b></span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
    Fill in or cross out any blank spaces.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    Get a copy of this contract document.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :14px">
   <b><span style="font-size :14px; font-family: Times New Roman">Do not</span></b><span style="font-size :14px; font-family: Times New Roman"> 
    sign this contract document</span>
   <br />
   <span style="font-size :14px; font-family: Times New Roman">if&nbsp; there is 
    anything you do not understand.</span>
   </li>
    </ul>
    </td>
    <td valign="top" >
    <ul>
    <li class="MsoNormal_p_contract_new" style="text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
        Once you sign this contract document, you will be 
        bound by it. However, you may end the contract before you obtain credit,or a 
        card or other means is used to obtain goods or services for which credit is to 
        be provided under the contract, by telling the credit provider in writing, but 
        you will still be liable for any fees or charges already incurred. 
    </span>
    </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt; text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    You <b>do not</b> have to take out consumer 
    credit insurance unless you want to. If this
     contract says so, you must take out
     insurance over any mortgaged property.  </span>
   </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px"> 
    <span style="font-size :14px; font-family: Times New Roman">
    If you take out insurance, the credit 
    provider cannot insist on any particular
    insurance company.</span>
     </li>
     <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
    <span style="font-size :14px; font-family: Times New Roman">
    If this contract document says so, the 
    credit provider can vary the annual 
    percentage rate (the interest rate),the 
    repayments and the fees and charges and 
    can add new fees and charges without 
    your consent </span>
   </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    If this contract document says so, the
    credit provider can charge a fee if you pay 
    out your contract early.</span>
    </li>
    </ul>
    </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;border-color:#111111;width:600px;height:50px" id="Table15" >
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td valign="top" style="font-size :14px; font-family: Times New Roman" >I/we acknowledge receiving 
	<b>$<asp:Label ID="Label_30" runat="server"></asp:Label>&nbsp;</b>in <asp:Label ID="Label_31" runat="server"></asp:Label>.</td></tr>
	<tr><td style="font-size :14px; font-family: Times New Roman">I/we acknowledge receiving a copy of the contract.</td></tr>
    <tr><td style="font-size :14px; font-family: Times New Roman">I/we acknowledge and accept the scanned documents as originals.
    </td>
    </tr> 
    <tr><td>&nbsp;</td></tr>
    </table>
    <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" style="margin-left:9.0pt;border-collapse: collapse;width:600px; height:212px">
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt; margin-top:5.0pt; margin-bottom:5.0pt;width:550px">
    <b><span style="font-size :14px; font-family: Times New Roman">Signed </span></b>
    <span style="font-size :14px; font-family: Times New Roman">by </span>
    </td>
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:300px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the presence of</span>     
    </td>
    </tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
      <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :14px; font-family: Times New Roman">
            ........................................................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px;font-size :14px; font-family: Times New Roman">
           &nbsp;&nbsp;&nbsp;&nbsp; 
           ................................................................................</td>
    </tr>
     <tr style="page-break-inside: avoid">
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
            
     <span style="font-size :14px; font-family: Times New Roman">&nbsp;Signature of Person receiving cash/loan </span>  
     </td>
     <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; Signature of witness</span>     
    </td>
    </tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt" ></td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt" ></td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
    <span style="font-size :14px; font-family: Times New Roman">
         ........................................................................ </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; ................................................................................</span></td>
    </tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;Print name</span></td>
    <td valign="top" style="width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; Print name of witness</span></td>
    </tr>

    <tr>
    <td style="width:350px"></td>
    <td style="margin-top:5.0pt;font-family :Comic Sans MS;font-size :13px;width:370px" >
    &nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="Label_33" runat="server" ></asp:Label></td>
    </tr>
    <tr>
    <td style="width:350px">&nbsp;</td>
    <td style="width:300px;height:5px;font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ..................................................................................</td>
    </tr>
    <tr>
    <td style="width:350px">&nbsp;</td>
    <td style="font-size :14px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp; &nbsp; Address of witness</td>
    </tr>
    <tr><td>&nbsp;</td></tr>
   <tr>
   <td style ="width:650px;text-align :left" class="MsoNormal_p_contract_new">
      &nbsp;
      Date of Credit Contract&nbsp; <asp:Label ID="Label_39" runat="server"></asp:Label>
      <br />
      <br />
    <span style="font-size :small;color :Gray;margin-top:10.0pt">&nbsp; NETL </span><asp:Label ID="Label_44" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label></td>
    <td>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </td>
     </tr>
     <tr><td>&nbsp;</td></tr>
     </table>
<p class="MsoNormal_p_contract_new"  style=" margin-bottom:20.0pt; width: 755px;">
 &nbsp; &nbsp;&nbsp; <asp:Label ID="Label_38" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6 of&nbsp; 9</span></p>
<%--..............................................
--%>
<p>&nbsp;</p>
<p style=" margin-left:12.0pt;margin-bottom:5.0pt;margin-top:5.0pt;text-align:justify; height: 32px; width:650px">
    &nbsp;
<span style="font-family: Arial Black;font-size:18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Legal 
    advice acknowledgment certificate
</span>
</p>
<p class="MsoNormal_p_contract_new" style="margin-top:5.0pt;margin-bottom:5.0pt;text-align:justify; width:650px;font-size:18px">
<span style="font-family: Arial Rounded MT Bold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp; COMPLETE ONE OF THESE BOXES
</span>
</p>
<p class="MsoNormal_p_contract_new">&nbsp;</p>
        <div style=" margin-left:15.0pt;border: 3.75pt double windowtext; padding: 7.0pt; width:650px; height:400px">
            <p class="MsoNormal_p_contract_new" style="text-align: center; border: medium none; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
                <span style="font-family: Arial Rounded MT Bold;font-size :14px">TO BE COMPLETED IF YOU CHOOSE</span>
<span style="background-color: #FFFFFF; font-size :18px"><b>NOT</b></span>
<span style="font-family: Arial Rounded MT Bold;font-size :14px">TO OBTAIN LEGAL ADVICE </span>
</p>
<p class="MsoNormal_p_contract_new"  style="text-align: center; border: medium none; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-family: Arial Rounded MT Bold;font-size :14px">IF YOU HAVE ANY DOUBTS OR 
WANT MORE INFORMATION, CONTACT YOUR GOVERNMENT CONSUMER AGENCY OR GET LEGAL ADVICE
</span></p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">&nbsp;
</p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">
<span style="font-size:14px">I/WE CERTIFY THAT:
</span></p>
<ul>
<li>
<p class="MsoNormal_p_contract_new" style=" border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-size :14px">I/we have read the document to 
which this certificate is attached (the &quot;Document&quot;).
</span>
</p>
</li>
<li>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-size :14px">I/we are the Borrower(s) named 
  in the Document.
</span>
</p>
</li>
 <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :14px">I/we have been given the opportunity to obtain 
  legal advice on the nature and effect <br />of the
  Document but have chosen not to do so.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
 <span style="font-size :14px">I/we understand the nature and 
  effect of the Document.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :14px">I/we understand the obligations 
  and risks involved in signing the Document.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; margin-right: 0cm; margin-top: 3.0pt; margin-bottom: 3.0pt; padding: 0cm;width:650px">
  <span style="font-size:3">I/we sign the Document freely, 
  voluntarily and without pressure from any person.
  </span>
  </p>
  </li>
  </ul>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">DATED</span>
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">:
  &nbsp;&nbsp;<asp:Label ID="Label_32" runat="server"></asp:Label></span></p>

  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm ">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm; width:650px ">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">SIGNED</span> 
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">:&nbsp;_____________________________ &nbsp;</span><b><span style="font-family: Arial Rounded MT Bold;font-size :14px">(borrower(s) 
  signature)</span> </b></p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm ">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin: 3 0cm;padding: 0cm;width:650px">
      <span style="font-family: Arial Rounded MT Bold;font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _____________________________ &nbsp;</span><b><span style="font-family: Arial Rounded MT Bold;font-size :14px">(borrower(s) 
  signature)</span> </b></p>
  </div>
<p class="MsoNormal_p_contract_new" style="text-align:center;margin:6.0pt 0cm; text-align:left;width:650px">

<span style="font-family: Arial Rounded MT Bold;font-size:4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
</span><span style="font-family: Arial Rounded MT Bold;font-size:22px">OR</span>
<br />
</p>
<div style="margin-left :15.0pt;border: 3.75pt double windowtext; padding: 7.0pt; width:650px; height:360px">
<p class="MsoNormal_p_contract_new" style="text-align: center; border: medium none; margin-top: 3.0pt; padding: 0cm; margin-bottom:3.0pt;width:650px">
<b><span style="font-family: Arial Rounded MT Bold;font-size :14px">TO BE COMPLETED IF YOU CHOOSE TO OBTAIN LEGAL ADVICE</span></b>
</p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">
<span style="font-size :14px">&nbsp;I/WE CERTIFY THAT:</span>
</p>
<ul>
<li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :14px">I/we have obtained legal advice on the nature and effect of the documents from the <br /> solicitor named below.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :14px">I/we understand the nature and effect of the 
  document to which this certificate is</span>
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :14px">attached
  (the &quot;Document&quot;).</span>
  </p>
 </li> 
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3; margin-bottom:3;width:650px">
  <span style="font-size :14px">I/we understand the obligations 
  and risks involved in signing the Document.</span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; margin-right: 0cm; margin-top: 3.0pt; margin-bottom: 3.0pt; padding: 0cm;width:650px">
  <span style="font-size :14px">I/we sign the Document freely, 
  voluntarily and without pressure from any person.</span>
  </p>
  </li>
  </ul>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px ">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">NAME OF SOLICITOR</span><span style="font-size:3">:___________________________________
  </span>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">DATED</span>
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">:&nbsp;the &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;________________&nbsp; day of&nbsp; ______________________</span>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">SIGNED</span> 
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">:&nbsp; 
  _______________________________ &nbsp;</span>
  <b><span style="font-family: Arial Rounded MT Bold;font-size :14px">(borrower(s) 
  signature)</span></b>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin: 3 0cm; padding: 0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :14px">&nbsp;</span><b> <span style="font-family: Arial Rounded MT Bold;font-size:3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family: Arial Rounded MT Bold;font-size :14px">&nbsp;&nbsp;&nbsp;&nbsp;_____________________________&nbsp; (borrower(s) signature)</span></b> 
 </p>
 </div>
 <p>&nbsp;&nbsp;<span style="font-size :small;color :Gray">&nbsp; NETL </span><asp:Label ID="Label_45" runat="server"  Font-Size="Small" ForeColor ="Gray" > </asp:Label></p>
<p class="MsoNormal_p_contract_new"  style="margin-top:20.0pt; margin-bottom:20.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp; <asp:Label ID="Label_37" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7 of&nbsp; 9</span></p>
<%--''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''--%>

<span style="font-family:Arial Narrow;font-size:14px">&nbsp;&nbsp;&nbsp; Some of the information in the information statement below will only apply if your loan is regulated by the Consumer Credit Code.</span>
<p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
    &nbsp;</p>
    <p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
            <span style="font-family:Arial Black;font-size:14px">&nbsp;&nbsp;&nbsp; INFORMATION STATEMENT</span></p>
        <p class="MsoNormal_new_contract" style="margin-top:0; margin-bottom:0;width:680px">
            <span style="font-family:Arial Black;font-size:14px">&nbsp; THINGS YOU SHOULD KNOW ABOUT 
YOUR<br/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            PROPOSED CREDIT CONTRACT</span> </p>
    <p style="margin-top:0; margin-bottom:0;width:680px">
         <span style="font-family:Arial Narrow;font-size:14px;text-align:left ">&nbsp;&nbsp;&nbsp; This statement tells you about some 
of the rights and obligations of yourself and your credit provider.</span>
    </p>
<p  style="margin-top:0; margin-bottom:0;width:680px">
<span style="font-family:Arial Narrow;font-size:14px">&nbsp;&nbsp;&nbsp;&nbsp; It does not state the terms and 
conditions of your contract.</span>
</p>
<p  style="margin-top:0; margin-bottom:.15cm;width:700px">
<span style="font-family:Arial Narrow;font-size:14px">&nbsp;&nbsp;&nbsp;&nbsp; If you have any concerns about your 
contract, contact your credit provider and, if you still have concerns, your 
Government Consumer<br />
 &nbsp;&nbsp;&nbsp;&nbsp;
 Agency, or get legal advice.
</span>
</p>
<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="font-family :Arial Narrow;font-size:12px"  >
 <span style="font-family: Arial Black; font-weight:700;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    THE CONTRACT</span>&nbsp;&nbsp;&nbsp;
 </td>
</tr>
</table>
<table border ="1" style="border-collapse: collapse;border-color:#000000;width:680px;margin-left:.15in">
<tr>
<td>
<table border ="0"  cellspacing="1" style="width:680px;margin-left:.15in" >
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px"> 
       1.&nbsp;How can I get details of my proposed credit contract?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your credit provider must give you a pre-contractual statement containing 
certain information about your contract. The pre-contractual</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; statement, and this document, must be given to you before- </td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; your contract is entered into; or </li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you make an offer to enter into the contract;<br/> 
</li>
</ul> 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;whichever happens first.  </td>
</tr>

<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px">2.&nbsp;How Can I get a copy of the final contract?</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;If the 
    contract document is to be signed by you and returned to your credit 
    provider, you must be given a copy to keep. Also, the credit
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;provider must give you a copy of the final contract within 
    14 days after it is made.&nbsp; This rule does not, however, apply, if the credit 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; provider has previously given you&nbsp; copy 
    of the contract document to keep. If you want another copy of your contract write to your credit  </td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;provider and 
    ask for one.Your credit provider may charge you a fee.&nbsp;Your credit provider has to give you a copy -</td>
</tr>

<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp; within 14 days of 
    your written request if the original contract came into existence 1 year or 
    less before your <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request; or
    </li>
<li>&nbsp;&nbsp;&nbsp;&nbsp; otherwise within 30 days of your written request.
</li>
</ul> 
</td>
</tr> 
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px;width:680px">3.&nbsp;Can I terminate the contract?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes. You can terminate the contract by writing to the credit provider 
    so long as - 
</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;you have not obtained any credit under the contract; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a card or other means of obtaining credit given to you by your 
    credit provider has not been used to acquire goods or services for<br />&nbsp;&nbsp;&nbsp;&nbsp;which credit is to be provided under the contract.
</li>
</ul> 
</td>
</tr> 
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;However, you will still have to pay any 
    fees or charges incurred before you terminated the contract.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" 
         >4.&nbsp;Can I pay my credit contract out early?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.Pay your credit 
    provider the amount required to pay out your credit contract on the day
    you wish to end your contract.

</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">5.&nbsp;How can I find out the pay out figure?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes can write to your credit provider at any time and ask for a statement of the pay out figure as at any date you 
    specify.&nbsp;
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can also ask for details of how the 
    amount is made up.&nbsp;
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your credit provider must 
    give you the statement within 7 days after you give your request to the credit 
    provider.You may&nbsp;be charged
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; a fee for the statement.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >6.&nbsp;Will I pay less interest if I pay out my contract early?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.The interest you can be 
	charged depends on the actual time money is owing.However, you may have to 
	pay an early termination

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; charge (if your contract permits your credit 
	provider to charge one) and other fees.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >7.&nbsp;Can my contract be changed by my credit provider?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes, 
    but only if your contract says so.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >8.&nbsp;Will I be told in advance if my credit provider is going to make a change in the contract?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;That depends on the type of change.&nbsp; 
    For example-
</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px;margin: 0.0pt 0cm;">
<li>&nbsp;&nbsp;&nbsp;&nbsp;You get at least same day notice for a change to an annual percentage rate.&nbsp; 
    That notice may be a written notice<br />&nbsp;&nbsp;&nbsp; to you or a notice published in a newspaper.
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;You get 20 days advance written notice for-
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a change in the way in which interest is calculated;
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;a change in credit fees and charges; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;any other changes by your credit provider
</li>
</ul> 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;except where 
    the change reduces what you have to pay or the change happens
    automatically under the contract</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px" >9.&nbsp;Is there 
    anything I can do if I think that my contract is unjust?
</td> 
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes.&nbsp;You should first talk 
    to your credit provider. Discuss the matter and see if you can come to some arrangement. If that is not successful
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you may contact your 
	credit provider's external dispute resolution scheme.External dispute resolution is a free service established to

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; provide you with an independent 
	mechanism to resolve specific complaints.You credit provider&#39;s external dispute resolution provider is the
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     Credit Ombudsman Service Limited and 
    can be contacted on 1800 
    138 422 or 02 9273 8400, by fax at 9273 8440, by email 
	at

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="mailto:info@cosl.com.au">info@cosl.com.au</a> or in writing to PO 
    Box A252 SYDNEY SOUTH 
    NSW 1235. Alternatively, you can go to 
    court. You may wish to get

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  legal advice, for example from your community legal centre or legal Aid. You can also contact ASIC, the 
	regulator, for information on
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1300 300 630 or through ASIC's website at http://www.asic.gov.au
</td>
</tr>
</table>
</td>
</tr>
</table>
<span style="font-size :small;color :Gray;margin-top:10.0pt">&nbsp;&nbsp;&nbsp;&nbsp; NETL </span><asp:Label ID="Label_42" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
<p class="MsoNormal_p_contract_new"  style=" margin-bottom:20.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp; <asp:Label ID="Label_34" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;8 of&nbsp; 9</span></p>
<p>&nbsp;</p>
<%--.........................
--%>

<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="width:680px">
 <span style="font-family: Arial Black; font-weight:700;font-size :18px;width:680px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GENERAL</span>&nbsp;&nbsp;&nbsp;
 </td>
</tr>
</table>
<table border ="1" style="border-collapse: collapse;border-color:#000000;width:680px;margin-left:.15in">
<tr>
<td>
<table border ="0"  cellspacing="1" style="width:680px" >
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">10.&nbsp;What do I do if I cannot make a repayment?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Get in touch with your 
    credit provider immediately.&nbsp; Discuss the matter and see if you can come to 
    some arrangement.You can ask your

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   credit provider to change your contract 
    in a number of ways:

</td>
</tr>
<tr>
<td>
<ul  style="font-family :Arial Narrow;font-size:13px">
<li>&nbsp;&nbsp;&nbsp;&nbsp;to extend the term of the contract and reduce the payments; or 
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;to 
    extend the term of your contract and delay payments for a set time; or
</li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;to delay payments for a set time.
</li>
</ul>
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">11.&nbsp;What if my credit provider and I cannot agree on a suitable arrangement?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;If the credit provider 
    refuses your request&nbsp; to change the repayment, you can ask the credit provider 
    to review this decision if you think it is 

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;wrong. 
    
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;if the credit provider still refuses your 
	request you can complain to the external dispute resolution scheme that your credit

</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;provider belongs to. Further details about this scheme are set out 
	below in question 12.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">12.&nbsp;Can my credit provider take action against me?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Yes, if you are in default 
    under your contract.&nbsp; But the law says that you cannot be unduly harassed or threatened for repayments.
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;If you think you are being unduly harassed or 
    threatened, contact the credit provider's external dispute resolution scheme or ASIC, 
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;or get legal advice.
</td>
</tr>
<tr>
<td style="font-family:Arial Black ; font-weight:700;font-size:13px">13.&nbsp;Do I have any other rights and obligations?
</td>
</tr>
<tr>
<td style="font-family :Arial Narrow;font-size:13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Yes. The law will give you other rights and obligations. You should also<b> READ YOUR CONTRACT </b>carefully.</td>
</tr>
</table> 
</td> 
</tr>
</table>

<table border="1" cellspacing="1" style="border-collapse: collapse;border-color:#000000;width:684px;margin-left:.15in" >
<tr>
<td style="font-family :Arial Narrow;font-size:13px"><b>IF YOU HAVE ANY COMPLAINTS ABOUT YOUR CREDIT CONTRACT, OR WANT MORE INFORMATION, CONTACT YOUR CREDIT PROVIDER.
  YOU MUST ATTEMPT TO RESOLVE YOUR COMPLAINT WITH YOUR 
	CREDIT PROVIDER BEFORE CONTACTING YOUR CREDIT PROVIDER'S&nbsp; EXTERNAL 
	DISPUTE RESOLUTION SCHEME. IF YOU HAVE A COMPLAINT WHICH REMAINS UNRESOLVED 
	AFTER SPEAKING TO YOUR CREDIT PROVIDER YOU CAN&nbsp; CONTACT YOUR CREDIT PROVIDER'S&nbsp; EXTERNAL DISPUTE RESOLUTION SCHEME 
	OR GET LEGAL ADVICE. EXTERNAL DISPUTE RESOLUTION IS A FREE SERVICE ESTABLISHED TO 
	PROVIDE YOU WITH AN INDEPENDENT MECHANISM TO RESOLVE SPECIFIC COMPLAINTS.&nbsp; 
	YOUR CREDIT PROVIDER'S&nbsp; EXTERNAL DISPUTE RESOLUTION PROVIDER IS THE 
	CREDIT OMBUDSMAN SERVICE LIMITED AND CAN BE CONTACTED ON 1800 138 422 OR 02 
	9273 8400, BY FAX AT 9273 8440, BY EMAIL AT
	<a href="mailto:INFO@COSL.COM.AU">INFO@COSL.COM.AU</a> OR IN WRITING TO PO 
	BOX A252 SYDNEY SOUTH NSW 1235.&nbsp;PLEASE KEEP THIS INFORMATION STATEMENT.&nbsp; YOU 
    MAY WANT SOME INFORMATION FROM IT AT A LATER DATE.</b>
</td>
</tr>
</table>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>

<span style="font-size :small;color :Gray">&nbsp;&nbsp;&nbsp; NETL </span><asp:Label ID="Label_43" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label>
<p class="MsoNormal_p_contract_new"  style="margin-top:5px; margin-bottom:20.0pt; width: 755px;">
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label_35" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;9 of&nbsp; 9</span></p>
<p>&nbsp;</p>


</asp:Panel>
</div>

 </form>
</body>
</html>
