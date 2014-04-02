<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Customer_cre.ascx.vb" Inherits="toolbaar_Customer_cre" %>
 <head>
    <title>tool_cretabs</title> 
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
     Customer Credit
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
    <asp:LinkButton ID="Link_creditdue" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_CreditDue.aspx" TabIndex="1" >Credit Due</asp:LinkButton>
    </td>   
    </tr>  
    </table> 
    <br />
    <table id="Table4" cellspacing="0">
    <tr  class ="toolbaar1_tr">
    <td class="toolbaar1_td_rep">
    <asp:LinkButton ID="Link_creditrec" runat="server"  CssClass="toolbaar1_link" PostBackUrl="~/Customer/Customer_CreditRec.aspx"  TabIndex="2">Credit Recieved</asp:LinkButton>
    </td>   
    </tr>
   </table> 
   </div> 