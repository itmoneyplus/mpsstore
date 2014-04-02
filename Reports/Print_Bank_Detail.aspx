<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Print_Bank_Detail.aspx.vb" Inherits="Customer_Print_Bank_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Print Bank Detail</title>
  <%--   CSS used--%>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
    <%--    Javascript used--%>
<script type="text/javascript"  src="../frm_val.js" >
</script>
</head>
 <body onload="window.print();">
 <form id="form1" runat="server" ondblclick="javascript:history.back();">
 <div  align="center" >
 <table cellpadding="3" class ="table_loanrepay" >
 <tr>
 <td  class="td_print_bnk" colspan="4"  ><b>BSB &amp; Account No. Details:</b></td>
 </tr>
 <tr>
 <td class="td_print_bnk">Bank name:</td>
 <td>
 <asp:TextBox ID="txtBankName_print" runat="server" TabIndex ="11"   Height="17px"  Width="218px" MaxLength="45" ></asp:TextBox></td>
 <td class="td_print_bnk"> Bank address:</td>
 <td class="td_print_bnk">
 <asp:TextBox ID="txtBankAddress_print" runat="server" TabIndex ="12"  Height="17px"  Width="223px" MaxLength="45" ></asp:TextBox></td>
 </tr>
 <tr>
 <td class="td_print_bnk" >BSB:</td>
 <td class="td_print_bnk">
 <asp:TextBox ID="txtBSB_print" runat="server" TabIndex ="13" CssClass="align"  Height="17px"  Width="112px" MaxLength="7" onkeypress="addcom();" ></asp:TextBox>
 </td>
 <td class="td_print_bnk">Suburb:</td>
 <td class="td_print_bnk">
 <asp:TextBox ID="txtBankSuburb_print"  runat="server" TabIndex ="14"  Height="17px"  Width="218px" MaxLength="25" ></asp:TextBox></td>
 </tr>
 <tr>
 <td class="td_print_bnk">Account number:</td>
 <td class="td_print_bnk"><asp:TextBox ID="txtAccountNumber_print"   runat="server" TabIndex ="15"  CssClass="align"  Height="17px"  Width="218px" MaxLength="15" ></asp:TextBox></td>
 <td class="td_print_bnk">State:</td>
 <td class="td_print_bnk"><asp:TextBox ID="txtBankState_print"  runat="server" TabIndex ="16"   Height="17px"  Width="61px" MaxLength="3" ></asp:TextBox></td>
 </tr>
 <tr>
 <td class="td_print_bnk" >Account name:</td>
 <td class="td_print_bnk">
 <asp:TextBox ID="txtAccountName_print"  runat="server" TabIndex ="17" CssClass="align" Height="17px" Width="218px" Enabled="False" MaxLength="45" ></asp:TextBox></td>
 <td class="td_print_bnk">Post code:</td>
 <td class="td_print_bnk"><asp:TextBox ID="txtBankPostCode_print"  runat="server" TabIndex ="18"   Height="17px"  Width="60px" MaxLength="4" ></asp:TextBox></td>
 <td class="td_print_bnk"></td></tr>
 </table>
 </div>
</form>
</body>
</html>
