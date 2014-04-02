<%@ Page Language="VB" Culture="en-AU" EnableEventValidation="false"  AutoEventWireup="false" CodeFile="Upload_docs_new1.aspx.vb" Inherits="Customer_Upload_docs_new1" %>
<%@ Register Src="~/toolbaar/tool_main.ascx" TagName="Toolbaar1"   TagPrefix="tool1"%>
<%@ Register Src="~/toolbaar/tool.ascx" TagName="Toolbaar3"  TagPrefix="tool3"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Customer Docs</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<body>
<form id="form1" runat="server">
<div class="align">
<tool1:Toolbaar1  ID="tool1" runat="server" />
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
    <RowStyle BackColor="White" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
    <Columns>
    <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" />
    <asp:BoundField DataField="Given_Name" HeaderText="Given Name" />
    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
    <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date Of Birth" SortExpression="Date Of Birth" DataFormatString="{0:d-MMM-yyyy}"  HtmlEncode="false"  />
    <asp:BoundField DataField="Request_Amount" HeaderText="Request Amount" DataFormatString="{0:c}" />
    <asp:BoundField DataField="Date_Joined" HeaderText="Date Joined" SortExpression="Date Joined" DataFormatString="{0:d}" HtmlEncode="false"  />
    <asp:BoundField DataField="Time_Joined" HeaderText="Time_Joined" SortExpression="Time_Joined" DataFormatString="{0:hh:mm tt}" HtmlEncode="false"  />
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
    <br/>
    <asp:Panel ID="Panel1" runat="server" >
    <div align="center">
    <table  class ="table_loanrepay">
    <tr><td>&nbsp;</td></tr>
    <tr><td> 
        
        </td></tr>
    <tr>
    <td>
    <asp:Label ID="L1" runat="server"  CssClass ="label_italics"
    Text="Upload Documents!!!"  ></asp:Label>
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
     <tr>
     <td class="align-center">
     &nbsp;&nbsp; &nbsp;&nbsp;<asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
     </td>
     </tr>
     <tr><td>&nbsp;</td></tr>    
     <tr>
     <td align ="center" >
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                BackColor="#CCCCCC" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" Font-Size="Medium" 
        ForeColor="Black" RowHeaderColumn="Customer Id" Width="85%" 
        CellSpacing="2" style="margin-bottom: 0px" DataKeyNames="Document_ID">
            
            
                <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            
            
                <Columns>
                    <asp:BoundField DataField="Document_ID" HeaderText="Document ID" />
                 
                    <asp:BoundField DataField="File_Name" HeaderText="Document File" />
                    <asp:TemplateField HeaderText ="Delete">
                      <ItemTemplate>
       <span onclick="return confirm('Are you sure to Delete the record?')">

      <asp:LinkButton ID="btnDelete" Text="Delete" runat="server"  CommandName="Delete" />
      </span>
      </ItemTemplate>
        </asp:TemplateField>
                </Columns>
            
            
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" />
            
            
            </asp:GridView>
            

    
     </td>
     </tr>
     </table>
      </div>
      </asp:Panel>
      </div> 

   </form>
 </body>
</html>