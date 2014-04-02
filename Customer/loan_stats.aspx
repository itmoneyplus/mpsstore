<%@ Page EnableEventValidation="false" Culture="en-AU" Language="VB" AutoEventWireup="false" CodeFile="loan_stats.aspx.vb" Inherits="Customer_loan_stats" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loans Found</title>
     <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script language="JavaScript" type="text/javascript" >
//         javascript: window.history.forward(1);
    </script>
   </head>
<body>
    <form id="form1" runat="server">
    <div>
    <tool1:Toolbaar1 ID ="tool_first" runat="server" />
    <table  class="table" align="center">
     <tr>
    <td>
    <asp:TextBox id="txtsearch"  runat ="server" TabIndex="8" style="width:120px"></asp:TextBox>
    <asp:Button ID="btnsearch" runat="server"  Text ="Search" TabIndex="9" style="width:60px;height:25px"  />
    <asp:Label runat ="server" ID="label1"  >|</asp:Label>
    <asp:LinkButton runat="server" id="LinkButton1" Text="Add Customer" CssClass="link_text" TabIndex="10"></asp:LinkButton>
    <asp:Label runat ="server" ID="label2"  >|</asp:Label>
    </td>
    </tr> 
    </table>
    </div>
    <br/>
    <asp:Label ID="Label3" runat="server"  CssClass ="label_text" Text="Customer Search Result:" Visible="False"></asp:Label>
    <br />
    <br />
 
    <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="100%" 
    CellSpacing="2" Font-Bold="True">
    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" 
    BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" />
    <asp:BoundField DataField="Given_Name" HeaderText="Given Name" />
    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
    <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date Of Birth" SortExpression="Date Of Birth" DataFormatString="{0:d-MMM-yyyy}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Request_Amount" HeaderText="Request Amount" 
        DataFormatString="{0:c}" />
    <asp:BoundField DataField="Date_Joined" HeaderText="Date Joined"  SortExpression="Date Joined" DataFormatString="{0:d}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Time_Joined" HeaderText="Time_Joined"  
    SortExpression="Time_Joined" DataFormatString="{0:hh:mm tt}"  
    HtmlEncode="false"  />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" 
        VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" 
        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
        HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" 
        HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>
  <asp:Panel id="Panel1" runat="server" >
   <br />
   <br />
  <div align="center">
   <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"  CssClass="italics1-doc"></asp:Label>
   <br />
   <br />
   
  <asp:GridView ID="GridView2" runat="server" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Font-Size="14px" 
    ForeColor="Black" RowHeaderColumn="Customer Id" Width="80%" 
    CellSpacing="2" Font-Bold="True">
    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" 
    BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" />
    <asp:BoundField DataField="Given_Name" HeaderText="Given Name" />
    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
    <asp:BoundField DataField="Amount" HeaderText="Loan Amount" 
            DataFormatString="{0:c}"  />
    <asp:BoundField DataField="Loan_Date" HeaderText="Date Of Loan" 
            DataFormatString="{0:d}"  HtmlEncode="false"  />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" 
        VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" 
        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" 
        HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" 
        HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>
   <br />
   <asp:Button ID="btn_print" runat="server" Text="Print List"  Visible ="false" Width ="110px" />
   <br />
   <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"  CssClass="italics1-doc"></asp:Label>
   <br />
   <br />
  </div>
  </asp:Panel>
   </form>
 </body>
</html>
