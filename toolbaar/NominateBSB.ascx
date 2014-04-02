<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NominateBSB.ascx.vb" Inherits="toolbaar_NominateBSB" %>
    <head>
    <title>Nominate BSB</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    </head>
    <div align="center" >
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
    AutoGenerateColumns="False" Font-Size="14px" Width ="95%" Font-Bold="True">
    <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
    <Columns>
    <asp:BoundField DataField="BSB" HeaderText="BSB" />
    <asp:BoundField DataField="Account_Number" HeaderText="Account" />
    <asp:BoundField DataField="Bank_Name" HeaderText="Bank Name" />
    <asp:BoundField DataField="Bank_Suburb" HeaderText="Suburb" />
    <asp:BoundField DataField="Bank_State" HeaderText="State" />
    <asp:BoundField DataField="Bank_Post_code" HeaderText="Post Code"/>
    <asp:BoundField DataField="Bank_Address" HeaderText="Address"/>
    <asp:BoundField DataField="Bank_Account_ID" HeaderText="Bank_Account_ID" />
    <asp:BoundField DataField="Account_Name" HeaderText="Account_Name" />
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White"       
     HorizontalAlign="Center" />
    </asp:GridView>
    <table class="table_noborder" id="tbl1" >
    </table>
    <table id="tbl2">
    <tr>
    <td>
    <asp:Button ID="Btnnominate" runat="server" Text="Nominate BSB for Direct Debit"  CssClass="txt-center1" Visible =false />
    <asp:Label ID="Label1" runat="server" Text="Nominate Bank "  CssClass="txt-center" Height="20px" Width="350px" Visible=false ></asp:Label>
    </td>
    </tr>
    </table>
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

