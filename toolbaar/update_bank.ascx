<%@ Control Language="VB" AutoEventWireup="false" CodeFile="update_bank.ascx.vb" Inherits="toolbaar_update_bank" %>
    <head>
    <title>update_bank</title> 
    <link rel="stylesheet" type="text/css" href="../css/style.css" /> 
    </head>
    <div align="center" id="MainContainer2" >
    <asp:Panel ID="Panel2" runat="server">
    <table  class="update_bank_table3">
    <tr> 
    <td class="align"><b class="italics1-doc">Bank Details</b> 
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
     BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" Width="100%" 
    CellSpacing="2"  style="margin-top: 27px">
    <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="Black" 
    BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="BSB" HeaderText="BSB" />
    <asp:BoundField DataField="Account_Number" HeaderText="Account" />
    <asp:BoundField DataField="Bank_Name" HeaderText="Bank Name" />
    <asp:BoundField DataField="Bank_Suburb" HeaderText="Suburb" />
    <asp:BoundField DataField="Bank_State" HeaderText="State" />
    <asp:BoundField DataField="Bank_Post_code" HeaderText="Post Code" />
    <asp:BoundField DataField="Bank_Address" HeaderText="Address" />
    <asp:BoundField DataField="Bank_Account_ID" HeaderText="Bank_Account_ID" />
    <asp:BoundField DataField="Account_Name" HeaderText="Account_Name" />
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
    <td class ="align-center" >
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add New Account"   /></td>
    </tr> 
    </table>     
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <table class="update_bank_table_new">
    <tr>
    <td>
    <asp:Label ID="Label5"  runat="server" CssClass="label_italics" Text="Bank Details:"></asp:Label>
    <br/>
    </td>
    </tr>
    <tr>
    <td class ="align-center1" >
    <span>There are no BSB recorded for&nbsp;</span>
    <asp:Label ID="Label6" runat="server" CssClass ="update_bank_table_lbl"></asp:Label>
    </td>
    </tr>
     <tr><td></td></tr>
     <tr><td ></td></tr>
     <tr><td></td></tr>
     <tr> <td class ="align-center" ><asp:Button ID="Button2" runat="server" Text="Add New Account"  /></td></tr>
     <tr><td ></td></tr>  
     <tr><td class="update_bank_table_center">No Loans Found</td></tr> 
     </table>  
     </asp:Panel>
     </div>
    