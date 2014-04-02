<%@ Control Language="VB" AutoEventWireup="false" CodeFile="letter.ascx.vb" Inherits="toolbaar_letter" %>
    <head>
    <title>Loan Repayment</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <script type = "text/javascript">
         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Click OK to create Enforcement letter!")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }
         </script>
    </head>
    <div align="center" >
    <asp:Panel ID="Panel1" runat="server">
    <table class="table_loanrepay">
    <tr>
    <td >Notices & Letters<asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="100%" 
    CellSpacing="2">
    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="Description" HeaderText="Notice Description" />
    <asp:BoundField DataField="Notice_Created_On" HeaderText="Notice created on" />
    <asp:BoundField DataField="Notice_Expires_On" HeaderText="Notice expires on" />
        <asp:BoundField DataField="Notice_ID" HeaderText="Notice_ID" />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>
   </td> 
   </tr> 
   <tr>
   <td class="align-center" >
   <asp:Label ID="lbl_letter" runat="server" Text="No Letters Found" Visible ="false" ></asp:Label>
   </td>
   </tr>
   <tr>
   <td class="align-center">
   <br />
   <asp:Button ID="cancel_letter" runat ="server"  Text="Cancel & go back" Visible="false" CssClass="align_mid" />
    <asp:Button ID="letter_enf" runat="server"  Text="Enforcement Letter"  Visible="false" CssClass="align_mid"  OnClientClick="Confirm() ;"/>
    <br /><br />
   </td> 
   </tr>
   </table> 
   </asp:Panel>
   <br />
   </div> 