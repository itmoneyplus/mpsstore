<%@ Page Language="VB" Culture="en-AU" AutoEventWireup="false" CodeFile="PartContract.aspx.vb" Inherits="Customer_PartContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Part Contract</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
<script type="text/javascript"  >
window.history.forward(1);
function  new_page() {
    window.location.assign("LoanSummary.aspx");
}
      

</script>
</head>

<body onload="window.print();">

<form id="form1" runat="server"  ondblclick="new_page();">
<div>
<%-- <table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;width:600px;border-color:#111111" id="AutoNumber24">
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

</table>--%>
<asp:Panel ID="p2new" runat ="server" Visible="false"  >
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
 <table border="1" cellpadding="0" cellspacing="0" style="margin-left:9.0pt;border-collapse: collapse;border-color:#111111;width:560px;height:440px" id="AutoNumber34">
 <tr>
 <td >
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left:9.0pt;border-collapse: collapse;border-color:#111111;width:560px; height:430px" id="AutoNumber35">
 <tr><td  colspan="2">&nbsp;</td></tr>
 <tr><td colspan="2"><b>
 <span style="font-size :15.5px; font-family: Times New Roman;margin-top:3.0pt;margin-bottom:3.0pt;width: 560px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; IMPORTANT</span>
 </b>
 </td>
 </tr>
 <tr>
<td valign="top">
<b><span style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BEFORE YOU SIGN</span></b>
 </td>
 <td valign="top" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<b><span style="font-size :15.5px; font-family: Times New Roman ;width:450px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; THINGS YOU 
 MUST KNOW</span></b>
 </td>
 </tr>
  <tr>
  <td valign="top" >
  <ul  >
  <li class="MsoNormal_p_contract_new" style=" text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :15.5px">
  <span style="font-size :15.5px; font-family: Times New Roman">READ THIS 
    CONTRACT DOCUMENT so that you know exactly what contract you are entering
     into and what you will have to do under the <br />
     contract.</span>
   </li>
   <li class="MsoNormal_p_contract_new" style="text-align: left; margin-right: 0cm; margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :15.5px">
  <span style="font-size :15.5px; font-family: Times New Roman">
    You should also read the information statement:  </span>
   <br />
   <span style="font-size :15.5px; font-family: Times New Roman">
    &quot;<b>THINGS YOU SHOULD KNOW 
    ABOUT YOUR PROPOSED CREDIT CONTRACT&quot;</b></span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :15.5px">
    <span style="font-size :15.5px; font-family: Times New Roman">
    Fill in or cross out any blank spaces.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :15.5px">
   <span style="font-size :15.5px; font-family: Times New Roman">
    Get a copy of this contract document.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="text-align: justify;  margin-right: 0cm;margin-top:3.0pt;margin-bottom:3.0pt;width: 320px;font-size :15.5px">
   <b><span style="font-size :15.5px; font-family: Times New Roman">Do not</span></b><span style="font-size :15.5px; font-family: Times New Roman"> 
    sign this contract document</span>
   <br />
   <span style="font-size :15.5px; font-family: Times New Roman">if&nbsp; there is 
    anything you do not understand.</span>
   </li>
    </ul>
    </td>
    <td valign="top" >
    <ul>
    <li class="MsoNormal_p_contract_new" style="text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :15.5px">
    <span style="font-size :15.5px; font-family: Times New Roman">
        Once you sign this contract document, you&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; will be 
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
<%--     <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt; text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :14px">
   <span style="font-size :14px; font-family: Times New Roman">
    You <b>do not</b> have to take out consumer 
    credit insurance unless you want to. However, If this
     contract says so, you must take out
     insurance over<br /> any mortgaged property that is used as security, such as a 
        house or car.  </span>
   </li>--%>
    <li class="MsoNormal_p_contract_new" style="margin-right: 10.0pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :15.5px"> 
    <span style="font-size :15.5px; font-family: Times New Roman">
    If you take out insurance, the credit 
    provider cannot insist on any particular
    insurance company.</span>
     </li>
     <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :15.5px">
    <span style="font-size :15.5px; font-family: Times New Roman">
    If this contract document says so, the 
    credit provider can vary the annual 
    percentage rate (the interest rate),the 
    repayments and the fees and charges and 
    can add new fees and charges without 
    your consent.</span>
   </li>
    <li class="MsoNormal_p_contract_new" style="margin-right: 4.7pt;text-align :justify;margin-top:3.0pt;margin-bottom:3.0pt;width: 290px;font-size :15.5px">
   <span style="font-size :15.5px; font-family: Times New Roman">
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
    <tr>
    <td valign="top" >I/we acknowledge receiving 
	<b>$<asp:Label ID="Label24" runat="server"></asp:Label>&nbsp;</b>in <asp:Label ID="Label25" runat="server"></asp:Label>.</td></tr>
	<tr><td>I/we acknowledge receiving a copy of the Contract.</td></tr>
    <tr><td>I/we acknowledge and accept the scanned documents as originals.
    </td>
    </tr> 
    <tr><td>&nbsp;</td></tr>
    </table>
    <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" style="margin-left:9.0pt;border-collapse: collapse;width:600px; height:212px">
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt; margin-top:5.0pt; margin-bottom:5.0pt;width:550px">
    <b><span style="font-size :15.5px; font-family: Times New Roman">Signed </span></b>
    <span style="font-size :15.5px; font-family: Times New Roman">by </span>
    </td>
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:300px">
    <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In the presence of</span>     
    </td>
    </tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :15.5px; font-family: Times New Roman">
            ........................................................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px;font-size :15.5px; font-family: Times New Roman">
           &nbsp;&nbsp;&nbsp;&nbsp; 
           ................................................................................</td>
    </tr>
     <tr style="page-break-inside: avoid">
     <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
            
     <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;Person receiving cash/loan </span>  
     </td>
     <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; Signature of witness</span>     
    </td>
    </tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr><td style="margin-top:5.0pt; margin-bottom:5.0pt;width:350px">&nbsp;</td></tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;margin-top:5.0pt; margin-bottom:5.0pt;width:370px"> 
    <span style="font-size :15.5px; font-family: Times New Roman">
         ........................................................................ </span></td>
    <td valign="top" style="margin-top:5.0pt; margin-bottom:5.0pt;width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; ................................................................................</span></td>
    </tr>
    <tr style="page-break-inside: avoid">
    <td valign="top" style="padding: 0cm 3.95pt;width:350px">
    <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;Print name</span></td>
    <td valign="top" style="width:300px;padding-left:3.95pt; padding-right:3.95pt; padding-top:0cm; padding-bottom:0cm;height:20px">
    <span style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp; Print name of witness</span></td>
    </tr>

    <tr>
    <td style="width:350px"></td>
    <td style="margin-top:5.0pt;font-family :Comic Sans MS;font-size :15px;width:370px" >
    &nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="Label26" runat="server" ></asp:Label></td>
    </tr>
    <tr>
    <td style="width:350px">&nbsp;</td>
    <td style="width:300px;height:5px;font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ..................................................................................</td>
    </tr>
    <tr>
    <td style="width:350px">&nbsp;</td>
    <td style="font-size :15.5px; font-family: Times New Roman">&nbsp;&nbsp;&nbsp; &nbsp; Address of witness</td>
    </tr>
   <tr>
   <td style ="width:650px;text-align :left" class="MsoNormal_p_contract_new">
      &nbsp;
      Date of Credit Contract&nbsp; <asp:Label ID="Label27" runat="server"></asp:Label>
      <br />
    <span style="font-size :small;color :Gray">&nbsp; NETL </span><asp:Label ID="Label11" runat="server"  Font-Size="small" ForeColor ="Gray" > </asp:Label></td>
    <td>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </td>
     </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
     <td colspan ="2" >&nbsp;<asp:Label ID="Label22" runat="server"  Font-Size="small" ></asp:Label></td></tr></table>
    <p>&nbsp;</p>
