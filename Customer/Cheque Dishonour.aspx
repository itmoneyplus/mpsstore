<%@ Page Language="VB" Culture="en-AU" EnableEventValidation ="false"  AutoEventWireup="false" CodeFile="Cheque Dishonour.aspx.vb" Inherits="Customer_Detail"  maintainScrollPositionOnPostBack="false" %>
<%@ Register Src="~/toolbaar/tool_main.ascx"  TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register src="~/toolbaar/Cheque_dishonoured.ascx" TagName="Tool_Chedis" TagPrefix ="tl_chedis"%>
<%@ Register Src="~/toolbaar/tool.ascx" TagName="Toolbaar3"  TagPrefix="tool3"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html>
    <head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
    <title>Cheque Dishonour</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    </head>
    <body>
    <form id="form1" runat="server">
  
    <div>
    <tool1:Toolbaar1  ID ="tool_first" runat="server" />
    <table class="table" align="center" >
    <tr>
    <td>
    <asp:TextBox id="txtsearch"  runat ="server" TabIndex="8" style="width:120px" ></asp:TextBox>
    <asp:Button ID="btnsearch" runat="server"  Text ="Search" TabIndex="9" style="width:60px;height:25px"/>
    <asp:Label runat ="server" ID="label2"  >|</asp:Label>
    <asp:LinkButton runat="server" id="LinkButton1" Text="Add Customer" CssClass="link_text" TabIndex="10"></asp:LinkButton>
    <asp:Label runat ="server" ID="label3"  >|</asp:Label>
    </td>
    </tr>
    </table>
    <br />
    <br />
    <br />
    <asp:Label ID="Label4" runat="server"  CssClass="label_text" Text="Customer Search Result:" Visible="False"></asp:Label>
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
    <asp:BoundField DataField="Request_Amount" HeaderText="Request Amount" DataFormatString="{0:c}" />
    <asp:BoundField DataField="Date_Joined" HeaderText="Date Joined"  SortExpression="Date Joined" DataFormatString="{0:d}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Time_Joined" HeaderText="Time_Joined"  SortExpression="Time_Joined" DataFormatString="{0:T}"  HtmlEncode="false"  />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:GridView>
    <div id="MainContainer" >
    <tool3:Toolbaar3 id="tool3" runat ="server" />
    <br />
    <tl_chedis:Tool_Chedis ID="che_id" runat="server" />
    </div>
    </div>
    </form>
    </body>
    </html>
