<%@ Control Language="VB" AutoEventWireup="false" CodeFile="tool_cheque.ascx.vb" Inherits="toolbaar_tool_cheque" %>
  <head>
  <title>tool_cheque</title> 
  <link rel="stylesheet" type="text/css" href="../css/style.css" />
  </head>
   <div align="center" >
    <table cellspacing="0" class ="toolbaar2_table">
    <tr>
    <td class="align"> <asp:Label ID="Label2" runat="server" Text="Cashed Summary"  CssClass="italics1-doc"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="95%" 
    CellSpacing="2"  style="margin-left:30px; margin-top: 20px">
    <RowStyle BackColor="White" HorizontalAlign="Left" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:TemplateField HeaderText="No.">
    <ItemTemplate><%# Container.DataItemIndex + 1 %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="no" HeaderText="No" Visible="False" />
    <asp:BoundField DataField="Cheque_Cashed_On" DataFormatString="{0:d-MMM-yyyy}" 
    HeaderText="Date" />
    <asp:BoundField DataField="cheque_amount" HeaderText="Cheque Amount" DataFormatString="{0:c}" />
    <asp:BoundField DataField="cheque_fee" HeaderText="Cheque Fee"  />
    <asp:BoundField HeaderText="%age" />
    <asp:BoundField DataField="pay_cash_now" HeaderText="Cash Paid" DataFormatString="{0:c}" />
    <asp:BoundField DataField="Cheque_Cashing_ID" HeaderText="Cheque_Cashing_ID" />
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
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td class="toolbaar2td"> <asp:Label ID="Label3" runat="server" Text="Total Outstanding:" Visible="false" ></asp:Label>
    &nbsp;<asp:Label ID="Label6" runat="server" Text="$"  Visible="False"></asp:Label>&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"  Visible="false"></asp:Label></td>
    </tr>
    <tr>
    <td>
    <b><asp:Label ID="Label5" runat="server" Text="No Cheque Summary Found"  Visible ="false" CssClass="italics1-doc">
    </asp:Label></b></td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
    </table>
    </div>