<%--..............................................
--%>


<p style=" margin-left:12.0pt;margin-bottom:5.0pt;margin-top:5.0pt;text-align:justify; height: 32px; width:650px">&nbsp;
<span style="font-family: Arial Black;font-size:20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Legal advice 
    acknowledgment certificate
</span>
</p>
<p class="MsoNormal_p_contract_new" style="margin-top:5.0pt;margin-bottom:5.0pt;text-align:justify; width:650px;font-size:20px">
<span style="font-family: Arial Rounded MT Bold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp; COMPLETE ONE OF THESE BOXES
</span>
</p>
<p class="MsoNormal_p_contract_new">&nbsp;</p>
        <div style=" margin-left:12.0pt;border: 3.75pt double windowtext; padding: 7.0pt; width:650px; height:400px">
            <p class="MsoNormal_p_contract_new" style="text-align: center; border: medium none; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
                <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">TO BE COMPLETED IF YOU CHOOSE</span> 
<span style="background-color: #FFFFFF; font-size :22px"><b>NOT</b></span>
<span style="font-family: Arial Rounded MT Bold;font-size :15.5px">TO OBTAIN LEGAL ADVICE </span>
</p>
<p class="MsoNormal_p_contract_new"  style="text-align: center; border: medium none; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-family: Arial Rounded MT Bold;font-size :15.5px">IF YOU HAVE ANY DOUBTS OR 
WANT MORE INFORMATION, CONTACT YOUR GOVERNMENT CONSUMER AGENCY OR GET LEGAL ADVICE
</span></p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">&nbsp;
</p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">
<span style="font-size:17px">I/WE CERTIFY THAT:
</span></p>
<ul>
<li>
<p class="MsoNormal_p_contract_new" style=" border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-size :15.5px">I/we have read the document to 
which this certificate is attached (the &quot;Document&quot;).
</span>
</p>
</li>
<li>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
<span style="font-size :15.5px">I/we are the Borrower(s) named 
  in the Document.
