<%@ Page Language="VB" Culture="en-AU" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Address_Look_Up_New.aspx.vb" Inherits="Common_Files_Address_Look_Up" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

 <head runat="server">
 <title>Address Look up</title>
 <script type ="text/javascript" language ="javascript"  >
  window.resizeTo(610, 700)
 </script>
 <link rel="stylesheet" type="text/css" href="../css/style.css" />
 </head>
 <body class="body">
 <form id="form1" runat="server" >
 <div class="div"> 
 <asp:GridView ID="GridView1" runat="server" BackColor="Black" 
 BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
 Font-Size="13px" AllowPaging="True" AutoGenerateColumns="False" 
 Height="162px" PageSize="100" Width="515px" >
<RowStyle BackColor="White" ForeColor="Black" BorderColor="Black" 
 HorizontalAlign="Center" />
<Columns>
<asp:BoundField AccessibleHeaderText="Post Code" DataField="Post_Code" HeaderText="Post Code" />
<asp:BoundField AccessibleHeaderText="Suburb" DataField="Suburb" HeaderText="Suburb" />
<asp:BoundField AccessibleHeaderText="State" DataField="State" HeaderText="State" />
</Columns>
<FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
<PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
</asp:GridView>
 </div>
</form>
</body>
</html>
