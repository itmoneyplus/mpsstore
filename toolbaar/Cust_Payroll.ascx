<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cust_Payroll.ascx.vb" Inherits="toolbaar_Cust_Payroll" %>
<head>
    <title>tool_payrolltabs</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    </head>
    <div id="toolbar">
    <table id="Table1" cellspacing="0" >
     <tr>
     <td>
    &nbsp;
    </td>   
    </tr>  
    </table> 
     <table id="Table2" cellspacing="0" >
     <tr  class ="label_italics">
     <td >
   Payroll File
    </td>   
    </tr>  
    </table> 
    <table id="toolbar_table" cellspacing="0" >
     <tr>
     <td>
     &nbsp;
    </td>   
    </tr>  
    </table> 
    <table id="Table3" cellspacing="0" >
    <tr  class ="toolbaar1_tr">
    <td class="toolbaar1_td_rep">
    <asp:LinkButton ID="Link_payroll" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_PayrollDue.aspx" TabIndex="1" >Payroll Deduction Due</asp:LinkButton>
    </td>   
    </tr>  
    </table> 
    <br />
    <table id="Table4" cellspacing="0">
    <tr  class ="toolbaar1_tr">
    <td class="toolbaar1_td_rep">
    <asp:LinkButton ID="Link_viewpayroll" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_PayrollRec.aspx"  TabIndex="2">View Payroll Deductions</asp:LinkButton>
    </td>   
    </tr>
   </table> 
   </div> 