</span>
</p>
</li>
 <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :15.5px">I/we have been given the opportunity to obtain 
  legal advice on the nature and effect <br />of the
  Document but have chosen not to do so.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
 <span style="font-size :15.5px">I/we understand the nature and 
  effect of the Document.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :15.5px">I/we understand the obligations 
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
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">DATED</span>
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">:
  &nbsp;&nbsp;<asp:Label ID="Label28" runat="server"></asp:Label></span></p>

  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm ">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm; width:650px ">
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">SIGNED</span> 
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">:&nbsp;_____________________________ &nbsp;</span><b><span style="font-family: Arial Rounded MT Bold;font-size:3">(borrower(s) 
  signature)</span> </b></p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm ">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin: 3 0cm;padding: 0cm;width:650px">
      <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _____________________________ &nbsp;</span><b><span style="font-family: Arial Rounded MT Bold;font-size:3">(borrower(s) 
  signature)</span> </b></p>
  </div>
<p class="MsoNormal_p_contract_new" style="text-align:center;margin:6.0pt 0cm; text-align:left;width:650px">

<span style="font-family: Arial Rounded MT Bold;font-size:4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
</span><span style="font-family: Arial Rounded MT Bold;font-size:22px">OR</span>
<br />
</p>
<div style="margin-left :12.0pt;border: 3.75pt double windowtext; padding: 7.0pt; width:650px; height:360px">
<p class="MsoNormal_p_contract_new" style="text-align: center; border: medium none; margin-top: 3.0pt; padding: 0cm; margin-bottom:3.0pt;width:650px">
<b><span style="font-family: Arial Rounded MT Bold;font-size :15.5px">TO BE COMPLETED IF YOU CHOOSE TO OBTAIN LEGAL ADVICE</span></b>
</p>
<p class="MsoNormal_p_contract_new" style="border: medium none; margin-bottom: 3.0pt; padding: 0cm; margin-top:3.0pt;width:650px">
<span style="font-size :15.5px">&nbsp;I/WE CERTIFY THAT:</span>
</p>
<ul>
<li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :15.5px">I/we have obtained legal advice on the nature and effect of the documents from the <br /> solicitor named below.
  </span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :15.5px">I/we understand the nature and effect of the 
  document to which this certificate is</span>
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3.0pt; margin-bottom:3.0pt;width:650px">
  <span style="font-size :15.5px">attached
  (the &quot;Document&quot;).</span>
  </p>
 </li> 
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; padding: 0cm; margin-top:3; margin-bottom:3;width:650px">
  <span style="font-size :15.5px">I/we understand the obligations 
  and risks involved in signing the Document.</span>
  </p>
  </li>
  <li>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin-left: 14.15pt; margin-right: 0cm; margin-top: 3.0pt; margin-bottom: 3.0pt; padding: 0cm;width:650px">
  <span style="font-size :15.5px">I/we sign the Document freely, 
  voluntarily and without pressure from any person.</span>
  </p>
  </li>
  </ul>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px ">
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">NAME OF SOLICITOR</span><span style="font-size:3">:___________________________________
  </span>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">DATED</span>
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">:&nbsp;the &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;________________&nbsp; day of&nbsp; ______________________</span>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">SIGNED</span> 
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">:&nbsp; 
  _______________________________ &nbsp;</span>
  <b><span style="font-family: Arial Rounded MT Bold;font-size :15.5px">(borrower(s) 
  signature)</span></b>
  </p>
  <p class="MsoNormal_p_contract_new" style="margin:3 0cm; border:medium none; padding:0cm;width:650px">&nbsp;
  </p>
  <p class="MsoNormal_p_contract_new" style="border: medium none; margin: 3 0cm; padding: 0cm;width:650px">
  <span style="font-family: Arial Rounded MT Bold;font-size :15.5px">&nbsp;</span><b> <span style="font-family: Arial Rounded MT Bold;font-size:3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family: Arial Rounded MT Bold;font-size:3">&nbsp;&nbsp;&nbsp;&nbsp;_____________________________&nbsp; (borrower(s) signature)</span></b> 
 </p>
 </div>
 <p>&nbsp;&nbsp;<span style="font-size :small;color :Gray">&nbsp; NETL </span><asp:Label ID="Label1" runat="server"  Font-Size="Small" ForeColor ="Gray" > </asp:Label></p>
<p style="margin-top:20.0pt; margin-bottom:20.0pt; width: 755px">
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label23" runat="server"  Font-Size="Small"></asp:Label></p>

</asp:Panel>
<asp:Panel ID="P1new" runat ="server" Visible="false"  >
<p>&nbsp;</p>
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
 <table border="1" cellpadding="0" cellspacing="0" style="margin-left:11.0pt;border-collapse: collapse;border-color:#111111;width:520px;height:440px" id="Table1">
 <tr>
 <td >
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left:5.0pt;border-collapse: collapse;border-color:#111111;width:520px; height:430px" id="Table2">

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
    <table border="0" cellpadding="0" cellspacing="1" style="margin-left:9.0pt;border-collapse: collapse;border-color:#111111;width:600px;height:50px" id="Table3" >
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
 &nbsp; &nbsp;&nbsp; <asp:Label ID="Label38" runat="server"  Font-Size="small" ></asp:Label><span style="font-size: small; font-weight:bold; text-align :right ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1 of&nbsp; 1</span></p>
<%--..............................................
--%>
</asp:Panel> 
</div>
</form>
</body>
</html>
