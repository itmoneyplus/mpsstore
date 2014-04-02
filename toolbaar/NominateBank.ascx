<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NominateBank.ascx.vb" Inherits="toolbaar_NominateBank" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Test</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />    

</head>
<div align="center" id="">
    <table class="table" align="center">       
        <tr>
            <td>                                
                          <%--<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                                EnableScriptLocalization="true" ID="ScriptManager1" />
                            <asp:UpdatePanel ID="CollapseDelegate" runat="server">
                                <ContentTemplate>--%>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        <%--  </ContentTemplate>
                            </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>                                                                 
    <asp:Button ID="Btnnominate" runat="server" Text="Nominate BSB for Direct Debit" CssClass="txt-center1" />  
    <table cellpadding="3" class ="nominate_bank_center_align">
    <tr>
    <td  colspan="4"  ><b>The following BSB from the above list is nominated for direct debit</b></td>
    </tr>
    <tr>
    <td class="td"> Bank name:</td>
    <td class="td">
    <asp:TextBox ID="txtBankName" runat="server" TabIndex ="11"  CssClass="txtbox" Height="17px"  Width="223px" MaxLength="45" ></asp:TextBox></td>
    <td class="td"> Bank address:</td>
    <td class="td">
    <asp:TextBox ID="txtBankAddress" runat="server" TabIndex ="12" CssClass="txtbox" Height="17px"  Width="223px" MaxLength="45" ></asp:TextBox></td>
    </tr>
    <tr>
     <td  class="td" >BSB:</td>
     <td  class="td">
     <asp:TextBox ID="txtBSB" runat="server" TabIndex ="13"  CssClass="align"  Height="17px"  Width="112px" MaxLength="7" onkeypress="addcom();" ></asp:TextBox>
     </td>
     <td class="td">Suburb:</td>
     <td class="td">
     <asp:TextBox ID="txtBankSuburb"  runat="server" TabIndex ="14" CssClass="txtbox"  Height="17px"  Width="146px" MaxLength="25" ></asp:TextBox></td>
     </tr>
     <tr>
     <td class="td">Account number:</td>
     <td class="td"><asp:TextBox ID="txtAccountNumber" runat="server" TabIndex ="15" CssClass="align"  Height="17px"  Width="109px" MaxLength="8" ></asp:TextBox></td>
     <td class="td">State:</td>
     <td class="td"><asp:TextBox ID="txtBankState"  runat="server" TabIndex ="16" CssClass="txtbox"  Height="17px"  Width="61px" MaxLength="3" ></asp:TextBox></td>
     </tr>
     <tr>
     <td class="td" >Account name:</td>
     <td class="td">
     <asp:TextBox ID="txtAccountName"  runat="server" TabIndex ="17" CssClass="align" Height="17px" Width="174px" MaxLength="45" ></asp:TextBox></td>
     <td class="td">Post code:</td>
     <td class="td"><asp:TextBox ID="txtBankPostCode"  runat="server" TabIndex ="18"  CssClass="txtbox"  Height="17px"  Width="54px" MaxLength="4" ></asp:TextBox></td>
     <td class="td"></td></tr>
     <tr>
     <td>
     </td>
     </tr>
      <tr>
     <td class="td" colspan ="2">
     <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Customer/Bank Detail.aspx">Nominate BSB</asp:LinkButton>
     </td>
     <td class="td">
     </td>
     </tr>
     </table>                                                                                                             
</div>
